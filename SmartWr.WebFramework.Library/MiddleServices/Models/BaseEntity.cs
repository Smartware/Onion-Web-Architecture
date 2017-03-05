using SmartWr.WebFramework.Library.Infrastructure.Identity;
using SmartWr.WebFramework.Library.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedOnUtc = DateTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; set; }
        public Int32 CreatedBy_Id { get; set; }
        [ForeignKey("CreatedBy_Id")]
        public virtual ApplicationIdentityUser CreatedBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public Nullable<Int32> ModifiedBy_Id { get; set; }
        [ForeignKey("ModifiedBy_Id")]
        public virtual ApplicationIdentityUser ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOnUtc { get; set; }
        public Boolean IsDeleted { get; set; }


        //
        // ValidationErrors
        //
        private List<ValidationError> _validationErrors;
        [NotMapped]
        public List<ValidationError> ValidationErrors
        {
            get
            {
                if (_validationErrors == null)
                { _validationErrors = new List<ValidationError>(); }
                return _validationErrors;
            }
            set { _validationErrors = value; }
        }

        [NotMapped]
        public Boolean HasErrors
        {
            get
            {
                return ValidationErrors.Count > 0;
            }
        }


        //
        // Validate
        // This method should be contained in the validation
        // of each concrete business object class.  The validation
        // region should contain contain all of the validation
        // functions for the class and an implementation of
        // Validate that calls all of them. Each validation
        // function is responsible for adding it's own ValidationError
        // to the ValidationErrors list if the method fails.
        //
        public abstract List<ValidationError> Validate();
    }
}
