﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.UserLogin
{
  public  class UserRegistrationEditModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public int Extention_no { get; set; }
    }
}