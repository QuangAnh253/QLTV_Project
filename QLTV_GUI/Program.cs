    using System;
using System.Collections.Generic;
using System.Linq;
using QLTV_GUI.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_GUI

{

    internal static class Program

    {

        /// <summary>

        /// The main entry point for the application.

        /// </summary>

        [STAThread]

        static void Main()

        {

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: Chạy FormLogin đầu tiên, sau đó mới mở FormMain

            // Application.Run(new FormLogin());

            Application.Run(new FormMain()); // Tạm thời chạy thẳng FormMain để test

        }

    }

}
