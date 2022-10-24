// See https://aka.ms/new-console-template for more information
using InstrumentViewer.Domain;
using System.Text.Json;

var instro = new InstrumentViewer.Domain.Instrument("Very First Instrument", 10, DateOnly.Parse("11.11.2011"), new Euro(1999.999)); ;

var json = JsonSerializer.Serialize(instro);
Console.WriteLine(json);

Instrument insto = JsonSerializer.Deserialize< Instrument >(json);

Console.WriteLine(insto);
