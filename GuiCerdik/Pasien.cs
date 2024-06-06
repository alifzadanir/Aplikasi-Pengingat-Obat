using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiCerdik
{
    public class Pasien
    {
        public string Username;
        public string NamaLengkap;
        public string Password;
        public string Email;
        public string TanggalLahir;
        public string Gender;

        public Pasien(string user, string nama, string pass, string email, string lahir, string gender)
        {
            Username = user;
            NamaLengkap = nama;
            Password = pass;
            Email = email;
            TanggalLahir = lahir;
            Gender = gender;
        }

        public Pasien() { }
    }
}
