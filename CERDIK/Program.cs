using System;
using System.ComponentModel.Design;
using System.Globalization;
using CERDIK;
using Menu;
using SimpanJadwal;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    // Table-driven design for menu options
    static Dictionary<string, Action<SmJadwal>> nakesMenuActions = new Dictionary<string, Action<SmJadwal>>()
    {
        { "1", smJadwal => { LihatJadwal(smJadwal); Menus.menuNakes(); HandleNakesMenu(smJadwal); } },
        { "2", smJadwal => { TambahkanJadwal(smJadwal); Menus.menuNakes(); HandleNakesMenu(smJadwal); } },
        { "3", smJadwal => { /* lihat device */ } },
        { "4", smJadwal => { /* daftarkan device */ } },
        { "5", smJadwal => { EditJadwal(smJadwal); Menus.menuNakes(); HandleNakesMenu(smJadwal); } }
    };

    public static void Main(string[] args)
    {
        SmJadwal smJadwal = new SmJadwal();
        string pilihMenu;
        string pilihRole;

        Menus.menuUtama();

        Console.WriteLine("Pilih role sesuai dengan kebutuhanmu!");
        pilihRole = Console.ReadLine();

        if (pilihRole == "1" || pilihRole == "2")
        {
            Menus.menuLogin();
        }

        Console.WriteLine("Pilih:");
        pilihMenu = Console.ReadLine();

        if (pilihMenu == "1" && pilihRole == "1")
        {
            Console.WriteLine("Login Sukses!");
            Menus.menuPasien();
        }
        else if (pilihMenu == "2" && pilihRole == "1")
        {
            Console.WriteLine("Daftar Sukses!");
            Menus.menuPasien();
        }
        else if (pilihMenu == "1" && pilihRole == "2")
        {
            Console.WriteLine("Login Sukses!");
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }
        else if (pilihMenu == "2" && pilihRole == "2")
        {
            Console.WriteLine("Daftar Sukses!");
            Menus.menuNakes();
            HandleNakesMenu(smJadwal);
        }

        Console.WriteLine("Pilihan:");
        pilihMenu = Console.ReadLine();
    }

    public static void HandleNakesMenu(SmJadwal smJadwal)
    {
        Console.WriteLine("Pilih opsi:");
        string pilihan = Console.ReadLine();

        if (nakesMenuActions.ContainsKey(pilihan))
        {
            nakesMenuActions[pilihan](smJadwal);
        }
        else
        {
            Console.WriteLine("Opsi tidak valid!");
        }
    }

    public static void TambahkanJadwal(SmJadwal smJadwal)
    {
        string penyakit;
        string obat;
        string dosis;

        do
        {
            Console.WriteLine("Masukkan nama penyakit:");
            penyakit = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(penyakit));

        do
        {
            Console.WriteLine("Masukkan nama obat:");
            obat = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(obat));

        do
        {
            Console.WriteLine("Masukkan dosis obat:");
            dosis = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(dosis));

        // Precondition
        System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(penyakit), "Precondition failed: penyakit must not be null or whitespace");
        System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(obat), "Precondition failed: obat must not be null or whitespace");
        System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(dosis), "Precondition failed: dosis must not be null or whitespace");

        smJadwal.TambahJadwal(new Jadwal(penyakit, obat, dosis));
        Console.WriteLine("Jadwal berhasil ditambahkan!");

        // Postcondition
        var addedJadwal = smJadwal.GetJadwalArray().FirstOrDefault(j => j.Penyakit == penyakit && j.Obat == obat && j.Dosis == dosis);
        System.Diagnostics.Debug.Assert(addedJadwal != null, "Postcondition failed: Jadwal should be added successfully");
    }

    public static void LihatJadwal(SmJadwal smJadwal)
    {
        var jadwalArray = smJadwal.GetJadwalArray();

        // Invariant
        System.Diagnostics.Debug.Assert(jadwalArray != null, "Invariant failed: jadwalArray should not be null");

        if (jadwalArray.Length > 0)
        {
            Console.WriteLine("Daftar Jadwal:");

            foreach (var jadwal in jadwalArray)
            {
                Console.WriteLine($"ID Jadwal: {jadwal.IdJadwal}");
                Console.WriteLine($"Penyakit: {jadwal.Penyakit}");
                Console.WriteLine($"Obat: {jadwal.Obat}");
                Console.WriteLine($"Dosis: {jadwal.Dosis}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Tidak ada jadwal yang tersedia.");
        }
    }

    public static void EditJadwal(SmJadwal smJadwal)
    {
        var jadwalArray = smJadwal.GetJadwalArray();

        // Invariant
        System.Diagnostics.Debug.Assert(jadwalArray != null, "Invariant failed: jadwalArray should not be null");

        if (jadwalArray.Length > 0)
        {
            Console.WriteLine("Daftar Jadwal:");

            for (int i = 0; i < jadwalArray.Length; i++)
            {
                Console.WriteLine($"ID Jadwal: {jadwalArray[i].IdJadwal}");
                Console.WriteLine($"Penyakit: {jadwalArray[i].Penyakit}");
                Console.WriteLine($"Obat: {jadwalArray[i].Obat}");
                Console.WriteLine($"Dosis: {jadwalArray[i].Dosis}");
                Console.WriteLine();
            }

            // Meminta input untuk memilih jadwal yang akan diedit
            Console.WriteLine("Masukkan ID Jadwal yang ingin diedit:");
            int idJadwal;
            while (!int.TryParse(Console.ReadLine(), out idJadwal))
            {
                Console.WriteLine("Input tidak valid. Masukkan ID Jadwal dengan angka:");
            }

            // Mencari jadwal yang sesuai dengan ID yang dimasukkan pengguna
            Jadwal jadwalToEdit = jadwalArray.FirstOrDefault(j => j.IdJadwal == idJadwal);

            if (jadwalToEdit != null)
            {
                // Meminta input untuk informasi jadwal yang diperbarui
                Console.WriteLine("Masukkan informasi baru:");

                string newPenyakit;
                string newObat;
                string newDosis;

                do
                {
                    Console.WriteLine("Masukkan nama penyakit baru:");
                    newPenyakit = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(newPenyakit));

                do
                {
                    Console.WriteLine("Masukkan nama obat baru:");
                    newObat = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(newObat));

                do
                {
                    Console.WriteLine("Masukkan dosis obat baru:");
                    newDosis = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(newDosis));

                // Precondition
                System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(newPenyakit), "Precondition failed: newPenyakit must not be null or whitespace");
                System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(newObat), "Precondition failed: newObat must not be null or whitespace");
                System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(newDosis), "Precondition failed: newDosis must not be null or whitespace");

                // Mengupdate informasi jadwal
                jadwalToEdit.Penyakit = newPenyakit;
                jadwalToEdit.Obat = newObat;
                jadwalToEdit.Dosis = newDosis;

                Console.WriteLine("Jadwal berhasil diperbarui!");

                // Postcondition
                System.Diagnostics.Debug.Assert(jadwalToEdit.Penyakit == newPenyakit, "Postcondition failed: Penyakit should be updated");
                System.Diagnostics.Debug.Assert(jadwalToEdit.Obat == newObat, "Postcondition failed: Obat should be updated");
                System.Diagnostics.Debug.Assert(jadwalToEdit.Dosis == newDosis, "Postcondition failed: Dosis should be updated");
            }
            else
            {
                Console.WriteLine("Jadwal tidak ditemukan!");
            }
        }
        else
        {
            Console.WriteLine("Tidak ada jadwal yang tersedia.");
        }
    }
}
