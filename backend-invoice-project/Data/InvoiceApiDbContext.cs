using backend_invoice_project.Controllers.Models;
using Microsoft.EntityFrameworkCore;
namespace backend_invoice_project.Data
{
    public class InvoiceApiDbContext: DbContext
    {
        public InvoiceApiDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet <Invoice> Invoices { get; set; }
    }
}
