using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeluruh
{
    public class Jadwal
    {
        public string NamaPenyakit { get; set; }
        public string NamaObat { get; set; }
        public int JumlahObat { get; set; }
        public string Frekuensi { get; set; }
        public string WaktuKonsumsi { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(NamaPenyakit))
                throw new ArgumentException("Nama Penyakit tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(NamaObat))
                throw new ArgumentException("Nama Obat tidak boleh kosong.");
            if (JumlahObat <= 0)
                throw new ArgumentException("Jumlah Obat harus lebih dari 0.");
            if (string.IsNullOrWhiteSpace(Frekuensi))
                throw new ArgumentException("Frekuensi tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(WaktuKonsumsi))
                throw new ArgumentException("Waktu Konsumsi tidak boleh kosong.");
        }
    }
}
