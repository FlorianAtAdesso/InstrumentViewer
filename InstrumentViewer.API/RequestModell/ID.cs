using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentViewer.API.RequestModell
{
    public class ID
    {
        public ID()
        {

        }
        public ID(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
