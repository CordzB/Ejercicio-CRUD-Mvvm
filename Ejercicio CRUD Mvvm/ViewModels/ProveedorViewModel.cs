using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejercicio_CRUD_Mvvm.Data;
using Ejercicio_CRUD_Mvvm.Models;

namespace Ejercicio_CRUD_Mvvm.ViewModels
{
    public partial class ProveedorViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        public ObservableCollection<Proveedor> Proveedores { get; set; } = new();

        private Proveedor _nuevoProveedor = new();
        public Proveedor NuevoProveedor
        {
            get => _nuevoProveedor;
            set
            {
                if (_nuevoProveedor != value)
                {
                    _nuevoProveedor = value;
                    OnPropertyChanged(nameof(NuevoProveedor));
                }
            }
        }

        public ProveedorViewModel()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Proveedores.db");
            _dbContext = new AppDbContext(databasePath);

            CargarProveedores();
        }

        private void CargarProveedores()
        {
            Proveedores.Clear();
            var proveedores = _dbContext.Proveedores.ToList();
            foreach (var proveedor in proveedores)
            {
                Proveedores.Add(proveedor);
            }
        }

        [RelayCommand]
        public void AgregarProveedor()
        {
            if (string.IsNullOrWhiteSpace(NuevoProveedor.Nombre) ||
                string.IsNullOrWhiteSpace(NuevoProveedor.Direcci�n) ||
                string.IsNullOrWhiteSpace(NuevoProveedor.Tel�fono) ||
                string.IsNullOrWhiteSpace(NuevoProveedor.Correo))
            {
                return; // Validaci�n
            }

            if (NuevoProveedor.Id == 0)
            {
                // Nuevo registro
                _dbContext.Proveedores.Add(NuevoProveedor);
            }
            else
            {
                // Actualizaci�n
                var proveedorExistente = _dbContext.Proveedores.FirstOrDefault(p => p.Id == NuevoProveedor.Id);
                if (proveedorExistente != null)
                {
                    proveedorExistente.Nombre = NuevoProveedor.Nombre;
                    proveedorExistente.Direcci�n = NuevoProveedor.Direcci�n;
                    proveedorExistente.Tel�fono = NuevoProveedor.Tel�fono;
                    proveedorExistente.Correo = NuevoProveedor.Correo;
                }
            }

            _dbContext.SaveChanges();
            CargarProveedores();

            NuevoProveedor = new Proveedor(); // Limpiar el formulario
        }

        [RelayCommand]
        public void EliminarProveedor(Proveedor proveedor)
        {
            if (proveedor == null) return;

            _dbContext.Proveedores.Remove(proveedor);
            _dbContext.SaveChanges();

            Proveedores.Remove(proveedor);
        }

        [RelayCommand]
        public void EditarProveedor(Proveedor proveedor)
        {
            if (proveedor == null) return;

            // Carga los datos del proveedor seleccionado en el formulario
            NuevoProveedor = new Proveedor
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Direcci�n = proveedor.Direcci�n,
                Tel�fono = proveedor.Tel�fono,
                Correo = proveedor.Correo
            };
        }
    }
}
