using BarberShopEkz.Data;
using BarberShopEkz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShopEkz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberShopController : ControllerBase
    {
        [HttpGet("customers")]
        public ActionResult<List<Customer>> Customers()
        {
            DataContext dataContext = new DataContext();

            return Ok(dataContext.Customers.ToListAsync());
        }


        [HttpGet("customers/{id}")]
        public ActionResult<List<Customer>> GetCustomer(int id)
        {

            DataContext dataContext = new DataContext();

            List<Customer> customers = new List<Customer>();
            customers.Add(dataContext.Customers.ToList().Find(x => x.Id == id));


            if (customers.Count == 0)
            {
                return BadRequest($"No customers by id {id}");
            }

            return Ok(customers);
        }

        [HttpPost("customers")]
        public ActionResult<List<Customer>> AddCustomer(Customer customer)
        {
            DataContext dataContext = new DataContext();

            dataContext.Customers.Add(customer);
            dataContext.SaveChanges();

            return Ok(dataContext.Customers.ToList());
        }

        [HttpDelete("customers/{id}")]
        public ActionResult<List<Customer>> DeleteCustomer(int id)
        {
            DataContext dataContext = new DataContext();

            Customer customer = dataContext.Customers.ToList().Find(x => x.Id == id);

            if (customer == null)
            {
                return BadRequest($"No customer by id {id}");
            }

            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();

            return Ok(dataContext.Customers.ToList());
        }


        [HttpGet("appointments")]
        public ActionResult<List<Customer>> GetAppointments()
        {
            DataContext dataContext = new DataContext();

            return Ok(dataContext.Appointments.ToList());
        }

        [HttpGet("appointments/{id}")]
        public ActionResult<List<Customer>> GetAppointment(int id)
        {

            DataContext dataContext = new DataContext();

            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(dataContext.Appointments.ToList().Find(x => x.Id == id));


            if (appointments.Count == 0)
            {
                return BadRequest($"No appointmens by id {id}");
            }

            return Ok(appointments);
        }
        [HttpPost("appointments")]
        public ActionResult<List<Customer>> AddAppointment(Appointment appointment)
        {
            DataContext dataContext = new DataContext();

            dataContext.Appointments.Add(appointment);
            dataContext.SaveChanges();

            return Ok(dataContext.Appointments.ToList());
        }

        [HttpDelete("appointments/{id}")]
        public ActionResult<List<Customer>> DeleteAppointment(int id)
        {
            DataContext dataContext = new DataContext();

            Appointment appointment = dataContext.Appointments.ToList().Find(x => x.Id == id);

            if (appointment == null)
            {
                return BadRequest($"No appointments by id {id}");
            }

            dataContext.Appointments.Remove(appointment);
            dataContext.SaveChanges();

            return Ok(dataContext.Appointments.ToList());
        }
    }
}

