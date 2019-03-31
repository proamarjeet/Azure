using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIP_1.ServiceLocatorInterfaces
{
    public interface IServiceLocator
    {
        T GetService<T>();       
    }
}
