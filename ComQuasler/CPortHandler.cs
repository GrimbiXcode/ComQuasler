/*****************************************************************************
 * NAMESPACES
 *****************************************************************************/
// Standart namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// namespaces for port-communication
using System.IO.Ports;
using System.IO;
/*****************************************************************************/

/*****************************************************************************
 * Class
 *****************************************************************************/  
namespace ComQuasler
{
    class CPortHandler
    {
        #region Initialize
        /// <summary>
        /// Initialize components
        /// </summary>
        private SerialPort serial = new SerialPort();                            // creates new serial port
        public string[] AvailableCOMPorts;                                      // create string array - later, here are all the com ports listed
        public int SelectedCOMPort;                                             // the number of the current port will be stored in here
        #endregion Initialize

        // all methodes, which work with the COM port
        #region COM
        /// <summary>
        /// sets up serial port
        /// </summary>
        public void SetUpPort(string port, int baud, string hand, int parity, int databits, int stop, int read, int write)
        {
            // setup:
            serial.PortName = port;
            serial.BaudRate = baud;
            serial.Handshake = System.IO.Ports.Handshake.[hand];
            serial.Parity = Parity.[parity];
            serial.DataBits = databits;
            serial.StopBits = StopBits.[stop];
            serial.ReadTimeout = read;
            serial.WriteTimeout = write;

            //AvailableCOMPorts = SerialPort.GetPortNames();                      // save all available ports in a string array
            //SelectedCOMPort = 0;                                                // which port of them above is selected (start with 0)
        }

        /// <summary>
        /// opens the selected com port
        /// </summary>
        /// <returns>true = open successfully</returns>
        bool ConnectPort()
        {
            DisconnectPort();                                                   // before open new port, ensure that all ports are closed
            // set com port, which should be open
            try
            {
                serial.Open();                                                  // try to open serial port
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ensure that the com port is closed
        /// </summary>
        void DisconnectPort()
        {
            if (serial.IsOpen)                                                  // if the port is open...
            {
                try
                {
                    serial.Close();                                             // ...try to close it
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// go through all ports end send a FIND
        /// </summary>
        /// <returns>false, if there no ports left</returns>
        public bool ConnectTestDevice()
        {
            //TelegramControlRxTxCounter = 0;                                     // Reset RxTx-Control Counter
            //if (SelectedCOMPort < AvailableCOMPorts.Length)                     // if ports left
            //{
            //    if (ConnectPort()) TelegramSendCMD = TelegramCommands.FIND;     // open port and send FIND telegram
            //    window.UpdateTBO(window._tboAnschluss, AvailableCOMPorts[SelectedCOMPort]);// updates GUI
            //    SelectedCOMPort++;                                              // increase, next time, next port will be open
            //    return true;
            //}
            //else                                                                // if no ports left
            //{
            //    DisconnectDevice();
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// checks if telegrams have been lost
        /// </summary>
        /// <returns>true = not more than 3 telegrams lost (else it causes ConnectionState = NONE and close Port)</returns>
        public bool CheckConnection()
        {
            //if (TelegramControlRxTxCounter > 2)                                 // 3x send a Telegram without response
            //{
            //    DisconnectDevice();
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// close com port and set connectionstate to NONE
        /// </summary>
        public void DisconnectDevice()
        {
            DisconnectPort();                                                   // close com port
            //ConnectionState = ConnectionStates.NONE;                            // set connection state to NONE
        }

        #endregion COM
    }
}
/*****************************************************************************/