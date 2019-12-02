using System;
using System.ComponentModel;
using Divis.AsyncObservableCollection;
using Logic;
using Xamarin.Forms;

namespace Sample.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly TheViewModel _model;
        public MainPage()
        {
            InitializeComponent();

            _model = new TheViewModel();
            this.BindingContext = _model;

            InitAsyncCollections();
        }

        private void InitAsyncCollections()
        {
            foreach (var prop in _model.GetType().GetProperties())
            {
                var value = prop.GetValue(_model);
                if (value is IAsyncObservableCollection collection)
                {
                    collection.Init(action => Device.BeginInvokeOnMainThread(() => action?.Invoke()));
                }
            }
        }

        private async void BtnAddAsync_OnClicked(object sender, EventArgs e)
        {
            _model.Minions.Clear();
            await _model.LoadMinionsOneByOneAsync();
        }

        private async void BtnAddRangeAsync_OnClicked(object sender, EventArgs e)
        {
            _model.Minions.Clear();
            await _model.LoadMinionsAtOnceAsync();
        }
    }
}
