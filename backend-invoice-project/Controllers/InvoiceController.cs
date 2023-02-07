using Microsoft.AspNetCore.Mvc;
using backend_invoice_project.Data;
using backend_invoice_project.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_invoice_project.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceApiDbContext? dbInvoice;

        public InvoiceController(InvoiceApiDbContext dbInvoice)
        {
            this.dbInvoice = dbInvoice;
        }
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            return Ok(await dbInvoice.Invoices.ToListAsync());
        }

        [HttpPost]      
        public async Task<IActionResult> AddInvoice(Invoice newInvoice)
        {
            var invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                date = newInvoice.date,
                Amount = newInvoice.Amount,
                Status = newInvoice.Status
            };
            await dbInvoice.Invoices.AddAsync(invoice);
            await dbInvoice.SaveChangesAsync();
            
            return Ok(newInvoice);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UppdateInvoice([FromRoute] Guid id , Invoice updateInvoice)
        {
           var invoice = await dbInvoice.Invoices.FindAsync(id);

           if (invoice != null)
            {
                invoice.Amount = updateInvoice.Amount;
                invoice.Status = updateInvoice.Status;
                invoice.date = updateInvoice.date;

                await dbInvoice.SaveChangesAsync();
                return Ok(invoice);
            }
           return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] Guid id)
        {

            var invoice = await dbInvoice.Invoices.FindAsync(id);
            if (invoice != null)
            {
                dbInvoice.Remove(invoice);
                await dbInvoice.SaveChangesAsync();
                return Ok(invoice);
            }
            return NotFound();
        }
    }
}
