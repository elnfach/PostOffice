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

namespace PostOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Method();
        }

        async void Method()
        {
            var token = "edb182bc7bb5f773b81de1ee9098c6a9b74fa7cd";
            var api = new SuggestClientAsync(token);
            var response = await api.Iplocate("46.226.227.20");
            var address = response.location.data.country;
            Console.WriteLine(address);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
