using DistributionCatalogue.Base;
using DistributionCatalogue.Logistic.WPFWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionCatalogue.Logistic
{
    public class MyEntryClass : IDistributionFormEntry
    {
        public string AuthorName
        {
            get { return "Grybisz"; }
        }

        public string AuthorSurname
        {
            get { return "Żak"; }
        }

        public string Version
        {
            get { return "0.0.0.1"; }
        }

        public System.Windows.Window WPFWindow
        {
            get { return new MyWindow(); }

            //if implementing WindowsForms solution please return null
           // get { return null; }
        }

        public System.Windows.Forms.Form WindowsFormsForm
        {
            //get { return new MyForm(); }

            //if implementing WPF solution please return null
            get { return null; }
        }
    }
}
