using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPLibrary.SLAYMethods
{
    /// <summary>
    /// SLAY interface
    /// </summary>
    public interface ISLAY
    {
        /// <summary>
        /// Number row
        /// </summary>
        int NumRow { get; set; }
        /// <summary>
        /// Number column
        /// </summary>
        int NumColum { get; set; }
        /// <summary>
        /// Main matrix
        /// </summary>
        double[,] MainMatrix { get; set; }
        /// <summary>
        /// Vector
        /// </summary>
        double[] Vector { get; set; }
        /// <summary>
        /// Result
        /// </summary>
        double[] XResult { get; set; }
    }
}
