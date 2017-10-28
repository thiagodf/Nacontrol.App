using NaControl.App.Model;
using NaControl.App.View;
using System.Collections.ObjectModel;

namespace NaControl.App.Services
{
    public class ItemService
    {
        private static ObservableCollection<MasterPageItem> menuLista { get; set; }

        public static ObservableCollection<MasterPageItem> GetMenuItens()
        {
            menuLista = new ObservableCollection<MasterPageItem>();
            // Criando as paginas para navegação
            // Definimos o titulo para o item
            // o icone do lado esquerdo e a pagina que vamos abrir
            var pagina1 = new MasterPageItem() { Title = "Home", Icon = "home.png", TargetType = typeof(HomePage) };
            var pagina2 = new MasterPageItem() { Title = "Buscar Grupos", Icon = "map.png", TargetType = typeof(NaControlMaps) };
            var pagina3 = new MasterPageItem() { Title = "Informações", Icon = "information.png", TargetType = typeof(Information) };
            var pagina4 = new MasterPageItem() { Title = "Literatura", Icon = "literature.png", TargetType = typeof(Literature) };
            // Adicionando items no menuLista
            menuLista.Add(pagina1);
            menuLista.Add(pagina2);
            menuLista.Add(pagina3);
            menuLista.Add(pagina4);
            //retorna a lista de itens 
            return menuLista;
        }
    }
}
