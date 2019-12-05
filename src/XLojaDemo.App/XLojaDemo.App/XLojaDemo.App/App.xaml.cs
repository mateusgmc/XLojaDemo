using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLojaDemo.App.Interfaces;
using XLojaDemo.App.Services;
using XLojaDemo.App.ViewModels;
using XLojaDemo.App.Views;

namespace XLojaDemo.App
{
    public partial class App : PrismApplication
    {
        public App() :
            this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {
        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver) :
            base(initializer, setFormsDependencyResolver)
        {
        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterForNavigation<CadastroProdutoPage, CadastroProdutoViewModel>();
            containerRegistry.RegisterForNavigation<ProdutosPage, ProdutosViewModel>();
            containerRegistry.RegisterForNavigation<EditarProdutoPage, EditarProdutoViewModel>();

            containerRegistry.RegisterSingleton<ILojaApiService, LojaApiService>();
        }
    }
}
