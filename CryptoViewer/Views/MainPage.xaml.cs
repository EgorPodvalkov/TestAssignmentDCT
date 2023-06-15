using CryptoViewer.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CryptoViewer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var container = ((App)App.Current).Container;

            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(MainViewModel));

            Search.KeyDown += EnterInSearch;
        }

        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel.UpdateCryptoList();
        }

        private void EnterInSearch(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ToFullInfoPage();
            }
        }

        private void SearchButton(object sender, RoutedEventArgs e)
            => ToFullInfoPage();

        private void ToFullInfoPage()
        {
            var search = Search.Text;
            if(!string.IsNullOrEmpty(search)) 
            {
                Frame.Navigate(typeof(FullInfoPage), search);
            }
        }
    }
}
