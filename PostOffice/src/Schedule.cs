using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostOffice.src
{
    internal class Schedule
    {
        Label schedule = new Label();

        public Schedule() 
        {
            schedule.AutoSize = true;
            schedule.Location = new Point(30, 30);
            schedule.Size = new Size(176, 33);
        }
        public Schedule(string str, int x, int y) 
        {
            schedule.AutoSize = true;
            schedule.ForeColor = Color.FromArgb(197, 202, 233);
            schedule.Location = new Point(x, y);
            schedule.Size = new Size(176, 33);
            schedule.Text = str;
        }

        public Label GetLabel()
        {
            return schedule;
        }
    }
}
