Console.Write("Müşteri adı: ");
string? ad = Console.ReadLine();

Console.Write("Yaşınız: ");

if (!int.TryParse(Console.ReadLine(), out int yas))
{
    Console.WriteLine("Lütfen yaşınızı tam sayı olarak giriniz.");
    return;
}

if (yas <= 0)
{
    Console.WriteLine("Yaş sıfırdan büyük olmalıdır.");
    return;
}

Console.Write("Kaç yıldır ehliyet sahibisiniz? ");

if (!int.TryParse(Console.ReadLine(), out int ehliyetSuresi))
{
    Console.WriteLine(
        "Lütfen ehliyet süresini tam sayı olarak giriniz."
    );
    return;
}

if (ehliyetSuresi < 0)
{
    Console.WriteLine("Ehliyet süresi negatif olamaz.");
    return;
}

Console.WriteLine();
Console.WriteLine("E - Ekonomik");
Console.WriteLine("S - SUV");
Console.WriteLine("L - Lüks");
Console.Write("Araç seçiminiz: ");

string aracSecimi =
    Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

string aracTuru;
decimal gunlukUcret;
decimal depozito;

switch (aracSecimi)
{
    case "E":
        aracTuru = "Ekonomik";
        gunlukUcret = 1000m;
        depozito = 5000m;
        break;

    case "S":
        aracTuru = "SUV";
        gunlukUcret = 1800m;
        depozito = 8000m;
        break;

    case "L":
        aracTuru = "Lüks";
        gunlukUcret = 3000m;
        depozito = 15000m;
        break;

    default:
        Console.WriteLine("Geçersiz araç kodu girdiniz.");
        return;
}

bool kiralamayaUygunMu = aracSecimi switch
{
    "E" => yas >= 21 && ehliyetSuresi >= 1,
    "S" => yas >= 25 && ehliyetSuresi >= 3,
    "L" => yas >= 30 && ehliyetSuresi >= 5,
    _ => false
};

if (!kiralamayaUygunMu)
{
    Console.WriteLine(
        "Yaş veya ehliyet süresi şartlarını karşılamıyorsunuz."
    );
    return;
}

Console.Write("Kaç gün kiralamak istiyorsunuz? ");

if (!int.TryParse(Console.ReadLine(), out int kiralamaSuresi))
{
    Console.WriteLine(
        "Lütfen kiralama süresini tam sayı olarak giriniz."
    );
    return;
}

if (kiralamaSuresi <= 0)
{
    Console.WriteLine("Kiralama süresi sıfırdan büyük olmalıdır.");
    return;
}

decimal sureIndirimOrani;

if (kiralamaSuresi >= 14)
{
    sureIndirimOrani = 0.15m;
}
else if (kiralamaSuresi >= 7)
{
    sureIndirimOrani = 0.10m;
}
else
{
    sureIndirimOrani = 0m;
}

Console.Write("Üye misiniz? (E/H): ");

string uyelikCevabi =
    Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

bool uyelikCevabiGecerliMi =
    uyelikCevabi == "E" || uyelikCevabi == "H";

if (!uyelikCevabiGecerliMi)
{
    Console.WriteLine("Üyelik için yalnızca E veya H giriniz.");
    return;
}

bool uyeMi = uyelikCevabi == "E";

decimal uyelikIndirimOrani =
    uyeMi ? 0.05m : 0m;

Console.Write("Ek sigorta ister misiniz? (E/H): ");

string sigortaCevabi =
    Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

bool sigortaCevabiGecerliMi =
    sigortaCevabi == "E" || sigortaCevabi == "H";

if (!sigortaCevabiGecerliMi)
{
    Console.WriteLine("Sigorta için yalnızca E veya H giriniz.");
    return;
}

bool ekSigortaIstiyorMu =
    sigortaCevabi == "E";

const decimal GunlukSigortaUcreti = 250m;

decimal temelKiralamaTutari =
    gunlukUcret * kiralamaSuresi;

decimal sureIndirimTutari =
    temelKiralamaTutari * sureIndirimOrani;

decimal sureIndirimliTutar =
    temelKiralamaTutari - sureIndirimTutari;

decimal uyelikIndirimTutari =
    sureIndirimliTutar * uyelikIndirimOrani;

decimal sigortaToplami = 0m;

if (ekSigortaIstiyorMu)
{
    sigortaToplami =
        GunlukSigortaUcreti * kiralamaSuresi;
}

decimal odenecekKiralamaTutari =
    sureIndirimliTutar
    - uyelikIndirimTutari
    + sigortaToplami;

decimal teslimAlmaToplami =
    odenecekKiralamaTutari + depozito;

Console.WriteLine();
Console.WriteLine("======== ARAÇ KİRALAMA ÖZETİ ========");
Console.WriteLine($"Müşteri: {ad}");
Console.WriteLine($"Araç türü: {aracTuru}");
Console.WriteLine($"Kiralama süresi: {kiralamaSuresi} gün");
Console.WriteLine($"Günlük ücret: {gunlukUcret:F2} TL");
Console.WriteLine(
    $"Temel kiralama tutarı: {temelKiralamaTutari:F2} TL"
);
Console.WriteLine(
    $"Süre indirimi: {sureIndirimTutari:F2} TL"
);
Console.WriteLine(
    $"Üyelik indirimi: {uyelikIndirimTutari:F2} TL"
);
Console.WriteLine($"Sigorta toplamı: {sigortaToplami:F2} TL");
Console.WriteLine(
    $"Ödenecek kiralama tutarı: {odenecekKiralamaTutari:F2} TL"
);
Console.WriteLine($"Depozito: {depozito:F2} TL");
Console.WriteLine(
    $"Teslim alırken gereken toplam: {teslimAlmaToplami:F2} TL"
);