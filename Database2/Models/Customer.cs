using System;
using System.Collections.Generic;
using Database2.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Database2.Models;
public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? ContactTitle { get; set; }

    //[Required]
    public string? Address { get; set; }

    //[Required(ErrorMessage ="City Field is Required!!!")]
    public string? City { get; set; }

    public string? Region { get; set; }

    [CustomerZipCode]
    public string? PostalCode { get; set; }

    //[Validation()]
    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; } = new List<CustomerDemographic>();

   
}
