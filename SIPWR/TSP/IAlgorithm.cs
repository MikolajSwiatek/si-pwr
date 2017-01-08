using SIPWR.TSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP
{
    public interface IAlgorithm
    {
        void Execute();
        History GetResult();
    }
}