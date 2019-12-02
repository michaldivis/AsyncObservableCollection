using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Divis.AsyncObservableCollection;
using Logic;
using Xamarin.Forms;

namespace Sample.Mobile
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _model;
        public MainPage()
        {
            InitializeComponent();

            _model = new MainViewModel();
            this.BindingContext = _model;

            //call the initialize method for async collections
            InitAsyncCollectionsAutomatically(_model);
        }

        /// <summary>
        /// Initializes all properties that implement the IAsyncObservableCollection interface
        /// </summary>
        /// <param name="model">The object, that holds the collections</param>
        private void InitAsyncCollectionsAutomatically(object model)
        {
            //select all properties that implement IAsyncObservableCollection
            var collections = model.GetType().GetProperties()
                .Where(a => typeof(IAsyncObservableCollection).IsAssignableFrom(a.PropertyType))
                .Select(a => a.GetValue(model) as IAsyncObservableCollection);

            //initialize them all
            InitAsyncCollections(collections);
        }

        /// <summary>
        /// Initializes an enumerable of IAsyncObservableCollection
        /// </summary>
        /// <param name="collections">The collections that need to be initialized</param>
        private void InitAsyncCollections(IEnumerable<IAsyncObservableCollection> collections)
        {
            foreach (var collection in collections)
            {
                //initialize the collection
                collection.Init(action => Device.BeginInvokeOnMainThread(() => action?.Invoke()));
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
