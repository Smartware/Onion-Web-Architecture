using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.Validation
{
    public class ValidationError : IComparable
    {
        #region "Properties"
        // FieldName
        // FieldName is required.  It tells us which entity field
        // value triggered the validation error.
        public string FieldName { get; set; }

        // UIFieldName
        // The UI label will often be different than the field name
        // on the business object.  This field allows the UI to set
        // a name that is consistent with the UI label.  If set, this
        // is the name that will be used in ErrorMessage.     
        public string UIFieldName { get; set; }

        // ErrorMessage
        // Contains the <FieldName> marker instead of field names. 
        // This allows us to replace with a UI-friendly name, the
        // UIFieldName.  If UIFieldName isn't set use FieldName.
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;

            }
            set
            {
                _errorMessage = value;
            }
        }

        // SortOrder
        public int SortOrder { get; set; }
        #endregion

        //
        // Constructor
        //
        public ValidationError(string fieldName, string errorMessage)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
            //UIFieldName = CommonBase.String_NullValue;
            SortOrder = int.MaxValue;
        }

        //
        // CompareTo
        // Implementation of IComparable.
        //
        int IComparable.CompareTo(object obj)
        {
            ValidationError error2 = (ValidationError)obj;
            return FieldName.CompareTo(error2.FieldName);
        }
    }
}
