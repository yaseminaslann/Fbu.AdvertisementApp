﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fbu.AdvertisementApp.Entities
{
   public class AppUser :BaseEntity
    {
        public string Username {  get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId {  get; set; }
        public Gender Gender { get; set; }

        public List<AppUserRole> AppUserRoles {  get; set; }
    }

}