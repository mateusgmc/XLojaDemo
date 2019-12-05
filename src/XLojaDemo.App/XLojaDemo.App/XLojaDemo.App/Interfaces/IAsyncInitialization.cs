using System.Threading.Tasks;

namespace XLojaDemo.App.Interfaces
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}
