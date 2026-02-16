using System;
using System.Collections.Generic;
using System.Text;

namespace Jan9
{
    internal interface IRepo<T>
    {
        T searchById(int id);
    }
}
