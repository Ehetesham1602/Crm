using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.QualifyQuestion
{
    public class QualifyQuestionAnswerAddModel
    {
        public int EntityId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
