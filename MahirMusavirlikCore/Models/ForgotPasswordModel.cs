﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class ForgotPasswordModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
