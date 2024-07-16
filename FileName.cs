using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Mahasiswa> GetMahasiswaByNIMAsync(string nim)
    {
        string wsKey = "4LL4h"; 
        string url = $"https://riset-akademik.site/WISUDA/?nim={nim}&wskey={wsKey}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        // Parsing JSON response
        var json = JObject.Parse(responseBody);
        var mahasiswaJson = json["data"]["wisudawan"][0]; 

        Mahasiswa mahasiswa = new Mahasiswa
        {
            NIM = (string)mahasiswaJson["nim"],
            Nama = (string)mahasiswaJson["nama"],
            Fakultas = (string)mahasiswaJson["fakultas"],
            Jurusan = (string)mahasiswaJson["jurusan"],
            IPK = (string)mahasiswaJson["ipk"],
            Predikat = (string)mahasiswaJson["predikat"],
            TglSidang = (string)mahasiswaJson["tgl_sidang"],
            Judul = (string)mahasiswaJson["judul"],
            Pembimbing1 = (string)mahasiswaJson["pembimbing1"],
            Pembimbing2 = (string)mahasiswaJson["pembimbing2"],
            GelarS1 = (string)mahasiswaJson["gelar_s1"],
            Email = (string)mahasiswaJson["email"]
        };

        return mahasiswa;
    }
}
