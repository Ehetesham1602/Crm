using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class ActivityNotesConfiguration : IEntityTypeConfiguration<ActivityNotes>
    {
        public void Configure(EntityTypeBuilder<ActivityNotes> builder)
        {
            builder.ToTable("ActivityNotes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NoteDescription).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityMasterId).IsRequired();
            builder.Property(x => x.DescriptionHtml).IsRequired().HasMaxLength(40);
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
        }
    }
}