using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistributionCatalogue.Execution.cs
{
    public class Win32WindowHandle : IWin32Window
    {
        private IntPtr _handle;

        public Win32WindowHandle(IntPtr handle)
        {
            _handle = handle;
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
