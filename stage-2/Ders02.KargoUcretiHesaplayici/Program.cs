Console.Write("Adınızı giriniz: ");
string? ad = Console.ReadLine();

Console.Write("Paket Ağırlığını (kg) giriniz: ");
if(!decimal.TryParse(Console.ReadLine(), out decimal agirlik))
{
    Console.WriteLine("Geçersiz ağırlık girdiniz.");
    return;
}

Console.WriteLine("E - Ekonomik: 80 TL");
Console.WriteLine("S - Standart: 120 TL");
Console.WriteLine("H - Hızlı: 200 TL");
Console.Write("Teslimat türünü giriniz (E/S/H): ");
string? teslimatTuru = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

decimal teslimatUcreti = teslimatTuru switch
{
    "E" => 80,
    "S" => 120,
    "H" => 200,
    _ => throw new ArgumentException("Geçersiz teslimat türü") // Geçersiz teslimat türü
};

Console.Write("Üyelik Durumu (Evet/Hayır): ");
string? uyelikDurumu = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

decimal agirlikEkUcreti = 0;

if (agirlik <= 0)
{
    Console.WriteLine("Ağırlık 0 kg veya daha az olamaz.");
    return;
}
else if (agirlik <= 1)
{
    agirlikEkUcreti = 0;
}
else if (agirlik <= 5)
{
    agirlikEkUcreti = teslimatUcreti * 0.2m; // 1-5 kg arası paketler için teslimat ücretinin %20'si
}
else if (agirlik <= 10)
{
    agirlikEkUcreti = teslimatUcreti * 0.4m; // 5-10 kg arası paketler için teslimat ücretinin %40'si
}
else
{
    agirlikEkUcreti = teslimatUcreti * 0.75m; // 10 kg üzeri paketler için teslimat ücretinin %75'i
}

decimal uyelikIndirimi = uyelikDurumu == "EVET" ? 0.1m : 0; // Üyelik varsa %10 indirim

decimal toplamUcret = teslimatUcreti + agirlikEkUcreti;
decimal indirimliUcret = toplamUcret * (1 - uyelikIndirimi);

Console.WriteLine();

Console.WriteLine("======= Kargo Özetiniz =======");
Console.WriteLine($"Ad: {ad}");
Console.WriteLine($"Paket Ağırlığı: {agirlik} kg");
Console.WriteLine($"Teslimat Türü: {teslimatTuru}");
Console.WriteLine($"Teslimat Ücreti: {teslimatUcreti:F2} TL");
Console.WriteLine($"Ağırlık Ek Ücreti: {agirlikEkUcreti:F2} TL");
Console.WriteLine($"Ara Toplam: {toplamUcret:F2} TL");
if (uyelikIndirimi > 0)
{
    Console.WriteLine($"Üyelik İndirimi: {uyelikIndirimi * 100}%");
}
Console.WriteLine($"Toplam Ücret: {indirimliUcret:F2} TL");