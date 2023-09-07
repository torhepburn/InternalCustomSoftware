using System;
using System.ComponentModel.DataAnnotations;

namespace OpticsTracker.Data
{
    public class FormModel
    {
        [Required]
        public string location { get; set; }

        [Required]
        public string part { get; set; }
    }
}
