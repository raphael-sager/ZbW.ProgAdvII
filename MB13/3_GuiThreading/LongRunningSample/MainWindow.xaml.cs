using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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

        private async void Do() {
            //var t = new Thread(() => this.LongRunningOperation());
            //t.Start();

            //var t = new Task<string>(() => this.LongRunningOperation());
            //t.Start();
            //t.ContinueWith(ta =>
            //{
            //    this.Dispatcher.Invoke(() => 
            //    {
            //        this.label.Content = ta.Result;
            //    });
            //});

            //var res = this.LongRunningOperation();
            //this.label.Content = res;

            var t = Task.Run((this.LongRunningOperation));
            var result = await t; // generates a second task
            this.label.Content = result;

        }

        private string LongRunningOperation() {
            var cnt = 1;
            while (cnt <= 10)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.label.Content = $"Process {cnt}/10";
                });

                Thread.Sleep(1000);
                cnt++;
            }
            return "fertig";
        }

    }
}
