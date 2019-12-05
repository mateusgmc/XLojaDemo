using Refit;
using XLojaDemo.App.Helpers;
using XLojaDemo.App.Interfaces;

namespace XLojaDemo.App.Services
{
    public class LojaApiService : ILojaApiService
    {
        public LojaApiService()
        {
            Api = RestService.For<ILojaRestService>(Settings.Current.HostUri);
        }

        public ILojaRestService Api { get; }
    }
}
