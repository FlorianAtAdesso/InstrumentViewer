using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using InstrumentViewer.Domain;
using Microsoft.Azure.Cosmos;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using InstrumentViewer.API.CosmosDbModells;
using System.Net.Http;
using System.Text;
using InstrumentViewer.API.RequestModell;
using System.Text.Json.Serialization;
using InstrumentViewer.API.Serializer;

namespace InstrumentViewer.API
{
    public static class DataSupplier
    {

        private static IConfigurationRoot config = new ConfigurationBuilder().AddEnvironmentVariables().Build();


        private const string DB_KEY_NAME = "dbKey";
        private const string DB_ENDPOINT_NAME = "dbEndPoint";
        private const string DATABASE_NAME = "DateBaseName";
        private const string CONTAINER_NAME = "ContainerName";


        [FunctionName("GetInstrument")]
        public static async Task<HttpResponseMessage> GetInstrument(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage reqMessage, HttpRequest req,
            ILogger log)
        {
            try
            {
                string id = req.Query["id"];
                if (string.IsNullOrWhiteSpace(id))
                {
                    var errorResponse = reqMessage.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    errorResponse.Content = new StringContent($"Expected a proprty ID in the query, but there was none", Encoding.UTF8, "text/plain"); 
                    return errorResponse;
                }


                var RequestedId = new ID(id);

                var container = await GetContainerAsync();
                string json = await ReadInstrumentAsJsonFromContainer(RequestedId, container);

                var response = reqMessage.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json"); ;
                return response;

            }
            catch (Microsoft.Azure.Cosmos.CosmosException e)
            {
                if(e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return reqMessage.CreateResponse(System.Net.HttpStatusCode.NotFound);
                }
                log.LogError(e.ToString());
                return reqMessage.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return reqMessage.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [FunctionName("GetAllInstrument")]
        public static async Task<HttpResponseMessage> GetAllInstrument(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            try
            {
                var container = await GetContainerAsync();

                var Instruments = container.GetItemLinqQueryable<Instrument>(true).ToList();
                Instruments.AddRange(Instruments);
                Instruments.AddRange(Instruments);

                var json = JsonSerializer.Serialize(Instruments);
                var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json"); ;
                return response;
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
        }


        [FunctionName("AddInstrument")]
        public static async Task<HttpResponseMessage> AddInstrument(
             [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage req,
             ILogger log)
        {

            try
            {

                var body = await req.Content.ReadAsStringAsync();

                if (!TryToDeserializeInstrumentForCosmos(body, out InstrumentForCosmos Instrument))
                {
                    var response = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    response.Content = new StringContent($"The body was in the wong format, the expected format is: {JsonSerializer.Serialize(new Domain.Instrument("Instrument Name", 10, DateOnly.Parse("11.11.2011"), new Euro(45.50)))} \r\n the Provied body was : {body}", Encoding.UTF8, "text/plain"); ;
                    return response;
                }

                var container = await GetContainerAsync();

                var result = await container.CreateItemAsync(Instrument);

                return req.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            catch (Microsoft.Azure.Cosmos.CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var ConflictResponse = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    ConflictResponse.Content = new StringContent("The Instrument with the Name allready exist", Encoding.UTF8, "text/plain");
                    return ConflictResponse;
                }
                log.LogError(e.ToString());
                return req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);

            }
        }
        private static async Task<string> ReadInstrumentAsJsonFromContainer(ID RequestedId, Container container)
        {
            var InstrumentResponse = await container.ReadItemAsync<Instrument>(RequestedId.Id, new PartitionKey(RequestedId.Id));
            var Instrument = InstrumentResponse.Resource;
            var json = JsonSerializer.Serialize(Instrument);
            return json;
        }

        private static async Task<Container> GetContainerAsync()
        {
            var DBKey = config[DB_KEY_NAME];
            var DBEndPoint = config[DB_ENDPOINT_NAME];
            var DBID = config[DATABASE_NAME];
            var ContainerID = config[CONTAINER_NAME];

            var CosmosClientOptions = new CosmosClientOptions
            {
                Serializer = new CosmosSystemTextJsonSerializer(new JsonSerializerOptions())
            };

            // New instance of CosmosClient class
            CosmosClient client = new(
                accountEndpoint: DBEndPoint,
                authKeyOrResourceToken: DBKey!,
                CosmosClientOptions
            );



            // Database reference with creation if it does not already exist
            Database database = await client.CreateDatabaseIfNotExistsAsync(
                id: DBID
            );

            //Console.WriteLine($"New database:\t{database.Id}");

            Container container = await database.CreateContainerIfNotExistsAsync(
                id: ContainerID,
                partitionKeyPath: "/Name"
            );

            return container;
        }
        private static bool TryToDeserializeID(string json, out ID value)
        {
            try
            {
                value = JsonSerializer.Deserialize<ID>(json);
                return true;
            }
            catch (Exception)
            {
                value = null;
                return false;
            }
        }

        private static bool TryToDeserializeInstrumentForCosmos(string json, out InstrumentForCosmos value)
        {
            try
            {
                value = JsonSerializer.Deserialize<InstrumentForCosmos>(json);
                return true;
            }
            catch (Exception)
            {
                value = null;
                return false;
            }
        }

        
    }
}
