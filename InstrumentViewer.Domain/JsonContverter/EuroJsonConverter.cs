using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;
using System.Globalization;

namespace InstrumentViewer.Domain.JsonContverter
{
    public class EuroJsonConverter : JsonConverter<Euro>
    {
        public override Euro Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {

            var Value = reader.GetString()!;
            var subString = Value.Substring(0, Value.Length - 1);
            var doubleValue = double.Parse(subString, CultureInfo.InvariantCulture);
            return new Euro(doubleValue);

        }


        public override void Write(
            Utf8JsonWriter writer,
            Euro EuroValue,
            JsonSerializerOptions options)
        {
            var stringValue = EuroValue.ToString();
            writer.WriteStringValue(stringValue);
        }
    }
}
