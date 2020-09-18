using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.QualifyQuestion
{
    public class QualifyQuestionEditModel
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionCode { get; set; }
        public Constants.FieldTypeId FieldTypeId { get; set; }
    }
}
