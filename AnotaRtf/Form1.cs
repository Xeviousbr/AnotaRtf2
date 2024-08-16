using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AnotaRtf
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AnoteitorRTF\MyApp"))
                {
                    if (key != null)
                    {
                        int x = (int)key.GetValue("WindowPositionX", this.Left);
                        int y = (int)key.GetValue("WindowPositionY", this.Top);
                        int width = (int)key.GetValue("WindowWidth", this.Width);
                        int height = (int)key.GetValue("WindowHeight", this.Height);

                        this.StartPosition = FormStartPosition.Manual;
                        this.Left = x;
                        this.Top = y;
                        this.Width = width;
                        this.Height = height;
                    }
                }
            }
            catch (Exception ex)
            {
                // 
            }
            rtfTexto.caminhoDoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "anotacoes.rtf");
            rtfTexto.Criptografia = false;
            rtfTexto.Carrega();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"AnoteitorRTF\MyApp"))
                {
                    if (key != null)
                    {
                        key.SetValue("WindowPositionX", this.Left);
                        key.SetValue("WindowPositionY", this.Top);
                        key.SetValue("WindowWidth", this.Width);
                        key.SetValue("WindowHeight", this.Height);
                    }
                }
            }
            catch (Exception ex)
            {
                // 
            }
        }
    }
}
