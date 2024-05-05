using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fbu.AdvertisementApp.Entities
{
    public class AppUserRole :BaseEntity
    {
        public int AppUserID {  get; set; }
        public string AppUser { get; set; }
        public int AppRoleId {  get; set; }
        public AppRole AppRole { get; set; }
        
        
    }
}
