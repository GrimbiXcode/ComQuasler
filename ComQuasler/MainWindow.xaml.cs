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
using System.Collections.Generic;

namespace ComQuasler
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// Uses as View
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize components for MVC
        /// </summary>
        private CController myController;
        private CModel myModel;

        /// <summary>
        /// Constructor of class MainWindow
        /// </summary>
        public MainWindow()
        {
            myModel = new CModel(this);
            this.myController = new CController(this, myModel);
            
            InitializeComponent();
        }


    }
}
