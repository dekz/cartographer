using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cartographer
{
    public partial class Cartographer : Form
    {
        public Cartographer()
        {
            InitializeComponent();
            BROWSER.Navigate("http://maps.google.com/maps");
        }
    }
}
