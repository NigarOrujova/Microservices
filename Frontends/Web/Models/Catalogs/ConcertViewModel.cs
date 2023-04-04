using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Models.Catalogs
{
    public class ConcertViewModel
    {
        public string Id { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public string Location { get; set; }
        public int AvailableTickets { get; set; }
    }
}