namespace CI_Platform.Models
{
    public class RegisterModelcs
    {
        public string? FirstName { get; set; } = null;

        public string? LastName { get; set; } = null; 

        public string Email { get; set; } = null!;


        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;

        public int PhoneNumber { get; set; }
        public string? ConformPassword { get; internal set; }
    }
}
