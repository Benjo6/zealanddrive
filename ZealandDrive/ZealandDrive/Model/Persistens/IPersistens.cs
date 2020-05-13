using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    interface IPersistens<T>
    {
        Task<ICollection<T>> Load();

        Task<bool> Opret(T t);

        Task <bool> Update(T t);


        Task <T> Delete(T t);

    }
}
