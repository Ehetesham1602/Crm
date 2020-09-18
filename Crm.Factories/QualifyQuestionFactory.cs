using Crm.Entities;
using Crm.Models.QualifyQuestion;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class QualifyQuestionFactory
    {
        public static QualifyQuestion Create(QualifyQuestionAddModel model, string userId)
        {
            var data = new QualifyQuestion
            {
                QuestionCode = model.QuestionCode,
                QuestionName = model.QuestionName,
                FieldTypeId = model.FieldTypeId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(QualifyQuestionEditModel model, QualifyQuestion entity, string userId)
        {
            entity.QuestionCode = model.QuestionCode;
            entity.QuestionName = model.QuestionName;
            entity.FieldTypeId = model.FieldTypeId;
        }

        public static void CreateQualifyAnswer(List<QualifyQuestionAnswerAddModel> model,List<QualifyQuestionAnswers> entities)
        {
     
            foreach(var item in model){
                var data = new QualifyQuestionAnswers
                {
                    Id = Guid.NewGuid(),
                    EntityId = item.EntityId,
                    QuestionId = item.QuestionId,
                    Answer = item.Answer
                };
                entities.Add(data);
            }
           // return entities;
        }
    }
}
