using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Abstract;
using WebApi.DbObject;

namespace WebApi.Interface.DbObjects
{
    public interface IUserServices
    {
        IList<User> GetAll();
        User Get(int id);
        void Add(User users);
        void HardDelete(int id);
        void SoftDelete(User users);
        void Update(User users);
        void AddBulk(List<User> userList);
    }
}
