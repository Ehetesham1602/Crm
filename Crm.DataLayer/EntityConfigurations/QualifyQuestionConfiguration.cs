using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class QualifyQuestionConfiguration : IEntityTypeConfiguration<QualifyQuestion>
    {
        public void Configure(EntityTypeBuilder<QualifyQuestion> builder)
        {
            builder.ToTable("QualifyQuestion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.QuestionName).IsRequired();
            builder.Property(x => x.FieldTypeId).IsRequired();
            builder.Property(x => x.QuestionCode).IsRequired(false);
            builder.Property(x => x.Options).IsRequired(false);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
        }
    }
}
