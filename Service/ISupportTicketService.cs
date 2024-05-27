using soporte_back_dotnet.Model;

namespace soporte_back_dotnet.Service
{
    public interface ISupportTicketService
    {
        Task<List<Supportticket>> GetAllTicketsAsync();
        Task<Supportticket> GetTicketByIdAsync(int id);
        Task<Supportticket> CreateTicketAsync(Supportticket ticket);
        Task<Supportticket> UpdateTicketAsync(Supportticket ticket);
        Task DeleteTicketAsync(int id);
    }
}
