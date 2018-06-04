/****************************************************
 ****************************************************
Author:      Omar Talaat
File Name:   RheinTurmUhr
Data:        04.06.018
compiler:    Visual Studio 2017
******************************************************
******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;
using TimeZonesLib;
namespace RheinTurmUhr
{
    public partial class Watch : Form
    {
        RheinTurmUhrClass selected = new RheinTurmUhrClass();
        MyClass timeZones = new MyClass();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Watch()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.TimerTick);
            timer.Start();
            // Prove if the langauge Arabic or German or English 
            if (selected.theChosenLanguage() == 1) AddTimeZonesGermen();
            else if (selected.theChosenLanguage() == 2) AddTimeZonesEnglish();
            else if (selected.theChosenLanguage() == 3) AddTimeZonesArabic();

        }
        // To fill the timezoneBox with the Time zones German
        private void AddTimeZonesGermen()
        {
            foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
            {
                if (check.Culture.EnglishName == "German (Germany)")
                {
                    foreach (TimeZoneInfo zonesById in TimeZoneInfo.GetSystemTimeZones())
                        timezoneBox.Items.Add(zonesById);
                    break;
                }
                else
                {
                    foreach (string zone in timeZones.TimeZonesGerman())
                    {
                        timezoneBox.Items.Add(zone);
                    }
                    break;
                }
            }
        }
        // To fill the timezoneBox with the Time zones Arabic
        private void AddTimeZonesArabic()
        {
            foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
            {
                if (check.Culture.EnglishName == "Arabic (Egypt)")
                {
                    foreach (TimeZoneInfo zonesById in TimeZoneInfo.GetSystemTimeZones())
                        timezoneBox.Items.Add(zonesById);
                    break;
                }
                else
                {
                    foreach (string zone in timeZones.TimeZonesArabic())
                    {
                        timezoneBox.Items.Add(zone);
                    }
                    break;
                }
            }
        }
        // To fill the timezoneBox with the Time zones English
        private void AddTimeZonesEnglish()
        {

            foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
            {
                if (check.Culture.EnglishName == "English (United States)")
                {
                    foreach (TimeZoneInfo zonesById in TimeZoneInfo.GetSystemTimeZones())
                        timezoneBox.Items.Add(zonesById);
                    break;
                }
                else
                {
                    foreach (string zone in timeZones.TimeZonesEnglish())
                    {
                        timezoneBox.Items.Add(zone);
                    }
                    break;
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //Switch Off Lights With every second
            SwitchOffLights();
            // When you choose the current Time for your System
            if (selected.chosenLanguage() > 0)
            {
                ShowTheCurrentSystemTime();
            }
            // When you choose the Time  1 for German, 2 for English and 3 for Arabic
            if (selected.theChosenLanguage() == 1)
            {
                foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
                {
                    if (check.Culture.EnglishName == "German (Germany)")
                    {
                        getTimeZones();
                        break;
                    }
                    else
                    {
                        foreach (string zone in timeZones.TimeZonesGerman())
                        {
                            compareTimeZones(zone);
                        }
                        break;
                    }
                }
            }
            else if (selected.theChosenLanguage() == 2)
            {
                foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
                {
                    if (check.Culture.EnglishName == "English (United States)")
                    {
                        getTimeZones();
                        break;
                    }
                    else
                    {
                        foreach (string zone in timeZones.TimeZonesEnglish())
                        {
                            compareTimeZones(zone);
                        }
                        break;
                    }
                }
            }
            else if (selected.theChosenLanguage() == 3)
            {
                foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
                {
                    if (check.Culture.EnglishName == "Arabic (Egypt)")
                    {
                        getTimeZones();
                        break;
                    }
                    else
                    {
                        foreach (string zone in timeZones.TimeZonesArabic())
                        {
                            compareTimeZones(zone);
                        }
                        break;
                    }
                }
            }
        }
        // When you choose the Time  1 for German, 2 for English and 3 for Arabic
        private void compareTimeZones(string zone)
        {
            foreach (TimeZoneInfo zones in TimeZoneInfo.GetSystemTimeZones())
            {
                if (zone == timezoneBox.Text)
                {
                    string zoneSubString = zone.Substring(4, 6);
                    string zoneCopy = zones.ToString();
                    int tester = zoneCopy.IndexOf(zoneSubString);
                    if (tester != -1)
                    {
                        ShowTheChosenSystemTime(zones);
                        break;
                    }
                }
            }
        }
        private void getTimeZones()
        {
            //Calculate the Time
            foreach (TimeZoneInfo zones in TimeZoneInfo.GetSystemTimeZones())
            {
                TimeZoneInfo zonesById = TimeZoneInfo.FindSystemTimeZoneById(zones.Id);

                if (timezoneBox.Text == zonesById.DisplayName)
                {
                    SwitchOffLights();
                    DateTime chosenTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zones);
                    SetDigitalWatch(chosenTime);
                    SwichOnLights(chosenTime.Second, chosenTime.Minute, chosenTime.Hour);
                }
            }
        }
        // TO Display the current Time for your System
        private void ShowTheCurrentSystemTime()
        {
            SetDigitalWatch(DateTime.Now);
            SwichOnLights(DateTime.Now.Second, DateTime.Now.Minute, DateTime.Now.Hour);
        }
        // TO Display the Chosen Time
        public void ShowTheChosenSystemTime(TimeZoneInfo zone)
        {
            SwitchOffLights();
            DateTime chosenTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
            SetDigitalWatch(chosenTime);
            SwichOnLights(chosenTime.Second, chosenTime.Minute, chosenTime.Hour);

        }
        private void SetDigitalWatch(DateTime dateTimeValue)
        {
            // To dispaly the Time on the Digital Watch
            currentHoursLabel.Text = dateTimeValue.ToString("HH");
            currentMinutesLabel.Text = dateTimeValue.ToString(":mm");
            currentSecondsLabel.Text = dateTimeValue.ToString("ss");
        }
        private void SwichOnLights(int seconds, int minutes, int hours)
        {
            //for each Second 
            switch (seconds % 10)
            {
                case 9: SwitchOn(S9); goto case 8;
                case 8: SwitchOn(S8); goto case 7;
                case 7: SwitchOn(S7); goto case 6;
                case 6: SwitchOn(S6); goto case 5;
                case 5: SwitchOn(S5); goto case 4;
                case 4: SwitchOn(S4); goto case 3;
                case 3: SwitchOn(S3); goto case 2;
                case 2: SwitchOn(S2); goto case 1;
                case 1: SwitchOn(S1); break;
            }
            //for each 10 Seconds 
            int resultDividSeconds = seconds / 10;
            switch (resultDividSeconds)
            {
                case 5: SwitchOn(S10); goto case 4;
                case 4: SwitchOn(S20); goto case 3;
                case 3: SwitchOn(S30); goto case 2;
                case 2: SwitchOn(S40); goto case 1;
                case 1: SwitchOn(S50); break;
            }
            //for each minute 
            switch (minutes % 10)
            {
                case 9: SwitchOn(M9); goto case 8;
                case 8: SwitchOn(M8); goto case 7;
                case 7: SwitchOn(M7); goto case 6;
                case 6: SwitchOn(M6); goto case 5;
                case 5: SwitchOn(M5); goto case 4;
                case 4: SwitchOn(M4); goto case 3;
                case 3: SwitchOn(M3); goto case 2;
                case 2: SwitchOn(M2); goto case 1;
                case 1: SwitchOn(M1); break;
            }
            //for each 10 minutes 
            int resultDividMinutes = minutes / 10;
            switch (resultDividMinutes)
            {
                case 5: SwitchOn(M50); goto case 4;
                case 4: SwitchOn(M40); goto case 3;
                case 3: SwitchOn(M30); goto case 2;
                case 2: SwitchOn(M20); goto case 1;
                case 1: SwitchOn(M10); break;
            }
            //for each hour 
            switch (hours % 10)
            {
                case 9: SwitchOn(H9); goto case 8;
                case 8: SwitchOn(H8); goto case 7;
                case 7: SwitchOn(H7); goto case 6;
                case 6: SwitchOn(H6); goto case 5;
                case 5: SwitchOn(H5); goto case 4;
                case 4: SwitchOn(H4); goto case 3;
                case 3: SwitchOn(H3); goto case 2;
                case 2: SwitchOn(H2); goto case 1;
                case 1: SwitchOn(H1); break;
            }
            //for each 10 hours
            int resultDividHours = hours / 10;
            switch (resultDividHours)
            {
                case 2:
                    SwitchOn(H10);
                    SwitchOn(H20);
                    break;
                case 1:
                    SwitchOn(H10);
                    break;

            }
        }
        private void SwitchOffLights()
        {
            PictureBox[] theLights = { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S20, S30, S40, S50,
                                         M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M20, M30, M40, M50,
                                         H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H20 };
            foreach (var Light in theLights)
            {
                Light.BackColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void SwitchOn(PictureBox lamp)
        {
            PictureBox[] theSecondsLights = { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S20, S30, S40, S50 };
            PictureBox[] theMinutesLights = { M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M20, M30, M40, M50 };
            PictureBox[] theHoursLights = { H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H20 };
            // giving blue Color to the Seconds
            foreach (var theSecondsLight in theSecondsLights)
            {
                if (lamp == theSecondsLight)
                    lamp.BackColor = Color.FromArgb(55, 60, 255);
            }
            // giving green Color to the Minutes
            foreach (var theMinutesLight in theMinutesLights)
            {
                if (lamp == theMinutesLight)
                    lamp.BackColor = Color.FromArgb(0, 160, 0);
            }
            // giving red Color to the Hours
            foreach (var theHoursLight in theHoursLights)
            {
                if (lamp == theHoursLight)
                    lamp.BackColor = Color.FromArgb(180, 0, 0);
            }
        }

        // Go to the About Window
        private void About_Click_1(object sender, EventArgs e)
        {
            About AboutForm = new About();
            AboutForm.ShowDialog();
        }
        // Go to the Alarm Window
        private void Alarm_Click_1(object sender, EventArgs e)
        {
            Alarm AlarmForm = new Alarm();
            AlarmForm.ShowDialog();
        }
        // to Exit
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }
        // to Minimize the Window
        private void Watch_Resize_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                icon.Visible = true;
            }
        }
        // to Maximize the Window
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            icon.Visible = false;
        }
        // to change the Langauge to English
        private void English_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Refreshed();
        }
        // to change the Langauge to Arabic
        private void Arbic_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-EG");
            Refreshed();
        }
        // to change the Langauge to Geramn
        private void Germen_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            Refreshed();
        }
        // to change the Langauge default Language 
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (InputLanguage check in InputLanguage.InstalledInputLanguages)
                if (check.Culture.EnglishName == "Arabic (Egypt)")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-EG");
                    Refreshed();
                }
                else if (check.Culture.EnglishName == "German (Germany)")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                    Refreshed();
                }
                else if (check.Culture.EnglishName == "English (United States)")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    Refreshed();
                }
        }
        //to reload the Form
        private void Refreshed()
        {
            Watch watch = new Watch();
            this.Hide();
            watch.Show();
        }
        
        }
}

