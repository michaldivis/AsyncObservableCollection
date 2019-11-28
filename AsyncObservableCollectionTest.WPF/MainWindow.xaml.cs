using System;
using System.Collections.Generic;
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
using AsyncObservableCollectionTest.Lib;

namespace AsyncObservableCollectionTest.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TheViewModel _model;
        public MainWindow()
        {
            InitializeComponent();

            _model = new TheViewModel();
            this.DataContext = _model;

            InitAsyncCollections();
        }

        private void InitAsyncCollections()
        {
            foreach (var prop in _model.GetType().GetProperties())
            {
                var value = prop.GetValue(_model);
                if (value is IAsyncObservableCollection collection)
                {
                    collection.Init(action => Dispatcher?.Invoke(() => action?.Invoke()));
                }
            }
        }

        private async void BtnAddAsync_OnClick(object sender, RoutedEventArgs e)
        {
            _model.Minions.Clear();
            await _model.LoadMinionsOneByOneAsync();
        }

        private async void BtnAddRangeAsync_OnClick(object sender, RoutedEventArgs e)
        {
            _model.Minions.Clear();
            await _model.LoadMinionsAtOnceAsync();
        }
    }
}
