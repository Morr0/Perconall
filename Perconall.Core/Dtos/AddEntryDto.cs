using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Perconall.Core.Dtos
{
    public class AddEntryDto : IValidatableObject
    {
        public string Notes { get; set; }
        [Required, Range(20, 1000)]
        public float Kg { get; set; }
        
        public bool OnWakeup { get; set; }
        public bool OnSleep { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            CheckTimeOfDayFlags(ref errors);

            return errors;
        }

        private void CheckTimeOfDayFlags(ref List<ValidationResult> errors)
        {
            if (OnWakeup && OnSleep)
            {
                errors.Add(new ValidationResult("It should either be on wakeup or on sleep that is true not both"));
            }
        }
    }
}