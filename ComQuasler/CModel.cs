using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Windows;

namespace ComQuasler
{
    class CModel
    {
        /// <summary>
        /// Initialize components for MVC
        /// </summary>
        private MainWindow myView;

        /// <summary>
        /// Initialize components
        /// </summary>>
        public SerialPort serial = new SerialPort();                            // creates new serial port
        public string[] AvailableCOMPorts;                                      // create string array - later, here are all the com ports listed
        public int SelectedCOMPort;                                             // the number of the current port will be stored in here

        /// <summary>
        /// Constructor of class cotroller
        /// </summary>
        /// <param name="myModel"></param>
        public CModel(MainWindow myView)
        {
            this.myView = myView;
        }
    }
}
