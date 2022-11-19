using System.ComponentModel.DataAnnotations;

namespace Model.Entities.Models;

public class LoginModel {
    public LoginModel() {
    }

    public LoginModel(string username, string email, string password) {
        Username = username;
        Email = email;
        Password = password;
    }

    [Required] public string Username { get; set; } = null!;
    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}