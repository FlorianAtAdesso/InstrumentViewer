using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentViewer.Domain
{
    public class Euro
    {
        public double Amount { get; set; }

        public Euro(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException($"The amount can not be lower than 0, but the Prived value was: {amount}");
            }

            Amount = Math.Round(amount, 2) ;
        }

        public override string ToString()
        {
            return $"{Amount.ToString(CultureInfo.InvariantCulture)}€";
        }
    }
}
