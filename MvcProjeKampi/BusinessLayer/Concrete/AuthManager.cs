using BusinessLayer.Abstract;
using Core.Utilities.Security.Hashing;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAdminService _adminService;
        private IWriterService _writerService;

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        public bool Login(LoginDto loginDto)
        {
            var result = _adminService.GetByUserName(loginDto.AdminUserName);
            if (HashingHelper.VerifyPasswordHash(loginDto.AdminPassword, result.PasswordHash, result.PasswordSalt))
            {
                return true;
            }
            return false;
        }

        public void Register(string adminUserName, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var admin = new Admin
            {
                AdminUserName = adminUserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = 1
            };
            _adminService.Add(admin);
        }

        public bool WriterLogin(WriterLoginDto writerLoginDto)
        {
            var userToChck = _writerService.GetByEmail(writerLoginDto.WriterMail);
            if (HashingHelper.VerifyPasswordHash(writerLoginDto.WriterPassword, userToChck.WriterPasswordHash, userToChck.WriterPasswordSalt))
            {
                return true;
            }
            return false;
        }

        public void WriterRegister(string mail, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterMail = mail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
            };
            _writerService.Add(writer);
        }
    }
}
