# DI_Service_Lifetime

Bu proje, .NET Core'da Dependency Injection (DI) türlerini ve bunların yaşam döngülerini göstermek için hazırlanmıştır. Proje, Transient, Scoped ve Singleton türlerini açıklayan ve bunların nasıl çalıştığını demonstrasyon eden bir örnek içerir.

## İçindekiler

- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Servis Türleri ve Yaşam Döngüleri](#servis-türleri-ve-yaşam-döngüleri)
- [Bağlantı](#bağlantı)

## Kullanılan Teknolojiler

- .NET Core 3.1 veya üzeri
- ASP.NET Core MVC

## Kurulum

1. Bu projeyi bilgisayarınıza klonlayın:

    ```bash
    https://github.com/MehmetCopurCE/DI_Service_Lifetime.git
    ```

2. Proje dizinine gidin:

    ```bash
    cd DI_Service_Lifetime
    ```

3. Gerekli bağımlılıkları yükleyin:

    ```bash
    dotnet restore
    ```

4. Uygulamayı çalıştırın:

    ```bash
    dotnet run
    ```

## Kullanım

Uygulama çalıştırıldığında, `HomeController` içerisindeki `Index` aksiyonu çağrılır. Bu aksiyon, farklı yaşam döngüsüne sahip servislerin GUID'lerini gösterir ve bu GUID'leri yanıt olarak döner. Tarayıcınızda aşağıdaki URL'yi ziyaret ederek sonuçları görebilirsiniz:

http://localhost:5000/

## Servis Türleri ve Yaşam Döngüleri

### Transient

- **Tanım**: Transient servisler her istek yapıldığında yeniden oluşturulur.
- **Kullanım Alanı**: Kısa ömürlü işlemler, stateless servisler.
- **Örnek**:

    ```csharp
    builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();
    ```

### Scoped

- **Tanım**: Scoped servisler her HTTP isteği başına bir kez oluşturulur ve aynı istek boyunca aynı instance kullanılır.
- **Kullanım Alanı**: Web uygulamalarında istek başına bir instance ihtiyacı olan işlemler.
- **Örnek**:

    ```csharp
    builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();
    ```

### Singleton

- **Tanım**: Singleton servisler uygulama ömrü boyunca tek bir kez oluşturulur ve her istek için aynı instance kullanılır.
- **Kullanım Alanı**: Paylaşılan veriler ve durumlar, cache, configuration ayarları.
- **Örnek**:

    ```csharp
    builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();
    ```

### Kod Açıklaması

#### `HomeController.cs`

```csharp
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;

namespace DI_Service_Lifetime.Controllers;

public class HomeController : Controller
{
    private readonly ISingletonGuidService _singleton1;
    private readonly ISingletonGuidService _singleton2;
    
    private readonly IScopedGuidService _scoped1;
    private readonly IScopedGuidService _scoped2;
    
    private readonly ITransientGuidService _transient1;
    private readonly ITransientGuidService _transient2;
    
    public HomeController(
        ISingletonGuidService singleton1, 
        ISingletonGuidService singleton2,
        IScopedGuidService scoped1,
        IScopedGuidService scoped2,
        ITransientGuidService transient1,
        ITransientGuidService transient2)
    {
        _singleton1 = singleton1;
        _singleton2 = singleton2;
        _scoped1 = scoped1;
        _scoped2 = scoped2;
        _transient1 = transient1;
        _transient2 = transient2;
    }

    public IActionResult Index()
    {
        StringBuilder message = new StringBuilder();
        message.Append($"Transient 1 : {_transient1.GetGuid()}\n");
        message.Append($"Transient 2 : {_transient2.GetGuid()}\n\n\n");
        message.Append($"Scoped 1 : {_scoped1.GetGuid()}\n");
        message.Append($"Scoped 2 : {_scoped2.GetGuid()}\n\n\n");
        message.Append($"Singleton 1 : {_singleton1.GetGuid()}\n");
        message.Append($"Singleton 2 : {_singleton2.GetGuid()}\n\n\n");

        return Ok(message.ToString());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
```
