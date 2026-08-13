Console.Write("Kullanıcı adınızı giriniz: ");
string? kullaniciAdi = Console.ReadLine();

Console.Write("Hangi şehire seyahat etmek istiyorsunuz? ");
string? sehir = Console.ReadLine();

Console.Write("Kaç gün seyahat edeceksiniz? ");
int gun = Convert.ToInt32(Console.ReadLine());

Console.Write("Günlük konaklama ücreti ne kadar? ");
decimal konaklamaUcreti = Convert.ToDecimal(Console.ReadLine());

Console.Write("Günlük yemek ücreti ne kadar? ");
decimal yemekUcreti = Convert.ToDecimal(Console.ReadLine());

decimal toplamKonaklamaUcreti = konaklamaUcreti * gun;
decimal toplamYemekUcreti = yemekUcreti * gun;
decimal toplamUcret = toplamKonaklamaUcreti + toplamYemekUcreti;

Console.WriteLine();
Console.WriteLine($"========Seyahat Bilgileri========");
Console.WriteLine($"Kullanıcı Adı: {kullaniciAdi}");
Console.WriteLine($"seyahat Edilecek Şehir: {sehir}");
Console.WriteLine($"seyahat Süresi: {gun} gün");
Console.WriteLine($"Toplam konaklama ücreti: {toplamKonaklamaUcreti:F2}");
Console.WriteLine($"Toplam yemek ücreti: {toplamYemekUcreti:F2}");
Console.WriteLine($"Toplam ücret: {toplamUcret:F2}");
