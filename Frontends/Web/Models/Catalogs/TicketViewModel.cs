using CodeAcademy.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Models.Catalogs
{
    public class TicketViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get => Description.Length > 100 ? Description.Substring(0, 100) + "..." : Description;
        }

        public decimal Price { get; set; }

        public string UserId { get; set; }
        public string Picture { get; set; }

        public string StockPictureUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public FeatureViewModel Feature { get; set; }

        public string ConcertId { get; set; }

        public ConcertViewModel Concert { get; set; }
    }
}