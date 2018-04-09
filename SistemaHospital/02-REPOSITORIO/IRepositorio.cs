using System;
using System.Collections.Generic;
using System.Data;
namespace ProjetoC._02_REPOSITORIO
{
    interface IRepositorio<T> where T : class
    {
        List<T> GetAll();
        DataSet GetMigraDGV(string _item);
        T GetById(int id);
        bool Insert(T _item);
        bool Delete(T _item);
        bool Update(T _item);

    }
}
