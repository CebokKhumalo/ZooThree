using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Helper;

namespace ZooThree.Service.Helper.Binder
{
    public class StringToEnumBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            var value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var enumType = bindingContext.ModelType; // this should be an enum type
            try
            {
                // Use the Description value of the enum as its string representation
                var enumValue = Enum.GetValues(enumType)
                    .Cast<Enum>()
                    .FirstOrDefault(e => string.Equals(e.GetEnumDescription(), value, StringComparison.OrdinalIgnoreCase));

                if (enumValue == null)
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, $"Invalid value for {enumType.Name}");
                    return Task.CompletedTask;
                }

                bindingContext.Result = ModelBindingResult.Success(enumValue);
            }
            catch (Exception)
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, $"Invalid value for {enumType.Name}");
            }

            return Task.CompletedTask;
        }
    }

}
