using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AdvertisementApp.Entities;

namespace Web.AdvertisementApp.Entities
{
    public class AdvertisementAppUserStatus : BaseEntity
    {
        public string Definition { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
