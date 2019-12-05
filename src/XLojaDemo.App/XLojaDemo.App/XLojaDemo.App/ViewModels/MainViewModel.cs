using Prism.Navigation;
using XLojaDemo.App.Interfaces;

namespace XLojaDemo.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService) :
            base(navigationService)
        {
        }
    }
}
