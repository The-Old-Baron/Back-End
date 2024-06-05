using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Interface.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedRole();
        void SeedUser();
    }
}
