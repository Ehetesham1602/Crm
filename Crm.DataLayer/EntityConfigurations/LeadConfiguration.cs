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
            builder.Property(x => x.LeadSourceId).IsRequired(false);
            builder.Property(x => x.LeadStatusId).IsRequired(false);
            builder.Property(x => x.AddressId).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.HasOne(x => x.LeadSource).WithMany().HasForeignKey(x => x.LeadSourceId);
            builder.HasOne(x => x.LeadStatus).WithMany().HasForeignKey(x => x.LeadStatusId);
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.UserId).IsRequired(false);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.Property(x => x.CallStatus).IsRequired();
        }
    }
}

