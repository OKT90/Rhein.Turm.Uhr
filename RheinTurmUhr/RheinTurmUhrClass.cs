using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZonesLib;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;
namespace RheinTurmUhr
{

    class RheinTurmUhrClass
    {
        short language;

        public int chosenLanguage()
        {
            Watch watch = new Watch();
            if (watch.timezoneBox.Text == "Systemzeit") { language = 1; }
            else if (watch.timezoneBox.Text == "System time") { language = 2; }
            else if (watch.timezoneBox.Text == "الوقت الحالي للنظام") { language = 3; }
            return language;
        }
        public int theChosenLanguage()
        {
            Watch watch = new Watch();
            if (watch.file.Text == "Datei") { language = 1; }
            else if (watch.file.Text == "File") { language = 2; }
            else if (watch.file.Text == "ملف") { language = 3; }
            return language;
        }
    }
}
