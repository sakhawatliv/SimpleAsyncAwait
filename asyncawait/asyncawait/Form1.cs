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

        private async void btnShowResult_Click(object sender, EventArgs e)
        {
            //Task keyword is means an unit of task....
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();
            lblCount.Text = "Processing File, please wait";
            //when till this done we will wait for the task.. so we used await keaword
            int count = await task;
            lblCount.Text = count.ToString() + "characters in file";





            //Note: If we dont use async await, when we first run the project and click on show as long as process not comple we cannot move the window form.

        }
    }
}
