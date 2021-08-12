namespace E_Store.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public abstract class RequiredIfAttribute : ValidationAttribute
    {
        protected abstract string CustomErrorMessage { get; set; }

        protected string valueToCompare;

        public RequiredIfAttribute(string valueToCompare)
        {
            this.valueToCompare = valueToCompare;
        }

        protected T GetField<T>(ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectInstance.GetType();
            var fieldToCompare = objectType.GetProperty(this.valueToCompare);

            if (fieldToCompare == null)
            {
                throw new MissingFieldException(
                    $"The {valueToCompare} field cannot be accessed on the {objectType.FullName} object. Please, contact the administrator.");
            }

            return (T) fieldToCompare.GetValue(validationContext.ObjectInstance);
        }

        protected virtual ValidationResult BuildErrorMessage(ValidationContext validationContext)
        {
            var displayName = validationContext.DisplayName;

            return new ValidationResult(ErrorMessage ??
                                        string.Format(CustomErrorMessage, displayName, this.valueToCompare));
        }
    }
}