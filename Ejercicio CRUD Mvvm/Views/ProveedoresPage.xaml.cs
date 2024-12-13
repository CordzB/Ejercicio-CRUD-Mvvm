using Ejercicio_CRUD_Mvvm.ViewModels;

namespace Ejercicio_CRUD_Mvvm.Views
{
    public partial class ProveedoresPage : ContentPage
    {
        public ProveedoresPage()
        {
            InitializeComponent();
            BindingContext = new ProveedorViewModel();
        }
    }
}
