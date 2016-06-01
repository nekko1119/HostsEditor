using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HostsEditor
{
    class Config
    {
        private string ConfigFileName { get; } = "hostspath.txt";
        public string DefaultHostsPath { get; } = @"C:\Windows\System32\drivers\etc\hosts";
        public string Path { get; private set; }

        public Config()
        {
            this.Path = this.DefaultHostsPath;
        }

        public void CreateIfNotExists()
        {
            if (!File.Exists(this.ConfigFileName))
            {
                using (var stream = File.Create(this.ConfigFileName))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(this.DefaultHostsPath);
                    }
                }
            }
        }

        public void Read()
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
            this.Path = config.Count() > 0 ? config.First() : this.DefaultHostsPath;
        }
    }
}
