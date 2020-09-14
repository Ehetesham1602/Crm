using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface ISeedManager
    {
        Task InitializeAsync();
    }
}
