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
            // 51.816468660013605, 107.65143629319506
            //Method(51.816468660013605, 107.65143629319506, 1000);
            try
            {
                Method(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch (Exception ex){
                MessageBox.Show("Вводите значения с плавающей точкой через ЗАПЯТУЮ!");
            }
        }
    }
}
