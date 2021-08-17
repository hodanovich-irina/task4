using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPLibrary.SLAYMethods
{
    public interface ISLAY
    {
        int NumRow { get; set; }
        int NumColum { get; set; }
        double[,] MainMatrix { get; set; }
        double[] Vector { get; set; }
        double[] XResult { get; set; }
    }
}
