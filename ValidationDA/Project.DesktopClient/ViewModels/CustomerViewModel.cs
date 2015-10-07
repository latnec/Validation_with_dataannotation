// -----------------------------------------------------------------------
// <copyright file="CustomerViewModel.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Project.DesktopClient.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerViewModel : ViewModel
    {
        private string customerName;

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; NotifyPropertyChanged("CustomerName"); }
        }


        private int age;

        [Required]
        [Range(0, 100)]
        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged("Age"); }
        }




        protected override string OnValidate(string propertyName)
        {
            //if ((CustomerName!=null)&&(!CustomerName.Contains(" ")))
            //{
            //    return "Customer name must have a first and last name";
            //}

            return base.OnValidate(propertyName);
        }
    }
}
