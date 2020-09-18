using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Website).IsRequired();
            builder.Property(x => x.Mobile).IsRequired();
            builder.Property(x => x.LeadSourceId).IsRequired();
            builder.Property(x => x.LeadStatusId).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.HasOne(x => x.LeadSource).WithMany().HasForeignKey(x => x.LeadSourceId);
            builder.HasOne(x => x.LeadStatus).WithMany().HasForeignKey(x => x.LeadStatusId);
        }
    }
}

