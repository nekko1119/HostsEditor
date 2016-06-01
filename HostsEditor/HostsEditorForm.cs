using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HostsEditor
{
    public partial class HostsEditorForm : Form
    {
        private Config config = new Config();

        public HostsEditorForm()
        {
            InitializeComponent();
        }

        private void HostsEditor_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "HostsEditor";
                this.config.CreateIfNotExists();
                this.config.Read();
            }
            catch
            {
                this.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HostsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
