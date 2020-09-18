using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class QualifyQuestion
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionCode { get; set; }
        public Constants.FieldTypeId FieldTypeId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
