using System;
using Blazorise;

namespace NutritionManager.Web.Wasm.Nutrient.Services
{
    public class NutrientValidationService
    {
        private const int TitleMaxLength = 32;

        public void ValidateTitle(ValidatorEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }

            var value = eventArgs.Value?.ToString() ?? string.Empty;

            if (value.Length > TitleMaxLength)
            {
                eventArgs.Status = ValidationStatus.Error;
            }
        }
    }
}