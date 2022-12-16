namespace BarberShopEkz.Models
{
        public class Appointment
        {
            public int Id { get; set; }

            public string? Date { get; set; }
            public string? Time { get; set; }

            public int CustomerId { get; set; }
        }
    
}
