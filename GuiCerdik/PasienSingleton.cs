using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiCerdik
{
    public class PasienSingleton
    {
        private static List<Pasien> DataAkunPasien;

        private static PasienSingleton _instance;

        private PasienSingleton()
        {
            DataAkunPasien = new List<Pasien>();
        }

        public static PasienSingleton GetDataSingleton()
        {
            if(_instance == null)
            {
                _instance = new PasienSingleton();
            }
            return _instance;
        }

        public List<Pasien> GetDataPasien()
        {
            return DataAkunPasien;
        }

        public void AddDataPasien(Pasien inputPasien)
        {
            DataAkunPasien.Add(inputPasien);
        }

        public bool SearchDataPasien(string usernamePasien, string passwordPasien)
        {
            bool isInputValid = false;

            for(int i = 0; i < DataAkunPasien.Count; i++)
            {
                if (DataAkunPasien[i].Username == usernamePasien && DataAkunPasien[i].Password == passwordPasien)
                {
                    isInputValid = true;
                    return isInputValid;
                }
            }

            return isInputValid;
        }
    }
}
