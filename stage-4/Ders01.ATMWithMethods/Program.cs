Console.Write("Müşteri adı: ");
string? musteriAdi = Console.ReadLine();

static decimal TutarOku(string mesaj, bool sifirKabulEdilsin)
{
    while (true)
    {
        Console.Write(mesaj);

        if (decimal.TryParse(Console.ReadLine(), out decimal tutar))
        {
            if (sifirKabulEdilsin && tutar == 0)
            {
                return tutar;
            }

            if (!sifirKabulEdilsin && tutar == 0)
            {
                Console.WriteLine("Tutar 0 olamaz!");
                continue;
            } 

            if (tutar < 0)
            {
                Console.WriteLine("Tutar 0'dan küçük olamaz.");
                continue;
            }

            return tutar;
        }
        else
        {
            Console.WriteLine("Lütfen tam sayı giriniz!");
        }
    }
}

decimal bakiye = TutarOku(
    "Başlangıç bakiyesi: ",
    true
);

int paraYatirmaSayisi = 0;
decimal toplamYatirilanPara = 0m;

int paraCekmeSayisi = 0;
decimal toplamCekilenPara = 0m;

int secim;

static void MenuyuGoster()
{
    Console.WriteLine();
    Console.WriteLine("======== ATM MENÜSÜ ========");
    Console.WriteLine("1 - Bakiye görüntüle");
    Console.WriteLine("2 - Para yatır");
    Console.WriteLine("3 - Para çek");
    Console.WriteLine("4 - İşlem özeti");
    Console.WriteLine("0 - Çıkış");
}

do
{
    MenuyuGoster();
    secim = MenuSecimiOku();

    switch (secim)
    {
        case 1:
            Console.WriteLine(
                $"Mevcut bakiye: {bakiye:F2} TL"
            );
            break;

        case 2:
            decimal yatirilacakTutar = TutarOku(
                "Yatırılacak tutar: ",
                false
            );

            bakiye = ParaYatir(
                bakiye,
                yatirilacakTutar
            );

            paraYatirmaSayisi++;
            toplamYatirilanPara += yatirilacakTutar;

            Console.WriteLine("Para yatırma başarılı.");
            break;

        case 3:
            decimal cekilecekTutar = TutarOku(
                "Çekilecek tutar: ",
                false
            );

            if (!ParaCekilebilirMi(
                    bakiye,
                    cekilecekTutar))
            {
                Console.WriteLine("Yetersiz bakiye.");
                break;
            }

            bakiye = ParaCek(
                bakiye,
                cekilecekTutar
            );

            paraCekmeSayisi++;
            toplamCekilenPara += cekilecekTutar;

            Console.WriteLine("Para çekme başarılı.");
            break;

        case 4:
            IslemOzetiGoster(
                paraYatirmaSayisi,
                toplamYatirilanPara,
                paraCekmeSayisi,
                toplamCekilenPara,
                bakiye
            );
            break;

        case 0:
            Console.WriteLine(
                $"Güle güle, {musteriAdi}."
            );
            break;

        default:
            Console.WriteLine("Geçersiz seçim.");
            break;
    }
}
while (secim != 0);

IslemOzetiGoster(
    paraYatirmaSayisi,
    toplamYatirilanPara,
    paraCekmeSayisi,
    toplamCekilenPara,
    bakiye
);

static int MenuSecimiOku()
{
    while (true)
    {
        Console.Write("Seçiminiz: ");

        if (int.TryParse(Console.ReadLine(), out int secim))
        {
            return secim;
        }

        Console.WriteLine("Lütfen geçerli bir menü seçimi giriniz.");
    }
}

static decimal ParaYatir(decimal bakiye, decimal yatirilacakTutar)
{
    return bakiye + yatirilacakTutar;
}

static bool ParaCekilebilirMi(decimal bakiye, decimal cekilecekTutar)
{
    return cekilecekTutar <= bakiye;
}

static decimal ParaCek(decimal bakiye, decimal cekilecekTutar)
{
    return bakiye - cekilecekTutar;
}

static void IslemOzetiGoster(
    int paraYatirmaSayisi,
    decimal toplamYatirilanPara,
    int paraCekmeSayisi,
    decimal toplamCekilenPara,
    decimal bakiye)
{
    Console.WriteLine();
    Console.WriteLine("======== İŞLEM ÖZETİ ========");
    Console.WriteLine($"Para yatırma sayısı: {paraYatirmaSayisi}");
    Console.WriteLine($"Toplam yatırılan: {toplamYatirilanPara:F2} TL");
    Console.WriteLine($"Para çekme sayısı: {paraCekmeSayisi}");
    Console.WriteLine($"Toplam çekilen: {toplamCekilenPara:F2} TL");
    Console.WriteLine($"Mevcut bakiye: {bakiye:F2} TL");
}
