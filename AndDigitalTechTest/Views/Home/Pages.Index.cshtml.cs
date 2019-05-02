using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AndDigitalTechTest.Pages
{
    public class IndexModel : PageModel
    {
        public int _id { get; set; }
        public string _customersName { get; set; }
        public long _customersPhoneNumber { get; set; }


    }
}