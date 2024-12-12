using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    public interface IGenericDal <T> where T : class
    {
        //Repository: bir tasarım desenidir:crud işlemlerini merkeziyetleştiriyor
        void Insert(T entity);
        void Update(T entity);
        void Delete(int Id);
        List<T> GetAll();
        T GetById(int Id);

    }
}
