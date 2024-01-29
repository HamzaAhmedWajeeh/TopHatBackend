using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Top_Hat_App.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    [NotMapped]
    public string? AccessToken { get; set; }
}
