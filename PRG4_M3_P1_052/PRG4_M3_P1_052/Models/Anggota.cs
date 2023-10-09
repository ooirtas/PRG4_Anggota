using System.ComponentModel.DataAnnotations;

namespace PRG4_M3_P1_052.Models
{
    public class Anggota
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama Maksimal 30 karakter")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Umur wajib diisi.")]
        [Range(0, 100, ErrorMessage = "Umur tidak valid.")]
        public int umur { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Alamat Maksimal 50 karakter")]
        public string alamat { get; set; }

        [Required(ErrorMessage = "Nomor HP wajib diisi.")]
        [RegularExpression(@"^\d{10,13}$", ErrorMessage = "Nomor HP harus berisi antara 10 hingga 13 angka.")]
        public string nohp { get; set; }


    }
}
