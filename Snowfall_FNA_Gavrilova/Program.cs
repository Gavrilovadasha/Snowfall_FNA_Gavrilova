using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snowfall_FNA_Gavrilova
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ScreenSaver screensaver = new ScreenSaver())
            {
                screensaver.Run();
            }
        }
    }
}
