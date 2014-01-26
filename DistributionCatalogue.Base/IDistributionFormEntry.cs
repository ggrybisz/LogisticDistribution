using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace DistributionCatalogue.Base
{
    /// <summary>
    /// For WPF implement in WPF User Control Library
    /// For WindowsForms implement in Class Library
    /// </summary>
    public interface IDistributionFormEntry
    {
        string AuthorName { get; }
        string AuthorSurname { get; }
        string Version { get; }

        //Do not implement both
        Window WPFWindow { get; }
        Form WindowsFormsForm { get; }
    }
}
