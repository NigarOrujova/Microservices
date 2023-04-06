using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Models.Catalogs
{
    public class ConcertViewModel
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        public string? Location { get; set; }
        public int AvailableTickets { get; set; }
    }
}