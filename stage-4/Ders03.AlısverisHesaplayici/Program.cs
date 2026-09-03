BaslikGoster("ALIŞVERİŞ HESAPLAYICI");

string urunAdi = MetinOku("Ürün adını girer misiniz: ");

static decimal PozitifDecimalOku(string mesaj)
{
    while (true)
    {
        Console.Write(mesaj);
        string? input = Console.ReadLine();
        if (decimal.TryParse(input, out decimal sayi) && sayi > 0)
        {
            return sayi;
        }
        else
        {
            Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
        }
    }
}

static decimal SifirVeyaPozitifDecimalOku(string mesaj)
{
    while (true)
    {
        Console.Write(mesaj);
        string? input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal sayi) && sayi >= 0)
        {
            return sayi;
        }

        Console.WriteLine("Lütfen sıfır veya pozitif bir sayı giriniz.");
    }
}

static string MetinOku(string mesaj)
{
    while (true)
    {
        Console.Write(mesaj);
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }

        Console.WriteLine("Lütfen boş bırakmayınız.");
    }
}

decimal fiyat = PozitifDecimalOku("Ürün fiyatını girer misiniz: ");

static int PozitifIntOku(string mesaj)
{
    while (true)
    {
        Console.Write(mesaj);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int sayi) && sayi > 0)
        {
            return sayi;
        }
        else
        {
            Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
        }    
    
    }
}

int adet = PozitifIntOku("Ürün adedini girer misiniz: ");
decimal indirimOrani = SifirVeyaPozitifDecimalOku("Ürün indirim oranını girer misiniz: ");
decimal kdvOrani = SifirVeyaPozitifDecimalOku("Ürün KDV oranını girer misiniz: ");


static void BaslikGoster(string baslik)
{
    Console.WriteLine("========== " + baslik + " ==========");
}

static decimal AraToplamHesapla(decimal birimFiyat, int adet)
{
    return birimFiyat * adet;
}

static decimal YuzdeTutariHesapla(decimal tutar, decimal yuzde)
{
    return tutar * yuzde / 100;
}

static void SiparisOzetiGoster(
    string urunAdi,
    int adet, 
    decimal araToplam,
    decimal indirimOrani,
    decimal kdvOrani,
    decimal genelToplam
)
{
    BaslikGoster("SİPARİŞ ÖZETİ");
    Console.WriteLine($"Ürün: {urunAdi}");
    Console.WriteLine($"Adet: {adet}");
    Console.WriteLine($"Ara toplam: {araToplam:C2}");
    Console.WriteLine($"İndirim oranı: %{indirimOrani}");
    Console.WriteLine($"KDV oranı: %{kdvOrani}");
    Console.WriteLine($"Genel toplam: {genelToplam:C2}");

    BaslikGoster("TEKRAR BEKLERİZ!");

} 

decimal araToplam = AraToplamHesapla(fiyat, adet);
decimal indirimTutari = YuzdeTutariHesapla(araToplam, indirimOrani);
decimal indirimliToplam = araToplam - indirimTutari;
decimal kdvTutari = YuzdeTutariHesapla(indirimliToplam, kdvOrani);
decimal genelToplam = indirimliToplam + kdvTutari;

SiparisOzetiGoster(urunAdi, adet, araToplam, indirimOrani, kdvOrani, genelToplam);


