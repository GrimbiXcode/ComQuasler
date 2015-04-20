using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComQuasler
{
    class CController
    {
        /// <summary>
        /// Initialize components for MVC
        /// </summary>
        private MainWindow myView;
        private CModel myModel;

        /// <summary>
        /// Constructor of class cotroller
        /// </summary>
        /// <param name="myModel"></param>
        public CController(MainWindow myView, CModel myModel)
        {
            this.myView = myView;
            this.myModel = new CModel(myView);
        }


    }
}
