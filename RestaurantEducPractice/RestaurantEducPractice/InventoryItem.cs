using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace RestaurantEducPractice;

[Table("inventory")]
public class InventoryItem : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("dish_name")]
    public string DishName { get; set; }

    [Column("portions_available")]
    public int PortionsAvailable { get; set; }
}