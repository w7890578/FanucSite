using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace UrlCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbCodeFormat.SelectedIndex = 0;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            string codeformat = cmbCodeFormat.SelectedItem.ToString();
            txtResult.Text = System.Web.HttpUtility.UrlEncode(txtsource.Text.Trim(), Encoding.GetEncoding(codeformat));
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            string codeformat = cmbCodeFormat.SelectedItem.ToString();
            txtResult.Text = System.Web.HttpUtility.UrlDecode(txtsource.Text.Trim(), Encoding.GetEncoding(codeformat));
        }
    }
}
