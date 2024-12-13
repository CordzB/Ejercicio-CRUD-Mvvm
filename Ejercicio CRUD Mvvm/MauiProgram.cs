using Ejercicio_CRUD_Mvvm.Data;
using Ejercicio_CRUD_Mvvm.ViewModels;
using Ejercicio_CRUD_Mvvm.Views;

namespace Ejercicio_CRUD_Mvvm;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registrar AppDbContext
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Proveedores.db");
        builder.Services.AddSingleton(new AppDbContext(databasePath));

        // Registrar ViewModel y Página
        builder.Services.AddTransient<ProveedorViewModel>();
        builder.Services.AddTransient<ProveedoresPage>();

        return builder.Build();
    }
}
