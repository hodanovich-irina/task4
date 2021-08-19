using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPLibrary.DelegateAndEvent
{
    /// <summary>
    /// Delegate
    /// </summary>
    public delegate void SLAY();
    /// <summary>
    /// Class for event
    /// </summary>
    public class MyEvent
    {
        /// <summary>
        /// event announcement
        /// </summary>
        public event SLAY SLAYEvent;
        /// <summary>
        /// method for starting the event
        /// </summary>
        public void OnSLAYEvent()
        {
            SLAYEvent();
        }
    }
}
