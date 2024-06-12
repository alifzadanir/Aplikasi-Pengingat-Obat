using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GUI
{
        public static class Data
        {
            private static string filePathObat = "obat.json";
            private static string filePathJadwal = "jadwal.json";

            // Metode umum untuk menyimpan data ke file JSON
            public static void SaveData<T>(List<T> data, string filePath)
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }

            // Metode umum untuk memuat data dari file JSON
            public static List<T> LoadData<T>(string filePath)
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<T>>(jsonData);
                }
                return new List<T>();
            }

            // Metode khusus untuk menyimpan data obat
            public static void SaveObat(List<Obat> obatList)
            {
                SaveData(obatList, filePathObat);
            }

            // Metode khusus untuk memuat data obat
            public static List<Obat> LoadObat()
            {
                return LoadData<Obat>(filePathObat);
            }

            // Metode khusus untuk menyimpan data jadwal
            public static void SaveJadwal(List<Jadwal> jadwalList)
            {
                SaveData(jadwalList, filePathJadwal);
            }

            // Metode khusus untuk memuat data jadwal
            public static List<Jadwal> LoadJadwal()
            {
                return LoadData<Jadwal>(filePathJadwal);
            }
        }
    }
