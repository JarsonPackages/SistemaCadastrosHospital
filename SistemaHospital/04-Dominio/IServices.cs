using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._04_Dominio
{
    interface IServices<T>
    {
        void Insert(T _user);
        void Delete(T _user);
        T Get(int  _user);
        List<T> GetAll();
        void Update(T _user);
    }
}
