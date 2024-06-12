using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataSeluruh;

public class Data
{
    private static readonly Lazy<Data> instance = new Lazy<Data>(() => new Data());

    private string filePathObat = "obat.json";
    private string filePathJadwal = "jadwal.json";

    private Data() { }

    public static Data Instance => instance.Value;

    // General method to save data to a JSON file
    public void SaveData<T>(List<T> data, string filePath)
    {
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }

    // General method to load data from a JSON file
    public List<T> LoadData<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
        return new List<T>();
    }

    // Specific method to save drug data
    public void SaveObat(List<Obat> obatList)
    {
        SaveData(obatList, filePathObat);
    }

    // Specific method to load drug data
    public List<Obat> LoadObat()
    {
        return LoadData<Obat>(filePathObat);
    }

    // Specific method to save schedule data
    public void SaveJadwal(List<Jadwal> jadwalList)
    {
        SaveData(jadwalList, filePathJadwal);
    }

    // Specific method to load schedule data
    public List<Jadwal> LoadJadwal()
    {
        return LoadData<Jadwal>(filePathJadwal);
    }
}
