int ustSinir = 0;
bool ustSinirGecerliMi = false;

while (!ustSinirGecerliMi)
{
    Console.Write("Üst sınır (1-100): ");

    if (int.TryParse(Console.ReadLine(), out ustSinir) && ustSinir >= 1 && ustSinir <= 100)
    {
        ustSinirGecerliMi = true;
    }
    else
    {
        Console.WriteLine("Lütfen 1 ile 100 arasında bir sayı giriniz.");
    }
}

int butunSayilarinToplami = 0;
int ciftSayiAdedi = 0;
int ciftSayilarinToplami = 0;
int tekSayiAdedi = 0;
int tekSayilarinToplami = 0;
int uceBolunenSayiAdedi = 0;
int beseBolunenSayiAdedi = 0;
int uceVeBeseBolunenSayiAdedi = 0;

Console.WriteLine();
Console.WriteLine("======== SAYILAR ========");

for (int sayi = 1; sayi <= ustSinir; sayi++)
{
    butunSayilarinToplami += sayi;

    string aciklama = sayi % 2 == 0
        ? "Çift"
        : "Tek";

    if (sayi % 2 == 0)
    {
        ciftSayiAdedi++;
        ciftSayilarinToplami += sayi;
    }
    else
    {
        tekSayiAdedi++;
        tekSayilarinToplami += sayi;
    }

    if (sayi % 3 == 0)
    {
        uceBolunenSayiAdedi++;
    }

    if (sayi % 5 == 0)
    {
        beseBolunenSayiAdedi++;
    }

    if (sayi % 3 == 0 && sayi % 5 == 0)
    {
        uceVeBeseBolunenSayiAdedi++;
        aciklama += " / 3'e ve 5'e bölünür";
    }
    else if (sayi % 3 == 0)
    {
        aciklama += " / 3'e bölünür";
    }
    else if (sayi % 5 == 0)
    {
        aciklama += " / 5'e bölünür";
    }

    Console.WriteLine($"{sayi} - {aciklama}");
}

Console.WriteLine();
Console.WriteLine("======== SAYI ANALİZİ ========");
Console.WriteLine($"Üst sınır: {ustSinir}");
Console.WriteLine($"Bütün sayıların toplamı: {butunSayilarinToplami}");
Console.WriteLine($"Çift sayı adedi: {ciftSayiAdedi}");
Console.WriteLine($"Çift sayıların toplamı: {ciftSayilarinToplami}");
Console.WriteLine($"Tek sayı adedi: {tekSayiAdedi}");
Console.WriteLine($"Tek sayıların toplamı: {tekSayilarinToplami}");
Console.WriteLine($"3'e bölünen sayı adedi: {uceBolunenSayiAdedi}");
Console.WriteLine($"5'e bölünen sayı adedi: {beseBolunenSayiAdedi}");
Console.WriteLine($"3'e ve 5'e bölünen sayı adedi: {uceVeBeseBolunenSayiAdedi}");

int carpimTablosuSayisi = 0;
bool carpimTablosuSayisiGecerliMi = false;

while (!carpimTablosuSayisiGecerliMi)
{
    Console.WriteLine();
    Console.Write("Çarpım tablosu sayısı (1-10): ");

    if (int.TryParse(Console.ReadLine(), out carpimTablosuSayisi) && carpimTablosuSayisi >= 1 && carpimTablosuSayisi <= 10)
    {
        carpimTablosuSayisiGecerliMi = true;
    }
    else
    {
        Console.WriteLine("Lütfen 1 ile 10 arasında bir sayı giriniz.");
    }
}

Console.WriteLine();
Console.WriteLine($"======== {carpimTablosuSayisi} ÇARPIM TABLOSU ========");

for (int carpim = 1; carpim <= 10; carpim++)
{
    Console.WriteLine($"{carpimTablosuSayisi} x {carpim} = {carpimTablosuSayisi * carpim}");
}
