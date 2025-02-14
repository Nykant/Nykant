// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;
namespace NykantIS.Models
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Addresse")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string RedirectAction { get; set; }
        public string RedirectController { get; set; }
        public string BasePath { get; set; }
        public string ISPath { get; set; }
    }
}