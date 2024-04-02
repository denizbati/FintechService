using System.Threading.Tasks;

namespace FintechService.Domain
{
    public interface IDbContextHandler
    {
        Task SaveChangesAsync();
    }
}