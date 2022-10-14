using FluentValidation.Results;
using System.Text;

namespace Application.AllServices.ValidatorServices
{
    public class GetValidationErrorsService
    {
        public async Task<string> GetErrorsValidationAsync(ValidationResult resultValidation)
        {
            var errorsValidation = new StringBuilder("");
            foreach (var error in resultValidation.Errors)
            {
                errorsValidation.Append(error.ToString());
            }
            return errorsValidation.ToString();
        }
    }
}
