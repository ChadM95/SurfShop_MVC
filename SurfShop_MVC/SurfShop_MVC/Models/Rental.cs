//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurfShop_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Rental
    {
        public int Rental_ID { get; set; }
        public string Customer_Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Rental_Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Return_Date { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
