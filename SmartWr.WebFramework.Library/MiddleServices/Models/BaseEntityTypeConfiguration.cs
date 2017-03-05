using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Models.Auth
{
    public class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T>
          where T : BaseEntity
    {
        public BaseEntityTypeConfiguration()
            : base()
        {
            this.HasRequired(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedBy_Id)
                .WillCascadeOnDelete(false);

            this.HasOptional(r => r.ModifiedBy)
                .WithMany()
                .HasForeignKey(r => r.ModifiedBy_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
