using System;
using System.Collections.Generic;

namespace CI_Platform.entites.Models;

public partial class PasswordReset
{
    public string Email { get; set; } = null!;

    public string Token { get; set; } = null!;

    public byte[] CreatedAt { get; set; } = null!;
}
