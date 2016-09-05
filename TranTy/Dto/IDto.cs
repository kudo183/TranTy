using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranTy.Dto
{
    public interface IDto<T> where T : class
    {
        bool HasChange { get; set; }
        int GetKey();
        void FromEntity(T entity);
        T ToEntity();
    }
}
