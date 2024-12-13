using Ejercicio_CRUD_Mvvm.Views;

namespace Ejercicio_CRUD_Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new ProveedoresPage()); // Página principal
        }
    }
}
