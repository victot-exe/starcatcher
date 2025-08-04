using System.ComponentModel.DataAnnotations.Schema;
using Starcatcher.DTOs;

namespace Starcatcher.Entities
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        [InverseProperty("User")]
        public List<Cota> Cotas { get; set; } = new();
        public User(UserDTOUpdate dto)
        {
            Username = dto.Username;
            Password = dto.Password;
        }
    }
}