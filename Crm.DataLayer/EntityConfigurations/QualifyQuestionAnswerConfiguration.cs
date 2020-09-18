using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class QualifyQuestionAnswerConfiguration : IEntityTypeConfiguration<QualifyQuestionAnswers>
    {
        public void Configure(EntityTypeBuilder<QualifyQuestionAnswers> builder)
        {
            builder.ToTable("QualifyQuestionAnswer");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.Answer).IsRequired(false);
        }
    }
}

