namespace E_Store.Classes
{
    using System.ComponentModel.DataAnnotations;
    
    public class RequiredIfEmptyAttribute : RequiredIfAttribute
    {
        protected override string CustomErrorMessage { get; set; } = "The {0} field is required if the {1} field isn't specified";
        
        public RequiredIfEmptyAttribute(string valueName) : base(valueName){}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = GetField<string>(validationContext);
            var stringValue = (string) value;

            return string.IsNullOrEmpty(fieldValue) && string.IsNullOrEmpty(stringValue)
                ? BuildErrorMessage(validationContext)
                : ValidationResult.Success;
        }
    }
}