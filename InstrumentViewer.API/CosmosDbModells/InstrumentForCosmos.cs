using InstrumentViewer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentViewer.API.CosmosDbModells
{
    internal class InstrumentForCosmos : Instrument
    {
        public InstrumentForCosmos(string name, int slots, DateOnly realseDate, Euro price) : base(name, slots, realseDate, price)
        {
        }

        public string id => this.Name; 
    }
}
