namespace Project.DesktopClient.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Project.Windows;
    using System.Collections.ObjectModel;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotSupportedException(); }
        }

        public string this[string columnName]
        {
            get { return OnValidate(columnName); }
        }

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this, null, null)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid)
            {
                return null;
            }
            else
            {
                string errorMessage = String.Empty;

                foreach (ValidationResult vr in results)
                {
                    var foundP = vr.MemberNames.FirstOrDefault(v => v == propertyName);
                    if (foundP != null)
                    {
                        errorMessage = vr.ErrorMessage;
                        break;
                    }
                }
                return errorMessage;
            }

        }
    }
}
