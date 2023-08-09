using System.ComponentModel.DataAnnotations;

namespace ToolRoomRequests.Pages
{
    public class ValidationComponents
    {
        public string Description { get; set; }

        [Required]
        public string Requirements { get; set; }

        [Required]
        public string ChargeNumber { get; set; }

        [Required]
        public string Employee { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Required]
        public string Priority { get; set; }

        //[Range(1, 100000,
        //    ErrorMessage = "Accommodation invalid (1-100000).")]
        //public int MaximumAccommodation { get; set; }

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
