﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPWR.Hanoi
{
    interface IAlgorithm
    {
        void Execute(string endstate);
        Hanoi.Model.History GetResult();
    }
}
