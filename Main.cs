using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Masukkan NIM: ");
        string nim = Console.ReadLine();

        ApiClient apiClient = new ApiClient();
        try
        {
            Mahasiswa mahasiswa = await apiClient.GetMahasiswaByNIMAsync(nim);
            if (mahasiswa != null)
            {
                Console.WriteLine("Data Mahasiswa:");
                Console.WriteLine($"NIM: {mahasiswa.NIM}");
                Console.WriteLine($"Nama: {mahasiswa.Nama}");
                Console.WriteLine($"Fakultas: {mahasiswa.Fakultas}");
                Console.WriteLine($"Jurusan: {mahasiswa.Jurusan}");
                Console.WriteLine($"IPK: {mahasiswa.IPK}");
                Console.WriteLine($"Predikat: {mahasiswa.Predikat}");
                Console.WriteLine($"Tanggal Sidang: {mahasiswa.TglSidang}");
                Console.WriteLine($"Judul: {mahasiswa.Judul}");
                Console.WriteLine($"Pembimbing 1: {mahasiswa.Pembimbing1}");
                Console.WriteLine($"Pembimbing 2: {mahasiswa.Pembimbing2}");
                Console.WriteLine($"Gelar S1: {mahasiswa.GelarS1}");
                Console.WriteLine($"Email: {mahasiswa.Email}");
            }
            else
            {
                Console.WriteLine("Mahasiswa dengan NIM tersebut tidak ditemukan.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }
    }
}
