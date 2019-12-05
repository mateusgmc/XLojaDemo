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

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
            await _lojaApiService.Api.DeleteProdutoAsync(Id);
            await NavigationService.NavigateAsync("ProdutosPage");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var produto = parameters["model"] as Produto;
            Id = produto.Id;
            Descricao = produto.Nome;
            Preco = produto.Preco;
        }

        private async void SalvarProdutoExecute()
        {
            await _lojaApiService.Api.AddOrUpdateProdutoAsync(new Produto
            {
                Nome = Descricao,
                Preco = Preco
            });
            await NavigationService.NavigateAsync("ProdutosPage");
        }
    }
}
