using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace RestaurantEducPractice;

[Table("orders")]
public class Order : BaseModel
{
    [PrimaryKey("id", false)]
    public string Id { get; set; }

    [Column("client_name")]
    public string ClientName { get; set; }

    [Column("waiter_name")]
    public string WaiterName { get; set; }

    [Column("table_number")]
    public string TableNumber { get; set; }

    [Column("created_at")]
    public string CreatedAt { get; set; }

    [Column("status")]
    public string Status { get; set; }

    [Column("reservation_id")]
    public string ReservationId { get; set; }
}