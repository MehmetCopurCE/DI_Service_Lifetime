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
    git clone https://github.com/kullaniciadi/DI_Service_Lifetime.git
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

