    using Supabase.Postgrest.Models;
    using Supabase.Postgrest.Attributes;

    namespace RestaurantEducPractice;

    [Table("reservations")]
    public class Reservation : BaseModel
    {
        [PrimaryKey("id", false)]
        public string Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("table_number")]
        public string TableNumber { get; set; }

        [Column("reservation_date")]
        public string ReservationDate { get; set; }

        [Column("reservation_time")]
        public string ReservationTime { get; set; }

        [Column("guests_count")]
        public int GuestsCount { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("waiter_name")]
        public string WaiterName { get; set; }
    }