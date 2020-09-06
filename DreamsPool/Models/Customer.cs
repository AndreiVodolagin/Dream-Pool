using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public class Customer
    {
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is not specified")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid name")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "No phone specified for callback")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "Invalid phone number. Example 639546362")]
        public string Phone { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Language Language { get; set; }
    }

    public enum Language
    {
        En,
        Es,
        Ru
    }
}
