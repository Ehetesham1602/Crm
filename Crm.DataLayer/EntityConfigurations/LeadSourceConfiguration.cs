using Crm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.DataLayer.EntityConfigurations
{
    public class LeadSourceConfiguration : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> builder)
        {
            builder.ToTable("LeadSource");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Status).IsRequired();
        }
    }
}
