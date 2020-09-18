using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class ActivityCallConfiguration : IEntityTypeConfiguration<ActivityCall>
    {
        public void Configure(EntityTypeBuilder<ActivityCall> builder)
        {
            builder.ToTable("ActivityCall");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CallSubject).IsRequired();
            builder.Property(x => x.CallDescription).IsRequired();
            builder.Property(x => x.CallPurpose).IsRequired();
            builder.Property(x => x.CallDate).IsRequired();
            builder.Property(x => x.CallTime).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityMasterId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DescriptionHtml).IsRequired().HasMaxLength(40);
        }
    }
}


