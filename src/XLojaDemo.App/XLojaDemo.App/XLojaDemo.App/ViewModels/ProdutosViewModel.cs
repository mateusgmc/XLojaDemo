using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XLojaDemo.App.Interfaces;
using XLojaDemo.App.Models;

namespace XLojaDemo.App.ViewModels
{
    public class ProdutosViewModel : ViewModelBase, IAsyncInitialization
    {
        private readonly ILojaApiService _lojaApiService;

        public Task Initialization { get; }

        public ProdutosViewModel(INavigationService navigationService, ILojaApiService lojaApiService) :
            base(navigationService)
        {
            _lojaApiService = lojaApiService;

            EditarProdutoCommand = new DelegateCommand<Produto>(EditarProdutoExecute);
            NovoProdutoCommand = new DelegateCommand(NovoProdutoExecute);
            Produtos = new ObservableCollection<Produto>();

            Initialization = InitializationAsync();
        }

        public DelegateCommand<Produto> EditarProdutoCommand { get; }

        public DelegateCommand NovoProdutoCommand { get; }

        public ObservableCollection<Produto> Produtos { get; }

        private async Task InitializationAsync()
        {
            var produtos = await _lojaApiService.Api.GetProdutosAsync();
            foreach(var produto in produtos)
            {
                Produtos.Add(produto);
            }
        }

        private void EditarProdutoExecute(Produto obj)
        {
            var navigationParams = new NavigationParameters
            {
                { "model", obj }
            };
            NavigationService.NavigateAsync("EditarProdutoPage", navigationParams);
        }

        private void NovoProdutoExecute()
        {
            NavigationService.NavigateAsync("CadastroProdutoPage");
        }
    }
}
