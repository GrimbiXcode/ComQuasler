/*****************************************************************************
 * Company:             GrimbixCode
 *
 * Project:             ComQuasler
 *
 * Target:              Windows
 *                   
 * Type:                C#-Class
 *
 * Description:         Intelligent communication over com-port
 *
 * Compiler:            C#
 *
 * Filename:            MainWindow.xaml.cs
 *
 * Version:             0.1
 *
 * Author:              GrimbixCode 
 *
 * Creation-Date:       20.04.2015
 *
 *****************************************************************************
 * Modification History:
 * 
 * [0.1]    16.04.2010  GrimbixCode     first release
 *
 *****************************************************************************/

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
// namespaces for ReadOnlyCollection
using System.Collections.ObjectModel;
/*****************************************************************************/

/*****************************************************************************
 * Class
 *****************************************************************************/   
namespace ComQuasler
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// Uses as View
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Define
        public static readonly IList<String> qcPortState = new ReadOnlyCollection<string>
        (new List<String> {"No port selected","Port is closed","Try open port","Port open"});

        #endregion Define

        #region Initialize
        /// <summary>
        /// Initialize components
        /// </summary>
        
        public enum ConnectionStates                                            // define all the connection states
        {
            NONE, CLOSED, TRYOPEN, CLOSEPORT, OPEN
        };

        private CPortHandler myComPort;

        
        #endregion Initialize

        #region Constructor
        /// <summary>
        /// Constructor of class MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            myComPort = new CPortHandler();

            _cboHandshake.ItemsSource = Enum.GetValues(typeof(Handshake));
            _cboParity.ItemsSource = Enum.GetValues(typeof(Parity));
            _cboStopBits.ItemsSource = Enum.GetValues(typeof(StopBits));
            _cboComPort.ItemsSource = SerialPort.GetPortNames();
            _tboState.Text = qcPortState[0];
        }

        #endregion Constructor


        #region GUI-Interface

        private void _btnConnect_Click(object sender, RoutedEventArgs e)
        {
            // check for missing setup data
            List<string> checkedComboBoxes = new List<string>(Check_ComboBoxes());
            if (checkedComboBoxes.Count > 0)
            {
                string str = "";
                foreach (string error in checkedComboBoxes)
                {
                    str += "- " + error + "\n\r";
                }
                if (checkedComboBoxes.Count == 1)
                {
                    MessageBox.Show("Folgende Angabe fehlt:\n\r" + str, "Fehlende Angaben", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Folgende Angaben fehlen:\n\r" + str, "Fehlende Angaben", MessageBoxButton.OK);
                }
            }
            else 
            {
                // if all data were avaiable, setup comport
                myComPort.SetUpPort(_cboComPort.SelectedItem.ToString(),
                                    int.Parse(_cboBaudrate.SelectedItem.ToString()),
                                    _cboHandshake.SelectedItem.ToString(),
                                    _cboParity.SelectedIndex,
                                    int.Parse(_tboDataBits.Text),
                                    _cboStopBits.SelectedIndex,
                                    int.Parse(_tboReadTimeout.Text),
                                    int.Parse(_tboWriteTimeout.Text)
                                    );
            }
        }

        #endregion GUI-Interface

        #region methodes

        private List<string> Check_ComboBoxes() 
        {
            List<string> checkList = new List<string>();
     
            if (_cboComPort.SelectedIndex == -1)
            {
                checkList.Add("COM Port");
            }
            if (_cboBaudrate.SelectedIndex == -1)
            {
                checkList.Add("Baudrate");
            }
            if (_cboHandshake.SelectedIndex == -1)
            {
                checkList.Add("Handshake");
            }
            if (_cboParity.SelectedIndex == -1)
            {
                checkList.Add("Parity");
            }
            if (_cboStopBits.SelectedIndex == -1)
            {
                checkList.Add("StopBit");
            }
            return checkList;
        }

        #endregion methodes
    }
}
/*****************************************************************************/
