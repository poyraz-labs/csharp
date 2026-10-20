using Microsoft.Data.Sqlite;
using System.Globalization;

const string connectionString = "Data Source=harcamalar.db";

using var connection = new SqliteConnection(connectionString);

connection.Open();

const string createTableSql = """
    CREATE TABLE IF NOT EXISTS Harcamalar
    (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Aciklama TEXT NOT NULL,
        Kategori TEXT NOT NULL,
        Tutar REAL NOT NULL,
        Tarih TEXT NOT NULL
    );
    """;

using var createTableCommand = connection.CreateCommand();

createTableCommand.CommandText = createTableSql;
createTableCommand.ExecuteNonQuery();

bool uygulamaDevamEdiyor = true;

while (uygulamaDevamEdiyor)
{
    Console.WriteLine();
    Console.WriteLine("Kişisel Harcama Takip Uygulaması");
    Console.WriteLine("=================================");
    Console.WriteLine("1 - Harcama ekle");
    Console.WriteLine("2 - Harcamaları listele");
    Console.WriteLine("3 - Çıkış yap");
    Console.Write("Seçiminiz: ");

    string secim = Console.ReadLine() ?? "";

    switch (secim)
    {
        case "1":
            HarcamaEkle();
            break;

        case "2":
            HarcamalariListele();
            break;

        case "3":
            uygulamaDevamEdiyor = false;
            Console.WriteLine("Uygulamadan çıkılıyor...");
            break;

        default:
            Console.WriteLine("Geçersiz seçim yaptınız.");
            break;
    }
}

void HarcamaEkle()
{
    Console.Write("Harcama açıklaması: ");
    string aciklama = Console.ReadLine() ?? "";

    Console.Write("Kategori: ");
    string kategori = Console.ReadLine() ?? "";

    decimal tutar;

    while (true)
    {
        Console.Write("Tutar: ");
        string tutarMetni = Console.ReadLine() ?? "";

        bool tutarGecerliMi = decimal.TryParse(
            tutarMetni,
            NumberStyles.Number,
            CultureInfo.CurrentCulture,
            out tutar);

        if (tutarGecerliMi && tutar > 0)
        {
            break;
        }

        Console.WriteLine("Geçersiz tutar. 0'dan büyük bir sayı girin.");
    }

    DateTime tarih = DateTime.Now;

    const string insertExpenseSql = """
        INSERT INTO Harcamalar (Aciklama, Kategori, Tutar, Tarih)
        VALUES ($aciklama, $kategori, $tutar, $tarih);
        """;

    using var insertExpenseCommand = connection.CreateCommand();

    insertExpenseCommand.CommandText = insertExpenseSql;

    insertExpenseCommand.Parameters.AddWithValue("$aciklama", aciklama);
    insertExpenseCommand.Parameters.AddWithValue("$kategori", kategori);
    insertExpenseCommand.Parameters.AddWithValue("$tutar", tutar);
    insertExpenseCommand.Parameters.AddWithValue("$tarih", tarih);

    insertExpenseCommand.ExecuteNonQuery();

    Console.WriteLine("Harcama başarıyla kaydedildi.");
}

void HarcamalariListele()
{
    Console.WriteLine();
    Console.WriteLine("Kayıtlı Harcamalar");
    Console.WriteLine("===================");

    const string listExpensesSql = """
        SELECT Id, Aciklama, Kategori, Tutar, Tarih
        FROM Harcamalar
        ORDER BY Tarih DESC;
        """;

    using var listExpensesCommand = connection.CreateCommand();

    listExpensesCommand.CommandText = listExpensesSql;

    using var reader = listExpensesCommand.ExecuteReader();

    bool kayitVarMi = false;

    while (reader.Read())
    {
        kayitVarMi = true;

        int id = reader.GetInt32(0);
        string kayitliAciklama = reader.GetString(1);
        string kayitliKategori = reader.GetString(2);
        decimal kayitliTutar = reader.GetDecimal(3);
        string kayitliTarih = reader.GetString(4);

        Console.WriteLine(
            $"{id} - {kayitliAciklama} | {kayitliKategori} | {kayitliTutar:C} | {kayitliTarih}");
    }

    if (!kayitVarMi)
    {
        Console.WriteLine("Henüz kayıtlı harcama bulunmuyor.");
    }
}