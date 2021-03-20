using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Abstract;
using WebApi.DbObject;

namespace WebApi.DAL.Concrete.EntityFramework
{
    public class EFUserDal : EFRepositoryDal<User>, IUserDal
    {
        public EFUserDal(WebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
