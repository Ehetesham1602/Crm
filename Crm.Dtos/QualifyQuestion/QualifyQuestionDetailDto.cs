using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Dtos.QualifyQuestion
{
    public class QualifyQuestionDetailDto
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionCode { get; set; }
        public Constants.FieldTypeId FieldTypeId { get; set; }
        public string Options { get; set; }
    }
}
