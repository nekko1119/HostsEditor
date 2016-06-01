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
    }
}
