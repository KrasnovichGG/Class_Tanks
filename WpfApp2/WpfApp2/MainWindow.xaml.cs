using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public delegate void Message(string a);
    public delegate string FilePath(SaveFileDialog OFD);

    public partial class MainWindow : Window
    {
        string link = "";
        string output = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OfdBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var OFD = new OpenFileDialog();
                OFD.Filter = "Word Documents|*.docx;*.doc";
                OFD.ShowDialog();
                link = OFD.FileName;
                FileInfo sr = new FileInfo(OFD.FileName);
                txtname.Text = sr.Name;
                txtBase64.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Выберите корректный путь \n Ошибка -  { ex.Message}");
            }
        }

        private async void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Environment.UserName);
            Message mess = Mesage;
            try
            {
                //FileInfo fi = new FileInfo(link);
                //output = fi.FullName.Replace(fi.Extension, "") + ".pdf";
                mess("Ожидайте выполнения программы!");
                await Task.Run(() => FileOperations.ConvertDocxToPdf(link, output));
                Thread.Sleep(5000);
                output = $@"C:\Users\{Environment.UserName}\Desktop\result.pdf"; //изменить путь на универсальный, путь макроса изменить
                if (FileOperations.CompressFile(output))
                    mess("Сжато");
                else
                    mess("Не сжато");
                //FileOperations.CompressFile(output)? mess("") : mess(""));
                txtBase64.Text = FileOperations.ConvertingToBase64(output);
                mess("Выполнение завершено!");
                SfdBtn_Click(null, null);
                FileOperations.ConvertingFromBase64(txtBase64.Text, output);
            }

            catch (Exception ex)
            {
               mess($"Не удалось сконвертировать файл\n{ex.Message}");
            }
        }

        private string GetFilePath(SaveFileDialog OFD)
        {
            return OFD.FileName;
        }

        private void SfdBtn_Click(object sender, RoutedEventArgs e)
        {
            Message mess = Mesage;
            try
            {
                var OFD = new SaveFileDialog();
                OFD.DefaultExt = "pdf";
                OFD.AddExtension = true;
                OFD.CreatePrompt = true;
                OFD.OverwritePrompt = true;
                OFD.ShowDialog();
                FilePath fp = GetFilePath;
                mess(fp(OFD));
                output = OFD.FileName;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Выберите корректный путь \n Ошибка -  { ex.Message}");
            }
        }

        private void CopyTxtBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBase64.Text != "")
            {
                Clipboard.SetText(txtBase64.Text);
                MessageBox.Show("base64 скопирован в буфер обмена");
            }
        }

        public static void Mesage(string mes)
        {
            MessageBox.Show(mes);
        }
    }
}