Console.Write("Etkinlik adı nedir? ");
string? etkinlikAdi = Console.ReadLine();

Console.Write("Katılımcı sayısı kaçtır? ");
if (!int.TryParse(Console.ReadLine(), out int katilimciSayisi))
{
    Console.WriteLine(
        "Geçersiz giriş. Lütfen katılımcı sayısını tam sayı olarak giriniz."
    );
    return;
}

if (katilimciSayisi == 0)
{
    Console.WriteLine("Katılımcı sayısı sıfır olamaz.");
    return;
}

Console.Write("Kişi başı etkinlik ücreti ne kadar? ");
if (!decimal.TryParse(Console.ReadLine(), out decimal kisiBasiUcret))
{
    Console.WriteLine(
        "Geçersiz giriş. Lütfen geçerli bir ücret giriniz."
    );
    return;
}

Console.Write("Hizmet bedeli yüzdesi ne kadar? ");
if (!decimal.TryParse(
        Console.ReadLine(),
        out decimal hizmetBedeliYuzdesi))
{
    Console.WriteLine(
        "Geçersiz giriş. Lütfen geçerli bir yüzde giriniz."
    );
    return;
}

decimal araToplamUcret =
    katilimciSayisi * kisiBasiUcret;

decimal hizmetBedeli =
    araToplamUcret * hizmetBedeliYuzdesi / 100;

decimal toplamUcret =
    araToplamUcret + hizmetBedeli;

decimal kisiBasiToplamUcret =
    toplamUcret / katilimciSayisi;

Console.WriteLine();
Console.WriteLine("======== Etkinlik Bilgileri ========");
Console.WriteLine($"Etkinlik adı: {etkinlikAdi}");
Console.WriteLine($"Katılımcı sayısı: {katilimciSayisi}");
Console.WriteLine(
    $"Kişi başı etkinlik ücreti: {kisiBasiUcret:F2}"
);
Console.WriteLine($"Ara toplam ücret: {araToplamUcret:F2}");
Console.WriteLine($"Hizmet bedeli: {hizmetBedeli:F2}");
Console.WriteLine($"Toplam ücret: {toplamUcret:F2}");
Console.WriteLine(
    $"Kişi başı toplam ücret: {kisiBasiToplamUcret:F2}"
);