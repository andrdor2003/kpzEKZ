using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BarberShopEkz.Models;

namespace BarberShopEkz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
    }
}
