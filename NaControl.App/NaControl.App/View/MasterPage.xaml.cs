using NaControl.App.Model;
using NaControl.App.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaControl.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage, INotifyPropertyChanged
    {
        private ObservableCollection<MasterPageItem> _menuLista;

        public MasterPage()
        {
            InitializeComponent();
            _menuLista = ItemService.GetMenuItens();
            navigationDrawerList.ItemsSource = _menuLista;
            // Define a propriedade ItemSource da pagina MainPage.xaml
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));

            BindingContext = this;
        }

        private void lvContas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var conta = e.SelectedItem as Conta;
            ////await Navigation.PushAsync(new ContaDetalhesPage(conta));
            //Detail = new ContaDetalhesPage(conta);
            ////para exibir a pagina de detalhes
            //IsPresented = false;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            //obtem o tipo de objeto 
            Type pagina = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina));
            IsPresented = false;
        }
    }
}