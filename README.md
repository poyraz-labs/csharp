# csharp

Poyraz is learning C#.

Bu repo, C# öğrenirken yaptığım küçük console uygulamalarını ve her derste öğrendiğim konuları topladığım çalışma alanı. Her proje küçük bir problemi çözüyor; amaç sadece kod yazmak değil, değişkenlerden metotlara kadar temel programlama mantığını adım adım oturtmak.

## Öğrenme Yolculuğu

| Stage | Ana konu | Öğrendiklerim |
| --- | --- | --- |
| Stage 1 | Temel giriş/çıkış ve hesaplama | `Console.Write`, `Console.ReadLine`, değişkenler, string interpolation, `int`, `decimal`, basit matematiksel işlemler |
| Stage 2 | Karar yapıları | `if`, `else if`, `else`, `switch`, karşılaştırma operatörleri, mantıksal operatörler, erken çıkış için `return` |
| Stage 3 | Döngüler | `while`, `do-while`, `for`, `continue`, `break`, sayaç mantığı, toplam alma, giriş doğrulama |
| Stage 4 | Metotlar | Metot tanımlama, parametre kullanma, geriye değer döndürme, `void` metotlar, iş mantığını küçük parçalara ayırma |

## Mini Projeler

| Proje | Klasör | Ne yapıyor? | Öne çıkan konular |
| --- | --- | --- | --- |
| İlk Program | `stage-1/Ders01.IlkProgram` | Kullanıcıdan ad, şehir ve C# öğrenme sebebini alıp özet mesaj üretir. | `string`, kullanıcı girdisi, çıktı yazdırma |
| Seyahat Fiyat Hesaplama | `stage-1/Ders02.FiyatHesaplama` | Gün sayısına göre konaklama ve yemek maliyetini hesaplar. | `int`, `decimal`, çarpma, toplam alma |
| Etkinlik Maliyet Hesaplama | `stage-1/Ders03.EtkinlikMaliyetHesaplama` | Katılımcı sayısı, kişi başı ücret ve hizmet bedeliyle etkinlik maliyeti çıkarır. | `TryParse`, doğrulama, yüzde hesabı |
| Sinema Bileti Fiyatlandırma | `stage-2/Ders01.SinemaBiletiFiyatlandirma` | Yaş ve öğrencilik durumuna göre bilet indirimi hesaplar. | `if/else`, koşullu indirim, `bool` |
| Kargo Ücreti Hesaplayıcı | `stage-2/Ders02.KargoUcretiHesaplayici` | Ağırlık, teslimat türü ve üyeliğe göre kargo ücretini hesaplar. | `switch`, üyelik indirimi, aralık kontrolü |
| Araç Kiralama Sistemi | `stage-2/Ders03.AracKiralamaSistemi` | Araç türü, yaş, ehliyet süresi, indirim ve sigortaya göre kiralama tutarı hesaplar. | `switch expression`, çoklu koşullar, sabit değerler |
| Günlük Harcama Takipçisi | `stage-3/Ders01.GunlukHarcamaTakipcisi` | Günlük bütçe ve harcamaları takip edip toplam, ortalama ve kalan bütçeyi gösterir. | `while`, `break`, `continue`, sayaçlar |
| ATM Simülasyonu | `stage-3/Ders02.ATM` | Bakiye görüntüleme, para yatırma, para çekme ve işlem özeti sunar. | `do-while`, `switch`, başarılı işlem sayaçları |
| Sayı Analiz Merkezi | `stage-3/Ders03.Hesaplayici` | 1 ile üst sınır arasındaki sayıları analiz eder ve çarpım tablosu üretir. | `for`, `%`, tek/çift ayrımı, bölünebilme kontrolü |
| ATM With Methods | `stage-4/Ders01.ATMWithMethods` | ATM simülasyonunu metotlara bölerek daha okunabilir hale getirir. | `static` metotlar, parametreler, dönüş değerleri, sorumluluk ayırma |

## Çalıştırma

Her mini proje ayrı bir console uygulamasıdır. Örneğin:

```bash
dotnet run --project stage-4/Ders01.ATMWithMethods/Ders01.ATMWithMethods.csproj
```

Başka bir dersi çalıştırmak için proje yolunu değiştirmen yeterli:

```bash
dotnet run --project stage-3/Ders03.Hesaplayici/Ders03.Hesaplayici.csproj
```

## Hedef

Bu repo, C# temellerini küçük ve anlaşılır projelerle pekiştirmek için büyüyor. Her stage yeni bir programlama fikrine odaklanıyor; önce problemi çözüyorum, sonra aynı fikri daha temiz ve daha düzenli yazmayı öğreniyorum.
