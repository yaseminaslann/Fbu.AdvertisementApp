using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Web.AdvertisementApp.Entities;

namespace Web.AdvertisementApp.Entities
{
    public class ProvidedService : BaseEntity
    {
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}