using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AdvertisementApp.Dtos.Interfaces;

namespace Web.AdvertisementApp.Dtos
{
    public class ProvidedServiceCreateDto : IDto
    {
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
