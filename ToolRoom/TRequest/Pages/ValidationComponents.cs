using System.ComponentModel.DataAnnotations;

namespace TRequest.Pages
{
    public class ValidationComponents
    {
        [Required]
        public string RequestType { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string CostCenter { get; set; }

        [Required]
        public string Employee { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        [Range(1, 100000,
            ErrorMessage = "Value invalid (1-100000).")]
        public int TimeSavings { get; set; }

        [Required]
        [Range(1, 100000,
            ErrorMessage = "Value invalid (1-100000).")]
        public int CostSavings { get; set; }

        [Required]
        [Range(1, 100000,
            ErrorMessage = "Value invalid (1-100000).")]
        public int RevenueSavings { get; set; }

        //[Required]
        //[Range(typeof(bool), "true", "true",
        //    ErrorMessage = "This form disallows unapproved ships.")]
        //public bool IsValidatedDesign { get; set; }

        [Required]
        [ValidYear(ErrorMessage = "Must select valid date.")]
        public DateTime RequestedDate { get; set; }

    }

    public class ValidYear : ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.UtcNow.AddHours(-24);
        private readonly DateTime _maxValue = DateTime.UtcNow.AddYears(60);

        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return val >= _minValue && val <= _maxValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage);
            //return string.Format(ErrorMessa1ge, _minValue, _maxValue);
        }

    }
}
