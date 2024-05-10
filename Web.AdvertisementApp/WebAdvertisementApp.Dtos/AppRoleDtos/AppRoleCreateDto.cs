using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AdvertisementApp.Dtos.Interfaces;

namespace Web.AdvertisementApp.Dtos.AppRoleDtos
{
    public class AppRoleCreateDto : IDto
    {
        public string Definition { get; set; }
    }
}
