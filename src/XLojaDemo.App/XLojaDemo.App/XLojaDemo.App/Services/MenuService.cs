using System.Collections.Generic;
using XLojaDemo.App.Models;

namespace XLojaDemo.App.Services
{
    public static class MenuService
    {
        public static List<MainMenuItem> GetMainMenuItens()
        {
            return new List<MainMenuItem>
            {
                new MainMenuItem { Title = "Cadastrar Produto", Icon = "menu_cadastro.png", MainMenuItemType = MainMenuItemType.CadastroProduto },
                new MainMenuItem { Title = "Produtos", Icon = "menu_produtos.png", MainMenuItemType = MainMenuItemType.Produtos },
                new MainMenuItem { Title = "Logout", Icon = "menu_logout.png", MainMenuItemType = MainMenuItemType.Logout }
            };
        }
    }
}
