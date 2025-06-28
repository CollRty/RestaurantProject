using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace RestaurantEducPractice;

[Table("order_items")]
public class OrderItem : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("dish_name")]
    public string DishName { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price_at_order")]
    public decimal PriceAtOrder { get; set; }

    [Column("order_id")]
    public string OrderId { get; set; }
}