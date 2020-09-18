using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class ActivityNotes
    {
        public int Id { get; set; }
        public string NoteDescription { get; set; }
        public int EntityId { get; set; }
        public Constants.EntityMasterId EntityMasterId { get; set; }
        public string DescriptionHtml { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
