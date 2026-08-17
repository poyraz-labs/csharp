int ogrenciSayisi = OgrenciSayisiOku();

string[] ogrenciIsimleri = new string[ogrenciSayisi];
decimal[,] notlar = new decimal[ogrenciSayisi, 3];

for (int ogrenciIndeksi = 0; ogrenciIndeksi < ogrenciIsimleri.Length; ogrenciIndeksi++)
{
    Console.Write($"{ogrenciIndeksi + 1}. öğrencinin adı: ");
    ogrenciIsimleri[ogrenciIndeksi] = Console.ReadLine() ?? "";

    for (int sinavIndeksi = 0; sinavIndeksi < notlar.GetLength(1); sinavIndeksi++)
    {
        notlar[ogrenciIndeksi, sinavIndeksi] = NotOku(
            ogrenciIsimleri[ogrenciIndeksi],
            sinavIndeksi + 1
        );
    }
}

RaporGoster(ogrenciIsimleri, notlar);

Console.WriteLine();
Console.WriteLine("======== DİZİ ÇALIŞMALARI ========");

int[] sayilar = [12, 5, 18, 7, 20, 3];

Console.WriteLine($"İlk eleman: {sayilar[0]}");
Console.WriteLine($"Son eleman: {sayilar[^1]}");

int[] ilkUcEleman = sayilar[..3];
int[] sonUcEleman = sayilar[^3..];
int[] siraliKopya = (int[])sayilar.Clone();

Array.Sort(siraliKopya);

Console.WriteLine($"İlk üç eleman: {string.Join(", ", ilkUcEleman)}");
Console.WriteLine($"Son üç eleman: {string.Join(", ", sonUcEleman)}");
Console.WriteLine($"Orijinal dizi: {string.Join(", ", sayilar)}");
Console.WriteLine($"Sıralı kopya: {string.Join(", ", siraliKopya)}");

static int OgrenciSayisiOku()
{
    while (true)
    {
        Console.Write("Öğrenci sayısı (2-10): ");

        if (int.TryParse(Console.ReadLine(), out int ogrenciSayisi) &&
            ogrenciSayisi >= 2 &&
            ogrenciSayisi <= 10)
        {
            return ogrenciSayisi;
        }

        Console.WriteLine("Lütfen 2 ile 10 arasında bir öğrenci sayısı giriniz.");
    }
}

static decimal NotOku(string ogrenciAdi, int sinavNumarasi)
{
    while (true)
    {
        Console.Write($"{ogrenciAdi} - {sinavNumarasi}. sınav notu: ");

        if (decimal.TryParse(Console.ReadLine(), out decimal not) &&
            not >= 0 &&
            not <= 100)
        {
            return not;
        }

        Console.WriteLine("Not 0 ile 100 arasında bir sayı olmalıdır.");
    }
}

static decimal OgrenciOrtalamasiHesapla(
    decimal[,] notlar,
    int ogrenciIndeksi)
{
    decimal toplam = 0m;

    for (int sinavIndeksi = 0; sinavIndeksi < notlar.GetLength(1); sinavIndeksi++)
    {
        toplam += notlar[ogrenciIndeksi, sinavIndeksi];
    }

    return toplam / notlar.GetLength(1);
}

static decimal SinifOrtalamasiHesapla(decimal[,] notlar)
{
    decimal toplam = 0m;
    int notSayisi = 0;

    for (int ogrenciIndeksi = 0; ogrenciIndeksi < notlar.GetLength(0); ogrenciIndeksi++)
    {
        for (int sinavIndeksi = 0; sinavIndeksi < notlar.GetLength(1); sinavIndeksi++)
        {
            toplam += notlar[ogrenciIndeksi, sinavIndeksi];
            notSayisi++;
        }
    }

    return toplam / notSayisi;
}

static void RaporGoster(
    string[] ogrenciIsimleri,
    decimal[,] notlar)
{
    int basariliOgrenciSayisi = 0;
    int basarisizOgrenciSayisi = 0;
    decimal enYuksekOrtalama = 0m;
    string enYuksekOrtalamaliOgrenci = "";

    Console.WriteLine();
    Console.WriteLine("======== SINIF RAPORU ========");

    for (int ogrenciIndeksi = 0; ogrenciIndeksi < ogrenciIsimleri.Length; ogrenciIndeksi++)
    {
        decimal ortalama = OgrenciOrtalamasiHesapla(
            notlar,
            ogrenciIndeksi
        );

        string basariDurumu;

        if (ortalama >= 50)
        {
            basariDurumu = "Başarılı";
            basariliOgrenciSayisi++;
        }
        else
        {
            basariDurumu = "Başarısız";
            basarisizOgrenciSayisi++;
        }

        if (ogrenciIndeksi == 0 || ortalama > enYuksekOrtalama)
        {
            enYuksekOrtalama = ortalama;
            enYuksekOrtalamaliOgrenci = ogrenciIsimleri[ogrenciIndeksi];
        }

        Console.Write($"{ogrenciIsimleri[ogrenciIndeksi],-10}");

        for (int sinavIndeksi = 0; sinavIndeksi < notlar.GetLength(1); sinavIndeksi++)
        {
            Console.Write($" | {notlar[ogrenciIndeksi, sinavIndeksi],6:F2}");
        }

        Console.WriteLine($" | Ortalama: {ortalama:F2} | {basariDurumu}");
    }

    decimal sinifOrtalamasi = SinifOrtalamasiHesapla(notlar);

    Console.WriteLine();
    Console.WriteLine($"Sınıf ortalaması: {sinifOrtalamasi:F2}");
    Console.WriteLine($"Başarılı öğrenci sayısı: {basariliOgrenciSayisi}");
    Console.WriteLine($"Başarısız öğrenci sayısı: {basarisizOgrenciSayisi}");
    Console.WriteLine($"En yüksek ortalama: {enYuksekOrtalamaliOgrenci} - {enYuksekOrtalama:F2}");
}
