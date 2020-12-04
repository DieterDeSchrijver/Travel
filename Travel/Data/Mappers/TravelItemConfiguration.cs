using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data.Mappers
{
    public class TravelItemConfiguration : IEntityTypeConfiguration<TravelItem>
    {
        public void Configure(EntityTypeBuilder<TravelItem> builder)
        {
            builder.ToTable("TravelItem");
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);
        }
    }
}