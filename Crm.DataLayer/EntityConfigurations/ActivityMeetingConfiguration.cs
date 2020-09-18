using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class ActivityMeetingConfiguration : IEntityTypeConfiguration<ActivityMeeting>
    {
        public void Configure(EntityTypeBuilder<ActivityMeeting> builder)
        {
            builder.ToTable("ActivityMeeting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.MeetingSubject).IsRequired();
            builder.Property(x => x.MeetingDescription).IsRequired();
            builder.Property(x => x.MeetingDate).IsRequired();
            builder.Property(x => x.MeetingTime).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityMasterId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DescriptionHtml).IsRequired().HasMaxLength(40);
        }
    }
}


