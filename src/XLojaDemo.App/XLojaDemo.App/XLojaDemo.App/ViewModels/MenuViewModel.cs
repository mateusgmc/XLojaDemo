using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using XLojaDemo.App.Interfaces;
using XLojaDemo.App.Models;
using XLojaDemo.App.Services;

namespace XLojaDemo.App.ViewModels
{
    public class MenuViewModel : ViewModelBase, IAsyncInitialization
    {
        private readonly ILojaApiService _lojaApiService;

        public Task Initialization { get; }

        public MenuViewModel(INavigationService navigationService, ILojaApiService lojaApiService) :
            base(navigationService)
        {
            _lojaApiService = lojaApiService;

            OpenOptionCommand = new DelegateCommand<MainMenuItem>(OpenOptionExecute);
            MenuItens = new ObservableCollection<MainMenuItem>(MenuService.GetMainMenuItens());
            Usuario = new Usuario();

            Initialization = InitializationAsync();
        }

        public DelegateCommand<MainMenuItem> OpenOptionCommand { get; }

        public ObservableCollection<MainMenuItem> MenuItens { get; }

        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private async Task InitializationAsync()
        {
            var usuarios = await _lojaApiService.Api.GetUsuariosAsync();
            Usuario = usuarios.FirstOrDefault();
        }

        private void OpenOptionExecute(MainMenuItem obj)
        {
            switch (obj.MainMenuItemType)
            {
                case MainMenuItemType.CadastroProduto:
                    NavigationService.NavigateAsync("MainPage/NavigationPage/CadastroProdutoPage");
                    break;
                case MainMenuItemType.Produtos:
                    NavigationService.NavigateAsync("MainPage/NavigationPage/ProdutosPage");
                    break;
            }
        }
    }
}
