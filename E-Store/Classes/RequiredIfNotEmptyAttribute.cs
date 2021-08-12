namespace E_Store.Classes
{
    using System.ComponentModel.DataAnnotations;
    
    public class RequiredIfNotEmptyAttribute : RequiredIfAttribute
    {
        protected override string CustomErrorMessage { get; set; } = 
            "If the {1} field is specified, the {0} field is required as well";
        
        public RequiredIfNotEmptyAttribute(string valueName) : base(valueName){}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return string.IsNullOrEmpty((string) value) && !string.IsNullOrEmpty(GetField<string>(validationContext))
                ? BuildErrorMessage(validationContext)
                : ValidationResult.Success;
        }
    }
}