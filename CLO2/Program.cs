//Belum Generic

using System.ComponentModel.Design;
using TUBESKPL;


public class Program
{
    public static void Main(string[] args)
    {
        List<DevicesAddConfig> devices = new List<DevicesAddConfig>();
        string pilihMenu;
        string pilihRole;
        Menu.Menus.menuUtama();

        Console.WriteLine("Pilih role sesuai dengan kebutuhanmu!");
        pilihRole = Console.ReadLine();
        if (pilihRole == "1" || pilihRole == "2")
        {
            Menu.Menus.menuLogin();
        }

        Console.WriteLine("Pilih:");
        pilihMenu = Console.ReadLine();
        if (pilihMenu == "1" && pilihRole == "1")
        {
            Console.WriteLine("Login Sukses!");
            Menu.Menus.menuPasien();
        } else if (pilihMenu == "2" && pilihRole == "1")
        {
            Console.WriteLine("Daftar Sukses!");
            Menu.Menus.menuPasien();
        } else if (pilihMenu == "1" && pilihRole == "2")
        {
            Console.WriteLine("Login Sukses!");
            Menu.Menus.menuNakes();
        } else if (pilihMenu == "2" && pilihRole == "2")
        {
            Console.WriteLine("Daftar Sukses!");
            Menu.Menus.menuNakes();
        }
        Console.WriteLine("Pilihan:");
        pilihMenu = Console.ReadLine();
        if (pilihMenu == "3")
        {
            string namaDevice = "", os = "", merekDevice = "";

            //Defensive//Design By Contract
            try
            {
                // Ask user for device configuration input
                Console.WriteLine("Masukkan nama device:");
                namaDevice = Console.ReadLine().Trim(); // Trim to remove leading/trailing whitespaces

                Console.WriteLine("Masukkan sistem operasi device:");
                os = Console.ReadLine().Trim();

                Console.WriteLine("Masukkan merek device:");
                merekDevice = Console.ReadLine().Trim();

                // Check if any of the inputs are blank
                if (string.IsNullOrEmpty(namaDevice) || string.IsNullOrEmpty(os) || string.IsNullOrEmpty(merekDevice))
                {
                    throw new Exception("Input tidak boleh kosong.");
                }

                // Create DevicesConfig object with user input
                DevicesAddConfig configBaru = new DevicesAddConfig(namaDevice, os, merekDevice);
                DevicesConfig deviceConfig = new DevicesConfig();
                deviceConfig.config = configBaru;

                // Create Devices object and activate trigger
                Devices laptop = new Devices(deviceConfig);
                laptop.ActivateTrigger(Trigger.Login);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

        
  }
