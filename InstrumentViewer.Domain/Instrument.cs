using InstrumentViewer.Domain.JsonContverter;
using System.Text.Json.Serialization;

namespace InstrumentViewer.Domain
{
    public class Instrument
    {
        public string Name { get; set; }
        public int Slots { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly RealseDate { get; set; }

        [JsonConverter(typeof(EuroJsonConverter))]
        public Euro Price { get; set; }

        public Instrument(string name, int slots, DateOnly realseDate, Euro price)
        {
            Name = name;
            Slots = slots;
            RealseDate = realseDate;
            Price = price;
        }
    }
}