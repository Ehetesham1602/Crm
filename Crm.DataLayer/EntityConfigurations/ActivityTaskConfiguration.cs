using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class ActivityTaskConfiguration : IEntityTypeConfiguration<ActivityTask>
    {
        public void Configure(EntityTypeBuilder<ActivityTask> builder)
        {
            builder.ToTable("ActivityTask");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.TaskSubject).IsRequired();
            builder.Property(x => x.TaskDescription).IsRequired();
            builder.Property(x => x.TaskPurpose).IsRequired();
            builder.Property(x => x.TaskDate).IsRequired();
            builder.Property(x => x.TaskTime).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityMasterId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DescriptionHtml).IsRequired().HasMaxLength(40);
        }
    }
}
