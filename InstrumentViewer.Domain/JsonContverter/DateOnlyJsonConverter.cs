using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstrumentViewer.Domain.JsonContverter
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateOnly.ParseExact(reader.GetString()!,
                    "dd.MM.yyyy");

        public override void Write(
            Utf8JsonWriter writer,
            DateOnly dateTimeValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    "dd.MM.yyyy"));
    }
}
