using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace RestaurantEducPractice;

[Table("statistics")]
public class Statistics : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("dish_name")]
    public string DishName { get; set; }

    [Column("category_name")]
    public string CategoryName { get; set; }

    [Column("sold_count")]
    public int OrderedCount { get; set; }
}