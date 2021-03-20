using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Abstract;
using WebApi.DbObject;
using WebApi.Interface.DbObjects;

namespace WebApi.BLL.Concrete.DbObjectManager
{
    public class UserManager : IUserServices
    {
        private readonly IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Add(User users)
        {
            userDal.Add(users);
        }

        public void AddBulk(List<User> userList)
        {
            userDal.AddBulk(userList);
        }

        public User Get(int id)
        {
            return userDal.Get(id);
        }

        public IList<User> GetAll()
        {
            return userDal.GetAll();
        }

        public void HardDelete(int id)
        {
            userDal.HardDelete(id);
        }

        public void SoftDelete(User users)
        {
            userDal.SoftDelete(users);
        }

        public void Update(User users)
        {
            userDal.Update(users);
        }
    }
}
