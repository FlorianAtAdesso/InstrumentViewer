using InstrumentViewer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentViewer.WebApp.Pages
{
    public class InstrumentInfoModel : PageModel
    {
        public Instrument Instrument { get; set; }
        public void OnGet()
        {
            Instrument = new Instrument("very first Instrument", 10, DateOnly.Parse("10.10.2010"), new Euro(15.44));
        }
    }
}
