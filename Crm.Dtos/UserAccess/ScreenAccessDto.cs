using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Dtos.UserAccess
{
    public class ScreenAccessDto
    {
        public int Id { get; set; }
        public Guid UserRoleId { get; set; }
        public int ScreenId { get; set; }
        public bool CanAccess { get; set; }
        public string ScreenName { get; set; }
    }
}
