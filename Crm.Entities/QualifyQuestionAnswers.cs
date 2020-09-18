using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class QualifyQuestionAnswers
    {
        public Guid Id { get; set; }
        public int EntityId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
