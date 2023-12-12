using GatewayManagementRESTAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace GatewayManagementRESTAPI.Validator
{
    public class Gateway
    {
        public int Id { get; set; }

        // Other properties...

        [MaxPeripheralDeviceCount(ErrorMessage = "A gateway can have a maximum of 10 peripheral devices.")]
        public ICollection<PeripheralDevice> PeripheralDevices { get; set; }
    }

    public class MaxPeripheralDeviceCountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var peripheralDevices = value as ICollection<PeripheralDevice>;

            if (peripheralDevices != null && peripheralDevices.Count > 10)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}