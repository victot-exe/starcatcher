using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Cota> Cotas { get; set; } = [];
    }
}