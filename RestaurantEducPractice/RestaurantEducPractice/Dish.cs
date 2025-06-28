using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RestaurantEducPractice;

[Table("dishes")]
public class Dish : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("category_name")]
    public string CategoryName { get; set; }
}