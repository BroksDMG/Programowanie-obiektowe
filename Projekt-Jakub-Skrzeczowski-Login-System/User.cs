using System.ComponentModel.DataAnnotations;

namespace Projekt_Jakub_Skrzeczowski_Login_System
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
    }
}