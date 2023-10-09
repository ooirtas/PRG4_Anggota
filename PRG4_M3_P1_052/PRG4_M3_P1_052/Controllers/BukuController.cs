using Microsoft.AspNetCore.Mvc;
using PRG4_M3_P1_052.Models;

namespace PRG4_M3_P1_052.Controllers
{
    public class BukuController : Controller
    {
        private static List<Buku> bukus = InitializeData();

        private static List<Buku> InitializeData()
        {
            List<Buku> initialData = new List<Buku>
            {
                new Buku
                {
                    id = 1,
                    judul = "Boyolali",
                    penulis = "Roni Prasetyo",
                    penerbit = "ABC Publications",
                    issn = "1234-5678",
                    tahun = 2020,
                    status = 1
                },
                new Buku
                {
                    id = 2,
                    judul = "Indonesiaku",
                    penulis = "Zulfikar",
                    penerbit = "XYZ Publications",
                    issn = "5678-1234",
                    tahun = 2018,
                    status = 1
                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Buku> bukuList = bukus.ToList();
            return View(bukuList);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Buku buku)
        {
            if(ModelState.IsValid) {
                int new_id = 1;
                while(bukus.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                buku.id = new_id;
                buku.status = 1;
                
                bukus.Add(buku);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(buku);
        }

        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus buku." };

            try
            {
                var buku = bukus.FirstOrDefault(b => b.id == id);
                if (buku != null)
                {
                    bukus.Remove(buku);
                    response = new { success = true, message = "Data berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Buku tidak ditemukan" };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Buku buku = bukus.FirstOrDefault(b => b.id == id);

            if(buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        [HttpPost]

        public IActionResult Edit(Buku buku)
        {
            if(ModelState.IsValid){
                Buku newBuku = bukus.FirstOrDefault(b => b.id == buku.id);

                if (buku == null)
                {
                    return NotFound();
                }

                newBuku.judul = buku.judul;
                newBuku.penulis = buku.penulis;
                newBuku.penerbit = buku.penerbit;
                newBuku.issn = buku.issn;
                newBuku.tahun = buku.tahun;

                TempData["SuccessMessage"] = "Buku berhasil diupdate.";
                return RedirectToAction("Index");
            }
            return View(buku);
        }
    }
}
