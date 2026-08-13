Console.Write("Adınızı giriniz: ");
string? ad = Console.ReadLine();

Console.Write("Paket ağırlığını (kg) giriniz: ");

if (!decimal.TryParse(Console.ReadLine(), out decimal agirlik))
{
    Console.WriteLine("Geçersiz ağırlık girdiniz.");
    return;
}

if (agirlik <= 0)
{
    Console.WriteLine("Ağırlık sıfırdan büyük olmalıdır.");
    return;
}

Console.WriteLine();
Console.WriteLine("E - Ekonomik: 80 TL");
Console.WriteLine("S - Standart: 120 TL");
Console.WriteLine("H - Hızlı: 200 TL");
Console.Write("Teslimat türünü giriniz (E/S/H): ");

string teslimatKodu =
    Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

string teslimatTuru;
decimal temelUcret;

switch (teslimatKodu)
{
    case "E":
        teslimatTuru = "Ekonomik";
        temelUcret = 80m;
        break;

    case "S":
        teslimatTuru = "Standart";
        temelUcret = 120m;
        break;

    case "H":
        teslimatTuru = "Hızlı";
        temelUcret = 200m;
        break;

    default:
        Console.WriteLine("Geçersiz teslimat türü girdiniz.");
        return;
}

Console.Write("Üye misiniz? (E/H): ");

string uyelikCevabi =
    Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

if (uyelikCevabi != "E" && uyelikCevabi != "H")
{
    Console.WriteLine("Üyelik durumu için yalnızca E veya H giriniz.");
    return;
}

bool uyeMi = uyelikCevabi == "E";

decimal agirlikEkUcreti;

if (agirlik <= 1)
{
    agirlikEkUcreti = 0m;
}
else if (agirlik <= 5)
{
    agirlikEkUcreti = temelUcret * 0.20m;
}
else if (agirlik <= 10)
{
    agirlikEkUcreti = temelUcret * 0.40m;
}
else
{
    agirlikEkUcreti = temelUcret * 0.75m;
}

decimal araToplam =
    temelUcret + agirlikEkUcreti;

decimal uyelikIndirimOrani = 0m;

if (uyeMi)
{
    uyelikIndirimOrani = 0.10m;
}

decimal uyelikIndirimTutari =
    araToplam * uyelikIndirimOrani;

decimal odenecekToplam =
    araToplam - uyelikIndirimTutari;

Console.WriteLine();
Console.WriteLine("======= Kargo Özeti =======");
Console.WriteLine($"Müşteri: {ad}");
Console.WriteLine($"Paket ağırlığı: {agirlik:F2} kg");
Console.WriteLine($"Teslimat türü: {teslimatTuru}");
Console.WriteLine($"Üyelik durumu: {(uyeMi ? "Üye" : "Üye değil")}");
Console.WriteLine($"Temel ücret: {temelUcret:F2} TL");
Console.WriteLine($"Ağırlık ek ücreti: {agirlikEkUcreti:F2} TL");
Console.WriteLine($"Ara toplam: {araToplam:F2} TL");
Console.WriteLine(
    $"Üyelik indirimi: {uyelikIndirimTutari:F2} TL"
);
Console.WriteLine($"Ödenecek toplam: {odenecekToplam:F2} TL");