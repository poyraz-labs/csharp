Console.Write("Adınızı giriniz: ");
string? ad = Console.ReadLine();

Console.Write("Yaşınızı giriniz: ");

if (!int.TryParse(Console.ReadLine(), out int yas))
{
    Console.WriteLine(
        "Geçersiz giriş. Lütfen yaşınızı tam sayı olarak giriniz."
    );
    return;
}

if (yas <= 0)
{
    Console.WriteLine("Yaş sıfırdan büyük olmalıdır.");
    return;
}

Console.Write("Öğrenci misiniz? (E/H): ");
string? ogrenciCevabi = Console.ReadLine();

bool ogrenciMi =
    ogrenciCevabi == "E" || ogrenciCevabi == "e";

Console.Write("Normal bilet fiyatı: ");

if (!decimal.TryParse(
        Console.ReadLine(),
        out decimal normalBiletFiyati))
{
    Console.WriteLine(
        "Geçersiz giriş. Lütfen geçerli bir bilet fiyatı giriniz."
    );
    return;
}

if (normalBiletFiyati <= 0)
{
    Console.WriteLine("Bilet fiyatı sıfırdan büyük olmalıdır.");
    return;
}

string indirimDurumu;
decimal indirimOrani;

if (yas <= 6)
{
    indirimOrani = 1.00m;
    indirimDurumu = "Ücretsiz çocuk bileti";
}
else if (yas <= 17)
{
    indirimOrani = 0.50m;
    indirimDurumu = "Çocuk ve genç indirimi";
}
else if (yas >= 65)
{
    indirimOrani = 0.40m;
    indirimDurumu = "65 yaş ve üzeri indirimi";
}
else if (yas >= 18 && yas <= 64 && ogrenciMi)
{
    indirimOrani = 0.25m;
    indirimDurumu = "Öğrenci indirimi";
}
else
{
    indirimOrani = 0.00m;
    indirimDurumu = "Tam ücret";
}

decimal indirimTutari =
    normalBiletFiyati * indirimOrani;

decimal odenecekTutar =
    normalBiletFiyati - indirimTutari;

Console.WriteLine();
Console.WriteLine("======== Bilet Bilgileri ========");
Console.WriteLine($"Ad: {ad}");
Console.WriteLine($"Yaş: {yas}");
Console.WriteLine($"Öğrenci: {(ogrenciMi ? "Evet" : "Hayır")}");
Console.WriteLine($"Normal fiyat: {normalBiletFiyati:F2} TL");
Console.WriteLine($"İndirim türü: {indirimDurumu}");
Console.WriteLine($"İndirim oranı: %{indirimOrani * 100:F0}");
Console.WriteLine($"İndirim tutarı: {indirimTutari:F2} TL");
Console.WriteLine($"Ödenecek tutar: {odenecekTutar:F2} TL");