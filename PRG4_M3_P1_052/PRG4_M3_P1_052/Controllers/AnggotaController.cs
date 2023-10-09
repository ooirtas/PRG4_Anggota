using Microsoft.AspNetCore.Mvc;
using PRG4_M3_P1_052.Models;

namespace PRG4_M3_P1_052.Controllers
{
    public class AnggotaController : Controller
    {
        private static List<Anggota> anggotas = InitializeData();

        private static List<Anggota> InitializeData()
        {
            List<Anggota> initialData = new List<Anggota>
                {

                };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Anggota> anggotaList = anggotas.ToList();
            return View(anggotaList);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;
                while (anggotas.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                anggota.id = new_id;

                anggotas.Add(anggota);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }

        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus anggota." };

            try
            {
                var anggota = anggotas.FirstOrDefault(b => b.id == id);
                if (anggota != null)
                {
                    anggotas.Remove(anggota);
                    response = new { success = true, message = "Data berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Anggota tidak ditemukan" };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Anggota anggota = anggotas.FirstOrDefault(b => b.id == id);

            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        [HttpPost]

        public IActionResult Edit(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                Anggota newAnggota = anggotas.FirstOrDefault(b => b.id == anggota.id);

                if (anggota == null)
                {
                    return NotFound();
                }

                newAnggota.nama = anggota.nama;
                newAnggota.umur = anggota.umur;
                newAnggota.alamat = anggota.alamat;
                newAnggota.nohp = anggota.nohp;

                TempData["SuccessMessage"] = "Buku berhasil diupdate.";
                return RedirectToAction("Index");
            }
            return View(anggota);
        }
    }
}
