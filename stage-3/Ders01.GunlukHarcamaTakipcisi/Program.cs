Console.Write("Kullanıcı adınız: ");
string? kullaniciAdi = Console.ReadLine();

decimal butce = 0m;
bool gecerliButceGirildiMi = false;

while (!gecerliButceGirildiMi)
{
    Console.Write("Günlük bütçeniz: ");

    if (decimal.TryParse(Console.ReadLine(), out butce) &&
        butce > 0)
    {
        gecerliButceGirildiMi = true;
    }
    else
    {
        Console.WriteLine(
            "Lütfen sıfırdan büyük geçerli bir sayı giriniz."
        );
    }
}

decimal toplamHarcama = 0m;
decimal enYuksekHarcama = 0m;
int harcamaSayisi = 0;

while (true)
{
    Console.Write(
        "Harcama tutarını giriniz (bitirmek için 0): "
    );

    if (!decimal.TryParse(
            Console.ReadLine(),
            out decimal harcamaTutari))
    {
        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
        continue;
    }

    if (harcamaTutari < 0)
    {
        Console.WriteLine("Harcama tutarı negatif olamaz.");
        continue;
    }

    if (harcamaTutari == 0)
    {
        break;
    }

    toplamHarcama += harcamaTutari;
    harcamaSayisi++;

    if (harcamaTutari > enYuksekHarcama)
    {
        enYuksekHarcama = harcamaTutari;
    }
}

decimal ortalamaHarcama = 0m;

if (harcamaSayisi > 0)
{
    ortalamaHarcama =
        toplamHarcama / harcamaSayisi;
}

decimal kalanButce =
    butce - toplamHarcama;

string durum;

if (kalanButce > 0)
{
    durum = "Bütçe sınırları içerisinde";
}
else if (kalanButce == 0)
{
    durum = "Bütçe tamamen kullanıldı";
}
else
{
    durum = "Bütçe aşıldı";
}

Console.WriteLine();
Console.WriteLine("======== HARCAMA ÖZETİ ========");
Console.WriteLine($"Kullanıcı: {kullaniciAdi}");
Console.WriteLine($"Günlük bütçe: {butce:F2} TL");
Console.WriteLine($"Harcama sayısı: {harcamaSayisi}");
Console.WriteLine($"Toplam harcama: {toplamHarcama:F2} TL");
Console.WriteLine(
    $"Ortalama harcama: {ortalamaHarcama:F2} TL"
);
Console.WriteLine(
    $"En yüksek harcama: {enYuksekHarcama:F2} TL"
);
Console.WriteLine($"Kalan bütçe: {kalanButce:F2} TL");
Console.WriteLine($"Durum: {durum}");