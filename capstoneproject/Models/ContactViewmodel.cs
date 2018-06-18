using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace capstoneproject.Models
{
   
        public class ContactViewModel
        {
            [Required]
            [Display(Name = "Your Name")]
            public string FromName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Your Email")]
            public string FromEmail { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Message Text")]
            public string Body { get; set; }
        }


    }
