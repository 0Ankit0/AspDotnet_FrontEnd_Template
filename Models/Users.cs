
namespace Template.Models{
    public class Users
    {
     public long UserId { get; set; }
     public string UserName { get; set; }
     public string UserEmail { get; set; }
     public string Password { get; set; }
     public string Address { get; set; }
     public string Phone { get; set; }
     public string GUID { get; set; }
     public DateTime CreatedAt { get; set; }
     public DateTime UpdatedAt { get; set; }
     public string Role { get; set; }
     public bool Active { get; set; }
    }
}
