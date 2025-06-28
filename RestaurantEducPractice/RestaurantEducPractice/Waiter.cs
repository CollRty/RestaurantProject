using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace RestaurantEducPractice;

[Table("waiters")]
public class Waiter : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }
}