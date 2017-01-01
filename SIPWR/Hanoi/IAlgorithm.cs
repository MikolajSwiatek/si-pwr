using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPWR.Hanoi
{
    interface IAlgorithm
    {
        Hanoi.Model.History Run();
    }
}
