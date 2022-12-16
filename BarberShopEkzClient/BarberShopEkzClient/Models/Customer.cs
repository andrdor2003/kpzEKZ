using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopEkzClient.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? WorkType { get; set; }

        public string? BarberSurname { get; set; }
    }
}
