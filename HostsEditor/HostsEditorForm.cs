using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HostsEditor
{
    public partial class HostsEditorForm : Form
    {
        private string ConfigFileName { get; } = "hostspath.txt";
        private string DefaultHostsPath { get; } = @"C:\Windows\System32\drivers\etc\hosts";
        private string HostsPath { get; set; }

        public HostsEditorForm()
        {
            InitializeComponent();
        }

        private void HostsEditor_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "HostsEditor";
                this.CreateConfigFileIfNotExists();
                this.ReadConfigFile();
            }
            catch
            {
                this.Close();
            }
        }

        private void CreateConfigFileIfNotExists()
        {
            if (!File.Exists(this.ConfigFileName))
            {
                using (var stream = File.Create(this.ConfigFileName))
                {
                    var writer = new StreamWriter(stream);
                    writer.WriteLine();
                }
            }
        }

        private void ReadConfigFile()
        {
            var config = Enumerable.Empty<string>();
            try
            {
                config = File.ReadLines(this.ConfigFileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            this.HostsPath = config.First();
        }
    }
}
