using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Providers.Interfaces
{
    public interface IResponseProvider
    {
        void Success(object data);
        void Success(string message,object data);
        void Error(string message);
    }
}
