using System.ComponentModel.DataAnnotations;

public class gateway
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Serial number is required.")]
    [StringLength(50, ErrorMessage = "Serial number must not exceed 50 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Serial number must contain only alphanumeric characters.")]
    public string SerialNumber { get; set; }

    [Required(ErrorMessage = "IP address is required.")]
    [RegularExpression(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$", ErrorMessage = "Invalid IPv4 address format.")]
    public string IPAddress { get; set; }
    public string IPv4Address { get; internal set; }
    public string Name { get; internal set; }
}
