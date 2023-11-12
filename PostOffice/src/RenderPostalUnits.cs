using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostOffice.src
{
    internal class RenderPostalUnits
    {
        Label title = new Label();
        Label subtitle = new Label();
        Button location = new Button();
        Label closed = new Label();
        Schedule _monday;
        Schedule _tuesday;
        Schedule _wednesday;
        Schedule _thursday;
        Schedule _friday;
        Schedule _saturday;
        Schedule _sunday;
        List<Schedule> list = new List<Schedule>();

        private string _address_str;
        private string _postal_code;

        private static int shift = 0;

        public RenderPostalUnits(
            string address_str, 
            string postal_code,
            bool is_closed,
            string schedule_mon,
            string schedule_tue,
            string schedule_wed,
            string schedule_thu,
            string schedule_fri,
            string schedule_sat,
            string schedule_sun
            )
        {
            _address_str = address_str;
            _postal_code = postal_code;

            title.AutoSize = true;
            title.Font = new Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title.ForeColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(23)))));
            title.Location = new Point(30, shift + 20);
            title.Size = new Size(176, 33);
            title.Text = "Почта России";

            shift += 30;

            subtitle.AutoSize = true;
            subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            subtitle.ForeColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(23)))));
            subtitle.Location = new Point(30, shift + 20);
            subtitle.Size = new Size(176, 33);
            subtitle.Text = "Почтовое отделение";

            shift += 20;

            location.AutoSize = true;
            //location.Image = ((Image)resources.GetObject("button1.Image"));
            location.ImageAlign = ContentAlignment.MiddleLeft;
            location.Location = new Point(30, shift + 20);
            location.Size = new Size(282, 39);
            location.FlatAppearance.BorderSize = 0;
            location.FlatStyle = FlatStyle.Flat;
            location.TextAlign = ContentAlignment.MiddleLeft;
            location.Text = $"{address_str}, {postal_code}";
            location.ForeColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(23)))));
            location.Click += new EventHandler(location_Click);

            shift += 50;

            closed.AutoSize = true;
            closed.ForeColor = Color.White;
            closed.Font = new Font(closed.Font, FontStyle.Bold);
            closed.Location = new Point(30, shift + 20);
            closed.Size = new Size(176, 33);
            if (is_closed)
            {
                closed.ForeColor = Color.Red;
                closed.Text = "Закрыто";
            }
            else
            {
                closed.ForeColor = Color.Green;
                closed.Text = "Открыто";
            }

            shift += 30;

            _monday = new Schedule($"Пн: ", schedule_mon, 30, shift + 20, "Monday");
            shift += 30;
            _tuesday = new Schedule($"Вт: ", schedule_tue, 30, shift + 20, "Tuesday");
            shift += 30;
            _wednesday = new Schedule($"Ср: ", schedule_wed, 30, shift + 20, "Wednesday");
            shift += 30;
            _thursday = new Schedule($"Чт: ", schedule_thu, 30, shift + 20, "Thursday");
            shift += 30;
            _friday = new Schedule($"Пт: ", schedule_fri, 30, shift + 20, "Friday");
            shift += 30;
            _saturday = new Schedule($"Сб: ", schedule_sat, 30, shift + 20, "Saturday");
            shift += 30;
            _sunday = new Schedule($"Вс: ", schedule_sun, 30, shift + 20, "Sunday");
            list.Add(_monday);
            list.Add(_tuesday);
            list.Add(_wednesday);
            list.Add(_thursday);
            list.Add(_friday);
            list.Add(_saturday);
            list.Add(_sunday);

            shift += 30;
        }

        public void Init()
        {
            shift = 0;
        }
        
        public Label GetTitle()
        {
            return title;
        }

        public Label GetSubTitle() { return subtitle; }
        public Button GetLocation()
        {
            return location;
        }
        public Label GetIsClosed()
        {
            return closed;
        }

        public List<Schedule> GetData()
        {
            return list;
        }

        private void location_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скопировано в буфер обмена");
            Clipboard.SetDataObject($"{_address_str}, {_postal_code}");
        }
    }
}
