using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.DAL;
using Library.Entity;
using Library.DAL.Repository;

namespace Library.BLL.Services
{
    public class RoleService
    {
        private RoleRepository _roleRepository;

        public RoleService()
        {
            _roleRepository = new RoleRepository();
        }

        public string GetRole(IPrincipal User)
        {
            return _roleRepository.GetRole(User.Identity);
        }
    }
}
