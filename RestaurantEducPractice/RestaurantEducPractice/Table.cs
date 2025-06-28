using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RestaurantEducPractice;

[Table("tables")]
public class Table : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("table_number")]
    public string TableNumber { get; set; }

    [Column("seats")]
    public int Seats { get; set; }

    [Column("status")]
    public string Status { get; set; }
}