namespace E_Store.Classes
{
    using System.ComponentModel.DataAnnotations;
    
    public class RequiredIfFalseAttribute : RequiredIfAttribute
    {
        protected override string CustomErrorMessage { get; set; } =
            "The {0} field is required if the {1} field isn't confirmed";
        
        public RequiredIfFalseAttribute(string valueName) : base(valueName) {}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = GetField<bool>(validationContext);

            return fieldValue == true || !string.IsNullOrEmpty(value?.ToString())
                ? ValidationResult.Success
                : BuildErrorMessage(validationContext);
        }
    }
}