using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncawait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CountCharacters()
        {
            int count = 0;
            using(StreamReader reader = new StreamReader("c:\\Data\\Data.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            lblCount.Text = "Processing File, please wait";
            int count = CountCharacters();
            lblCount.Text = count.ToString() + "characters in file";

        }
    }
}
