using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace CryptoGraphy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public IDialogService dialogService;
        public EncryptMachine encryptMachine;

        public MainWindow()
        {
            InitializeComponent();
            dialogService = new DefaultDialogService();
            encryptMachine = new EncryptMachine();
        }

        public void menuOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if(dialogService.OpenFileDialog())
            {
                inputTextBox.Text = File.ReadAllText(dialogService.FilePath);
            }
        }

        public void menuSaveFile_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(dialogService.FilePath))
            {
                File.WriteAllText(dialogService.FilePath, inputTextBox.Text);
            }
            else
            {
                menuSaveFileAs_Click(sender, e);
            }
        }

        public void menuSaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            if (dialogService.SaveFileDialog())
            {
                File.WriteAllText(dialogService.FilePath, inputTextBox.Text);
            }
        }

        public void inputTextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        public void menuNewFile_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "";
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void inputTextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void inputTextBox_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outputTextBlock.Text = encryptMachine.Encrypt(inputTextBox.Text, keyTextBox.Text, comboBoxEncryptionType.SelectedIndex, comboBoxLanguage.SelectedIndex);
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
