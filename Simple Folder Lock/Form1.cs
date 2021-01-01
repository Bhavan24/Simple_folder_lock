using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Simple_Folder_Lock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
            if (fbdL.ShowDialog() == DialogResult.OK)
            {
                txtLock.Text = fbdL.SelectedPath;

                DirectoryInfo d = new DirectoryInfo(fbdL.SelectedPath);
                string selectedpath = d.Parent.FullName + d.Name;
                if (fbdL.SelectedPath.LastIndexOf(".{") == -1)
                {
                    if (!d.Root.Equals(d.Parent.FullName))
                        d.MoveTo(d.Parent.FullName + "\\" + d.Name + x);
                    else d.MoveTo(d.Parent.FullName + d.Name + x);

                }
            }
            else
            {
                MessageBox.Show("Please Select Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fbdU.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo d = new DirectoryInfo(fbdU.SelectedPath);
                string Selectedpath = d.Parent.FullName + d.Name;

                txtUnlock.Text = fbdU.SelectedPath;

                d.MoveTo(fbdU.SelectedPath.Substring(0, fbdU.SelectedPath.LastIndexOf(".")));

            }
            else
            {
                MessageBox.Show("Please Select Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
