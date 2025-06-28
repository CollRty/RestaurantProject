using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RestaurantEducPractice;

[Table("clients")]
public class Client : BaseModel
{
    [PrimaryKey("id", false)]
    [Column("id")]
    public string Id { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("phone")]
    public string Phone { get; set; }

    [Column("role")]
    public string Role { get; set; }
}