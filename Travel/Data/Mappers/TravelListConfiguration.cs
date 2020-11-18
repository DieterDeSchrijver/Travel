using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data.Mappers
{
    public class TravelListConfiguration : IEntityTypeConfiguration<TravelList>
    {
        public void Configure(EntityTypeBuilder<TravelList> builder)
        {
            builder.ToTable("TravelLists");
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Location);

            builder.HasMany(t => t.Items);
        }
    }
}
