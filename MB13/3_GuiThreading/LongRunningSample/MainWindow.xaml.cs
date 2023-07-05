using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LongRunningSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Do();
        }

        private void Do() {
            var res = this.LongRunningOperation();
            this.label.Content = res;
        }

        private string LongRunningOperation() {
            var cnt = 0;
            while (cnt < 10) {
                this.label.Content = $"Process {cnt}/10";
                Thread.Sleep(1000);
                cnt++;
            }
            return "fertig";
        }

    }
}
