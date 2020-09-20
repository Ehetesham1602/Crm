using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class UserScreenAccess
    {
        public int Id { get; set; }
        public Guid UserRoleId { get; set; }
        public int ScreenId { get; set; }
        public bool CanAccess { get; set; }
    }
}
