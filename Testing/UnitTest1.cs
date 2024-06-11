using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using GUI;
using DataSeluruh;
using System.Windows.Forms;

namespace Tests
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void TestRemoveSelectedObat()
        {
            // Arrange
            var form = new Form1();
            var obatList = new List<Obat>
            {
                new Obat { NamaObat = "Obat 1", Satuan = "Satuan 1", Jenis = "Jenis 1" },
                new Obat { NamaObat = "Obat 2", Satuan = "Satuan 2", Jenis = "Jenis 2" }
            };

            // Act
            form.RemoveSelectedObat(obatList, obatList.First());

            // Assert
            Assert.AreEqual(1, obatList.Count);
        }

        [Test]
        public void TestRemoveSelectedJadwal()
        {
            // Arrange
            var tambahjdForm = new tambahjd();
            var jadwalList = new List<Jadwal>
            {
                new Jadwal { NamaPenyakit = "Penyakit 1", NamaObat = "Obat 1", JumlahObat = 1, Frekuensi = "Frekuensi 1", WaktuKonsumsi = "Waktu 1" },
                new Jadwal { NamaPenyakit = "Penyakit 2", NamaObat = "Obat 2", JumlahObat = 2, Frekuensi = "Frekuensi 2", WaktuKonsumsi = "Waktu 2" }
            };

            // Act
            tambahjdForm.RemoveSelectedJadwal(jadwalList, jadwalList.First());

            // Assert
            Assert.AreEqual(1, jadwalList.Count);
        }

        [Test]
        public void TestSaveAndLoadObat()
        {
            // Arrange
            var data = Data.Instance;
            var obatList = new List<Obat>
            {
                new Obat { NamaObat = "Obat 1", Satuan = "Satuan 1", Jenis = "Jenis 1" },
                new Obat { NamaObat = "Obat 2", Satuan = "Satuan 2", Jenis = "Jenis 2" }
            };

            // Act
            data.SaveObat(obatList);
            var loadedObatList = data.LoadObat();

            // Assert
            Assert.IsNotNull(loadedObatList);
            Assert.AreEqual(obatList.Count, loadedObatList.Count);
            for (int i = 0; i < obatList.Count; i++)
            {
                Assert.AreEqual(obatList[i].NamaObat, loadedObatList[i].NamaObat);
                Assert.AreEqual(obatList[i].Satuan, loadedObatList[i].Satuan);
                Assert.AreEqual(obatList[i].Jenis, loadedObatList[i].Jenis);
            }
        }

        [Test]
        public void TestSaveAndLoadJadwal()
        {
            // Arrange
            var data = Data.Instance;
            var jadwalList = new List<Jadwal>
            {
                new Jadwal { NamaPenyakit = "Penyakit 1", NamaObat = "Obat 1", JumlahObat = 1, Frekuensi = "Frekuensi 1", WaktuKonsumsi = "Waktu 1" },
                new Jadwal { NamaPenyakit = "Penyakit 2", NamaObat = "Obat 2", JumlahObat = 2, Frekuensi = "Frekuensi 2", WaktuKonsumsi = "Waktu 2" }
            };

            // Act
            data.SaveJadwal(jadwalList);
            var loadedJadwalList = data.LoadJadwal();

            // Assert
            Assert.IsNotNull(loadedJadwalList);
            Assert.AreEqual(jadwalList.Count, loadedJadwalList.Count);
            for (int i = 0; i < jadwalList.Count; i++)
            {
                Assert.AreEqual(jadwalList[i].NamaPenyakit, loadedJadwalList[i].NamaPenyakit);
                Assert.AreEqual(jadwalList[i].NamaObat, loadedJadwalList[i].NamaObat);
                Assert.AreEqual(jadwalList[i].JumlahObat, loadedJadwalList[i].JumlahObat);
                Assert.AreEqual(jadwalList[i].Frekuensi, loadedJadwalList[i].Frekuensi);
                Assert.AreEqual(jadwalList[i].WaktuKonsumsi, loadedJadwalList[i].WaktuKonsumsi);
            }
        }
    }
}
