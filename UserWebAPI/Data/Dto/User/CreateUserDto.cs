using System.ComponentModel.DataAnnotations;

namespace UserWebAPI.Data.Dto.User;

public class CreateUserDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}
