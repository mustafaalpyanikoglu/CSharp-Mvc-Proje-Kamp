using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        private AdminManager _adminManager = new AdminManager(new EfAdminDal());
        private RoleManager _roleManager = new RoleManager(new EfRoleDal());

        // GET: Auth
        public ActionResult Index()
        {
            var result = _adminManager.GetAdmins();
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueAdminRole = (from c in _roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()
                                                   }).ToList();
            ViewBag.valueAdmin = valueAdminRole;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(LoginDto loginDto)
        {
            _authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = (from c in _roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();
            ViewBag.valueAdmin = valueAdminRole;
            var result = _adminManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var result = _adminManager.GetById(admin.AdminId);
            if(result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            _adminManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}