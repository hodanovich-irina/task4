using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPLibrary.SLAYMethods
{
    public delegate void UI();
    
    public class MyEvent
    {
        // Объявляем событие
        public event UI SLAYEvent;

        // Используем метод для запуска события
        public void OnSLAYEvent()
        {
            SLAYEvent();
        }
    }
}
