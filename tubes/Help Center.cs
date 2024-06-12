using MongoDB.Driver.Core.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace CERDIK;
public class HelpCenter
{
    public int ID { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
    public string ConnectionString { get; set; }

    [ContractInvariantMethod]
    protected void ObjectInvariant()
    {
        Contract.Invariant(ID >= 0);
        Contract.Invariant(!string.IsNullOrEmpty(Question));
        Contract.Invariant(!string.IsNullOrEmpty(Answer));
        Contract.Invariant(!string.IsNullOrEmpty(Category));
        Contract.Invariant(!string.IsNullOrEmpty(ConnectionString));
    }
    public List<HelpCenter> GetHelpCenterData()
    {
        Contract.Ensures(Contract.Result<List<HelpCenter>>() != null);
        List<HelpCenter> helpCenterList = new List<HelpCenter>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HelpCenter", connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                HelpCenter helpCenter = new HelpCenter();
                helpCenter.ID = reader.GetInt32(0);
                helpCenter.Question = reader.GetString(1);
                helpCenter.Answer = reader.GetString(2);
                helpCenter.Category = reader.GetString(3);

                helpCenterList.Add(helpCenter);
            }
        }

        return helpCenterList;
    }

    public void DisplayHelpCenter()
    {
        List<HelpCenter> helpCenterList = GetHelpCenterData();

        Console.WriteLine("Selamat Datang Di Help Center!");
        Console.WriteLine("---------------------------");

        var helpCategories = helpCenterList.Select(x => x.Category).Distinct();

        foreach (var category in helpCategories)
        {
            Console.WriteLine("\nKategori: " + category);

            var helpQuestions = helpCenterList.Where(x => x.Category == category);

            foreach (var helpQuestion in helpQuestions)
            {
                Console.WriteLine("\nPertanyaan: " + helpQuestion.Question);
                Console.WriteLine("Jawaban: " + helpQuestion.Answer);
            }
        }
    }

    public void SearchHelpCenter()
    {
        Console.WriteLine("Masukkan Keyword:");
        string searchQuery = Console.ReadLine();

        List<HelpCenter> helpCenterList = GetHelpCenterData();

        var searchResults = helpCenterList.Where(x => x.Question.Contains(searchQuery) || x.Answer.Contains(searchQuery));

        if (searchResults.Count() == 0)
        {
            Console.WriteLine("Tidak ada hasil ditemukan.");
        }
        else
        {
            Console.WriteLine("Search Results:");

            foreach (var result in searchResults)
            {
                Console.WriteLine("\nPertanyaan: " + result.Question);
                Console.WriteLine("Jawaban: " + result.Answer);
            }
        }
    }

    public void AddHelpCenterEntry()
    {
        Console.WriteLine("Masukkan Pertanyaan:");
        string question = Console.ReadLine();

        Console.WriteLine("Masukkan Jawaban:");
        string answer = Console.ReadLine();

        Console.WriteLine("Masukkan Kategori:");
        string category = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO HelpCenter (Pertanyaan, Jawaban, Kategori) VALUES (@Pertanyaan, @Jawaban, @Kategori)", connection);

            command.Parameters.AddWithValue("@Pertanyaan", question);
            command.Parameters.AddWithValue("@Jawaban", answer);
            command.Parameters.AddWithValue("@Kategori", category);

            command.ExecuteNonQuery();
        }

        Console.WriteLine("Pertanyaan dan Jawaban telah terinput di Database.");
    }

    public void AccessHelpCenter()
    {
        Console.WriteLine("Selamat Datang di Help Center!");
        Console.WriteLine("---------------------------");
        Console.WriteLine("1. Tampilkan Help Center");
        Console.WriteLine("2. Cari Help Center");
        Console.WriteLine("3. Tambahkan Bantuan Center Entry");
        Console.WriteLine("4. Exit");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                DisplayHelpCenter();
                break;
            case 2:
                SearchHelpCenter();
                break;
            case 3:
                AddHelpCenterEntry();
                break;
            case 4:
                Console.WriteLine("Keluar dari Help Center...");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}

