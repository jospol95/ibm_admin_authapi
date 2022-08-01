namespace IBMAuthApi.Api.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
    }
}
