using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Models.Catalogs
{
    public class TicketUpdateInput
    {
        public string Id { get; set; }

        [Display(Name = "Bilet ismi")]
        public string Name { get; set; }

        [Display(Name = "Bilet açıklama")]
        public string Description { get; set; }

        [Display(Name = "Bilet fiyat")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }
        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Bilet kategori")]
        public string ConcertId { get; set; }

        [Display(Name = "Bilet Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}