using Prism.Commands;
using Prism.Navigation;
using XLojaDemo.App.Interfaces;
using XLojaDemo.App.Models;

namespace XLojaDemo.App.ViewModels
{
    public class EditarProdutoViewModel : ViewModelBase
    {
        private readonly ILojaApiService _lojaApiService;

        public EditarProdutoViewModel(INavigationService navigationService, ILojaApiService lojaApiService) :
            base(navigationService)
        {
            _lojaApiService = lojaApiService;

            SalvarProdutoCommand = new DelegateCommand(SalvarProdutoExecute);
            DeletarProdutoCommand = new DelegateCommand(DeletarProdutoExecute);
        }

        public DelegateCommand SalvarProdutoCommand { get; }

        public DelegateCommand DeletarProdutoCommand { get; }

        private Produto _produto;
        public Produto Produto
        {
            get { return _produto; }
            set { SetProperty(ref _produto, value); }
        }

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

        private async void DeletarProdutoExecute()
        {
            await _lojaApiService.Api.DeleteProdutoAsync(Produto.Id);
            await NavigationService.NavigateAsync("ProdutosPage");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Produto = parameters["model"] as Produto;
            Descricao = Produto.Nome;
            Preco = Produto.Preco;
        }

        private async void SalvarProdutoExecute()
        {
            Produto.Nome = Descricao;
            Produto.Preco = Preco;
            await _lojaApiService.Api.AddOrUpdateProdutoAsync(Produto);
            await NavigationService.NavigateAsync("ProdutosPage");
        }
    }
}
