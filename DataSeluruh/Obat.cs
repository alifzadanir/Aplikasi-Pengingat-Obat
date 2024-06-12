using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeluruh
{
    public class Obat
    {
        public string NamaObat { get; set; }
        public string Satuan { get; set; }
        public string Jenis { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(NamaObat))
                throw new ArgumentException("Nama Obat tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(Satuan))
                throw new ArgumentException("Satuan tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(Jenis))
                throw new ArgumentException("Jenis tidak boleh kosong.");
        }
    }
}
