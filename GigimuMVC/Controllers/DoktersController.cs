using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using GigimuDTO;
using Gigimu.BLL;
using Gigimu.InterfaceBLL;
using GigimuMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GigimuMVC.Controllers
{
    public class DoktersController : Controller
    {
        private readonly IDokterBLL _dokterBLL;
        private readonly IJadwalBLL _jadwalBLL;
        private readonly IKonsultasiBLL _konsultasiBLL;
        private readonly IPasienBLL _pasienBLL;
        public DoktersController(IDokterBLL dokterBLL, IJadwalBLL jadwalBLL, IKonsultasiBLL konsultasiBLL, IPasienBLL pasienBLL)
        {
            _dokterBLL = dokterBLL;
            _jadwalBLL = jadwalBLL;
            _konsultasiBLL = konsultasiBLL;
            _pasienBLL = pasienBLL;
        }
        // GET: DoktersController
        public ActionResult Index()
        {
            var models = _dokterBLL.GetAll();
            return View(models);
        }

        // GET: DoktersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoktersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoktersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoktersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoktersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoktersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoktersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDokterDTO loginDokterDto)
        {
            try
            {
                var dokterDto = _dokterBLL.LoginMVC(loginDokterDto);

                var dokterDtoSerialize = JsonSerializer.Serialize(dokterDto);
                HttpContext.Session.SetString("user", dokterDtoSerialize);

                return RedirectToAction("Index", "Dokters");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }
        public IActionResult addDokter()
        {
            var userDto = JsonSerializer.Deserialize<DokterDTO>(HttpContext.Session.GetString("user"));
            var userRoles = userDto.Roles;
            var access = 0;
            foreach (var role in userRoles)
            {
                if (role.RoleID == 1)
                {
                    access = 1;
                }
            }
            if (access == 1)
            {
                var models = _dokterBLL.GetAll();
                return View(models);
            }
            else
            {
                return RedirectToAction("Index", "Dokters");
            }
        }
        [HttpPost]
        public IActionResult addDokter(AddDokterDTO addDokterDTO)
        {
            try
            {
                _dokterBLL.Insert(addDokterDTO);
                //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            }
            catch (Exception ex)
            {

                //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("addDokter", "Dokters");
        }
        public IActionResult addRole()
        {
            ViewBag.user = _dokterBLL.GetAll();
            ViewBag.role = _dokterBLL.GetAllRoles();
            return View();
        }
        [HttpPost]
        public IActionResult addRole(int dokterID, int roleID)
        {
            _dokterBLL.AddUserToRole(dokterID, roleID);
            return RedirectToAction("Index", "Dokters");
        }
        public IActionResult addJadwal()
        {
            JadwalWithDokter jadwalWithDokter = new JadwalWithDokter();
            jadwalWithDokter.Dokters = new SelectList(_dokterBLL.GetAll(), "DokterID","Nama");
            jadwalWithDokter.Jadwals = _jadwalBLL.GetJadwalWithDokter().ToList();
            return View(jadwalWithDokter);
        }
        [HttpPost]
        public IActionResult addJadwal(AddJadwalDTO addJadwalDTO)
        {
            try
            {
                _jadwalBLL.Insert(addJadwalDTO);
                //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            }
            catch (Exception ex)
            {

                //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("addJadwal", "Dokters");
        }
        public IActionResult editJadwal(int id)
        {
            var model = _jadwalBLL.GetJadwalById(id);
            if (model == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Jadwal Not Found !</div>";
                return RedirectToAction("editJadwal", "Dokters");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult editJadwal(int id, UpdateJadwalDTO updateJadwalDTO)
        {
            try
            {
                _jadwalBLL.Update(updateJadwalDTO);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
            }
            catch (Exception ex)
            {
                ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View(updateJadwalDTO);
            }
            return RedirectToAction("addJadwal", "Dokters"); 
        }
        public IActionResult deleteJadwal(int id)
        {

            try
            {
                _jadwalBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>delete Data Category Success !</div>";
            }
            catch (Exception ex)
            {
                ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("addJadwal", "Dokters");
        }
        public IActionResult addKonsultasi()
        {
            ViewBag.dokter = _dokterBLL.GetAll();
            ViewBag.pasien = _pasienBLL.GetAll();
            var models = _konsultasiBLL.GetKonsultasiWithDokterPasien();
            return View(models);
        }
        [HttpPost]
        public IActionResult addKonsultasi(AddKonsultasiDTO addKonsultasiDTO)
        {
            try
            {
                _konsultasiBLL.Insert(addKonsultasiDTO);
                //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            }
            catch (Exception ex)
            {

                //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("addKonsultasi", "Dokters");
        }
        public IActionResult RiwayatKonsultasi()
        {
            var userDto = JsonSerializer.Deserialize<DokterDTO>(HttpContext.Session.GetString("user"));
            var model = _pasienBLL.GetKonsultasiPasienByDokter(userDto.DokterID);
            return View(model);
        }
    }
}
