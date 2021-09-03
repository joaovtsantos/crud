using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Exceptions
{
    public class ApiDomainException : Exception
    {
        public ApiDomainException(IList<ValidationFailure> errors)
        {
            JArray messages = new JArray();

            foreach (var item in errors)
            {
                JObject error = new JObject();

                error.Add(item.PropertyName, item.ErrorMessage);

                messages.Add(error);
            }

            this.Errors = messages;
        }

        public ApiDomainException(string errorMessage, string propertyName = "")
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Errors of model
        /// </summary>
        public JArray Errors { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; }
    }
}
