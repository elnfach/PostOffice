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
using PostOffice.src;

namespace PostOffice
{
    public partial class Form1 : Form
    {
        AddressWrap addressWrap;
        KeyPressHandler textbox1Handler = new KeyPressHandler();
        KeyPressHandler textbox2Handler = new KeyPressHandler();
        KeyPressHandler textbox3Handler = new KeyPressHandler();
        string token = "edb182bc7bb5f773b81de1ee9098c6a9b74fa7cd";
        public Form1()
        {
            InitializeComponent();
        }

        async void Method(double lat, double lon, int radius)
        {
            var api = new OutwardClientAsync(token);
            var response = await api.Geolocate<PostalUnit>(lat, lon, radius);
            addressWrap = new AddressWrap(response.suggestions);
            richTextBox1.Text = addressWrap.GetData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 51.818410947834856, 107.65301106105547
            try
            {
                Method(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch (Exception ex){
                MessageBox.Show("Входная строка имеет неправильное значение");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (textbox1Handler.CheckKeyPressed(number))
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
