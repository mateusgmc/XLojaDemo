using Prism.Commands;
using Prism.Navigation;
using XLojaDemo.App.Interfaces;
using XLojaDemo.App.Models;

namespace XLojaDemo.App.ViewModels
{
    public class CadastroProdutoViewModel : ViewModelBase
    {
        private readonly ILojaApiService _lojaApiService;
        
        public CadastroProdutoViewModel(INavigationService navigationService, ILojaApiService lojaApiService) :
            base(navigationService)
        {
            _lojaApiService = lojaApiService;

            SalvarProdutoCommand = new DelegateCommand(SalvarProdutoExecute);
            ListarProdutosCommand = new DelegateCommand(ListarProdutosExecute);
        }

        public DelegateCommand SalvarProdutoCommand { get; }

        public DelegateCommand ListarProdutosCommand { get; }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        private double _preco;
        public double Preco
        {
            get { return _preco; }
            set { SetProperty(ref _preco, value); }
        }

        private void ListarProdutosExecute()
        {
            NavigationService.NavigateAsync("ProdutosPage");
        }

        private async void SalvarProdutoExecute()
        {
            await _lojaApiService.Api.AddProdutoAsync(new Produto
            {
                Nome = Descricao,
                Preco = Preco
            });
            await NavigationService.NavigateAsync("ProdutosPage");
        }
    }
}
