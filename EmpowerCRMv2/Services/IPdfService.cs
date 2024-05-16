using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IPdfService
    {
        string GenerateInvoicePdf(Opportunity opp);
    }
}
