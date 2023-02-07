namespace backend_invoice_project.Controllers.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public string? Status { get; set; }
        public int Amount { get; set; }
    }
}
