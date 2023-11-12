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
        DateTime _date;
        string _dayofweek;
        Label schedule = new Label();

        public Schedule() 
        {
            _date = DateTime.Now;
            _dayofweek = _date.DayOfWeek.ToString();
            schedule.AutoSize = true;
            schedule.Location = new Point(30, 30);
            schedule.Size = new Size(176, 33);
        }
        public Schedule(string str, string schedule_str, int x, int y, string dayofweek)
        {
            _date = DateTime.Now;
            _dayofweek = _date.DayOfWeek.ToString();
            schedule.AutoSize = true;
            if (_dayofweek == dayofweek)
            {
                schedule.Font = new Font(schedule.Font, FontStyle.Bold);
            }
            schedule.ForeColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(23)))));
            schedule.Location = new Point(x, y);
            schedule.Size = new Size(176, 33);
            schedule.Text = $"{str} {schedule_str}";
            if (schedule_str == null)
            {
                schedule.Text = $"{str} Закрыто";
            }
        }
        private bool CheckSchedule()
        {


            return false;
        }

        public Label GetLabel()
        {
            return schedule;
        }
    }
}
