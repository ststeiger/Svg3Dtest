using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'COR_Basic_DemoDataSet.T_Benutzer' table. You can move, or remove it, as needed.
            this.T_BenutzerTableAdapter.Fill(this.COR_Basic_DemoDataSet.T_Benutzer);
            this.reportViewer1.RefreshReport();
        }
    }
}