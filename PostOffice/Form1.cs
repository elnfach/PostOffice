using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dadata;
using Dadata.Model;
using PostOffice.Properties;
using PostOffice.src;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PostOffice
{
    public partial class Form1 : Form
    {
        RenderPostalUnits renderPostalUnits = null;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        string token = "edb182bc7bb5f773b81de1ee9098c6a9b74fa7cd";
        public Form1()
        {
            InitializeComponent();
        }

        async void SearchPostalUnits(double lat, double lon, int radius)
        {
            try
            {
                var api = new OutwardClientAsync(token);
                var response = await api.Geolocate<PostalUnit>(lat, lon, radius);
                if (renderPostalUnits != null)
                {
                    renderPostalUnits.Init();
                }
                panel1.Controls.Clear();
                foreach (var item in response.suggestions)
                {
                    renderPostalUnits = new RenderPostalUnits(
                        item.data.address_str,
                        item.data.postal_code,
                        item.data.is_closed,
                        item.data.schedule_mon,
                        item.data.schedule_tue,
                        item.data.schedule_wed,
                        item.data.schedule_thu,
                        item.data.schedule_fri,
                        item.data.schedule_sat,
                        item.data.schedule_sun
                        );

                    panel1.Controls.Add(renderPostalUnits.GetTitle());
                    panel1.Controls.Add(renderPostalUnits.GetSubTitle());
                    panel1.Controls.Add(renderPostalUnits.GetLocation());
                    panel1.Controls.Add(renderPostalUnits.GetIsClosed());

                    foreach (Schedule j in renderPostalUnits.GetData())
                    {
                        panel1.Controls.Add(j.GetLabel());
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Show();
                SearchPostalUnits(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch (Exception ex){
                MessageBox.Show("Входная строка имеет неправильное значение");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 44 && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 44 && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
