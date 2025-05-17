using System;
using System.Collections.Generic;

class Mahasiswa
{
    public int NIM { get; set; }
    public string Nama { get; set; }
    public string Jurusan { get; set; }

    public Mahasiswa(int nim, string nama, string jurusan)
    {
        NIM = nim;
        Nama = nama;
        Jurusan = jurusan;
    }
}

class ManajemenMahasiswa
{
    private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

    static void Main(string[] args)
    {
        while (true)
        {
            TampilkanMenu();
            string masukan = Console.ReadLine();
            if (!int.TryParse(masukan, out int pilihan))
            {
                Console.WriteLine("Pilihan tidak valid!");
                continue;
            }

            switch (pilihan)
            {
                case 1:
                    TambahMahasiswa();
                    break;
                case 2:
                    LihatMahasiswa();
                    break;
                case 3:
                    UbahMahasiswa();
                    break;
                case 4:
                    HapusMahasiswa();
                    break;
                case 5:
                    Console.WriteLine("Terima kasih telah menggunakan program!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }
        }
    }

    private static void TampilkanMenu()
    {
        Console.WriteLine("\n=== Sistem Manajemen Mahasiswa ===");
        Console.WriteLine("1. Tambah Mahasiswa");
        Console.WriteLine("2. Lihat Mahasiswa");
        Console.WriteLine("3. Update Mahasiswa");
        Console.WriteLine("4. Hapus Mahasiswa");
        Console.WriteLine("5. Keluar");
        Console.Write("Pilih menu (1-5): ");
    }

    private static void TambahMahasiswa()
    {
        Console.Write("Masukkan NIM: ");
        if (!int.TryParse(Console.ReadLine(), out int nim))
        {
            Console.WriteLine("-- NIM harus berupa angka! --");
            return;
        }

        if (daftarMahasiswa.Exists(m => m.NIM == nim))
        {
            Console.WriteLine("-- NIM sudah terdaftar! --");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan Jurusan: ");
        string jurusan = Console.ReadLine();

        daftarMahasiswa.Add(new Mahasiswa(nim, nama, jurusan));
        Console.WriteLine("Data mahasiswa berhasil ditambahkan!");
    }

    private static void LihatMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        Console.WriteLine("\nDaftar Mahasiswa:");
        Console.WriteLine("-----------------");
        for (int i = 0; i < daftarMahasiswa.Count; i++)
        {
            Console.WriteLine($"Mahasiswa {i + 1}");
            Console.WriteLine($"NIM: {daftarMahasiswa[i].NIM}");
            Console.WriteLine($"Nama: {daftarMahasiswa[i].Nama}");
            Console.WriteLine($"Jurusan: {daftarMahasiswa[i].Jurusan}");
            Console.WriteLine("-----------------");
        }
    }

    private static void UbahMahasiswa()
    {
        Console.Write("Masukkan NIM mahasiswa yang akan diupdate: ");
        if (!int.TryParse(Console.ReadLine(), out int nim))
        {
            Console.WriteLine("-- NIM harus berupa angka! --");
            return;
        }

        Mahasiswa mahasiswa = daftarMahasiswa.Find(m => m.NIM == nim);
        if (mahasiswa == null)
        {
            Console.WriteLine("-- NIM tidak ditemukan! --");
            return;
        }

        Console.Write("Masukkan Nama baru: ");
        string namaBaru = Console.ReadLine();
        Console.Write("Masukkan Jurusan baru: ");
        string jurusanBaru = Console.ReadLine();

        mahasiswa.Nama = namaBaru;
        mahasiswa.Jurusan = jurusanBaru;
        Console.WriteLine("Data mahasiswa berhasil diupdate!");
    }

    private static void HapusMahasiswa()
    {
        Console.Write("Masukkan NIM mahasiswa yang akan dihapus: ");
        if (!int.TryParse(Console.ReadLine(), out int nim))
        {
            Console.WriteLine("-- NIM harus berupa angka! --");
            return;
        }

        Mahasiswa mahasiswa = daftarMahasiswa.Find(m => m.NIM == nim);
        if (mahasiswa == null)
        {
            Console.WriteLine("-- NIM tidak ditemukan! --");
            return;
        }

        daftarMahasiswa.Remove(mahasiswa);
        Console.WriteLine("Data mahasiswa berhasil dihapus!");
    }
}