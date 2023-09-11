using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application
{
    public interface IUnitOfWork
    {
        //yapılan işlemlerin veritabanına kaydedilmesi için gerekli methodlar tanımlandı.
        Task CommitAsync();
        void Commit();
    }
}
