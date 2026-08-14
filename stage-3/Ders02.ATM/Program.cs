using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("tr-TR");

Console.Write("Müşteri adı: ");
string? musteriAdi = Console.ReadLine();

decimal bakiye = 0m;
bool baslangicBakiyesiGecerliMi = false;

while (!baslangicBakiyesiGecerliMi)
{
    Console.Write("Başlangıç bakiyesi: ");

    if (decimal.TryParse(Console.ReadLine(), out bakiye) && bakiye >= 0)
    {
        baslangicBakiyesiGecerliMi = true;
    }
    else
    {
        Console.WriteLine("Başlangıç bakiyesi negatif olamaz ve sayı olmalıdır.");
    }
}

int paraYatirmaSayisi = 0;
decimal toplamYatirilanPara = 0m;
int paraCekmeSayisi = 0;
decimal toplamCekilenPara = 0m;
int secim;

do
{
    Console.WriteLine();
    Console.WriteLine("======== ATM MENÜSÜ ========");
    Console.WriteLine("1 - Bakiye görüntüle");
    Console.WriteLine("2 - Para yatır");
    Console.WriteLine("3 - Para çek");
    Console.WriteLine("4 - İşlem özeti");
    Console.WriteLine("0 - Çıkış");
    Console.Write("Seçiminiz: ");

    if (!int.TryParse(Console.ReadLine(), out secim))
    {
        Console.WriteLine("Hatalı menü girişi.");
        secim = -1;
        continue;
    }

    Console.WriteLine();

    switch (secim)
    {
        case 1:
            Console.WriteLine($"Mevcut bakiye: {bakiye:F2} TL");
            break;

        case 2:
            Console.Write("Yatırılacak tutar: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal yatirilacakTutar) || yatirilacakTutar <= 0)
            {
                Console.WriteLine("Yatırılacak tutar sıfırdan büyük bir sayı olmalıdır.");
                break;
            }

            bakiye += yatirilacakTutar;
            paraYatirmaSayisi++;
            toplamYatirilanPara += yatirilacakTutar;

            Console.WriteLine("Para yatırma başarılı.");
            Console.WriteLine($"Yeni bakiye: {bakiye:F2} TL");
            break;

        case 3:
            Console.Write("Çekilecek tutar: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal cekilecekTutar) || cekilecekTutar <= 0)
            {
                Console.WriteLine("Çekilecek tutar sıfırdan büyük bir sayı olmalıdır.");
                break;
            }

            if (cekilecekTutar > bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
                break;
            }

            bakiye -= cekilecekTutar;
            paraCekmeSayisi++;
            toplamCekilenPara += cekilecekTutar;

            Console.WriteLine("Para çekme başarılı.");
            Console.WriteLine($"Yeni bakiye: {bakiye:F2} TL");
            break;

        case 4:
            Console.WriteLine("======== İŞLEM ÖZETİ ========");
            Console.WriteLine($"Para yatırma sayısı: {paraYatirmaSayisi}");
            Console.WriteLine($"Toplam yatırılan: {toplamYatirilanPara:F2} TL");
            Console.WriteLine($"Para çekme sayısı: {paraCekmeSayisi}");
            Console.WriteLine($"Toplam çekilen: {toplamCekilenPara:F2} TL");
            Console.WriteLine($"Mevcut bakiye: {bakiye:F2} TL");
            break;

        case 0:
            Console.WriteLine($"Güle güle, {musteriAdi}.");
            break;

        default:
            Console.WriteLine("Hatalı menü girişi.");
            continue;
    }
}
while (secim != 0);

Console.WriteLine();
Console.WriteLine("======== SON İŞLEM ÖZETİ ========");
Console.WriteLine($"Para yatırma sayısı: {paraYatirmaSayisi}");
Console.WriteLine($"Toplam yatırılan: {toplamYatirilanPara:F2} TL");
Console.WriteLine($"Para çekme sayısı: {paraCekmeSayisi}");
Console.WriteLine($"Toplam çekilen: {toplamCekilenPara:F2} TL");
Console.WriteLine($"Son bakiye: {bakiye:F2} TL");
