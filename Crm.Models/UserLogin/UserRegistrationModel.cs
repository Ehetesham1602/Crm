﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.UserLogin
{
    public class UserRegistrationModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
    }
}