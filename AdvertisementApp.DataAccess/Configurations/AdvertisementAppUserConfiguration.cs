using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x => new
            {
                x.AdvertisementID,
                x.AppUserID
            }).IsUnique();
            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementID);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AppUserID);
            builder.HasOne(x => x.AdvertisementAppUserStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementUserStatusID);
            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.MilitaryStatusID);
        }
    }
}
