using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._04_Dominio
{
    interface IServices<T>
    {
        bool Insert(T _user);
        bool Delete(T _user);
        T Get(int  _user);
        List<T> GetAll();
        bool Update(T _user);
    }
}
