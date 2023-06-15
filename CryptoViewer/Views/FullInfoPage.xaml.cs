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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoViewer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FullInfoPage : Page
    {
        public FullInfoPage()
        {
            this.InitializeComponent();

            var container = ((App)App.Current).Container;

            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(FullInfoViewModel));

            Search.KeyDown += EnterInSearch;
        }

        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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
            if (!string.IsNullOrEmpty(search))
            {
                UpdateDisplaing(search);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                UpdateDisplaing(e.Parameter.ToString());
            }
        }

        private void UpdateDisplaing(string search)
        {
            var viewModel = DataContext as FullInfoViewModel;

            Head.Children.Clear();
            Info.Children.Clear();
            LinkRow.Children.Clear();
            Exchanges.Children.Clear();

            // if Such Crypto Exist
            if (viewModel.UpdateData(search))
            {
                // Creating Head
                var head = new TextBlock
                {
                    Text = $"{viewModel.Symbol} ({viewModel.Name}), {viewModel.Price} $  ",
                    FontSize = 30
                };

                SolidColorBrush percentColor;
                if (viewModel.PercentColor == "Red")
                {
                    percentColor = new SolidColorBrush(Windows.UI.Colors.Red);
                }
                else
                {
                    percentColor = new SolidColorBrush(Windows.UI.Colors.LightGreen);
                }

                var headPecentage = new TextBlock
                {
                    Foreground = percentColor,
                    Text = $" {viewModel.ChangePercent} %",
                    FontSize = 30
                };

                Grid.SetColumn(head, 0);
                Head.Children.Add(head);

                Grid.SetColumn(headPecentage, 1);
                Head.Children.Add(headPecentage);

                // Creating Info List
                Info.Children.Add(new TextBlock
                {
                    Text = 
                    $"Rank - {viewModel.Rank}\n" +
                    $"Supply - {viewModel.Supply}\n" +
                    $"Market Cap - {viewModel.Cap}\n" +
                    $"Volume (24 Hours) - {viewModel.Volume}"
                });
                Info.Padding = new Thickness(10, 0, 0, 0);

                // Creating Link
                var linkDescription = new TextBlock { Text = "More info: " };

                var link = new TextBlock();
                var linkText = new Run { Text = viewModel.Link };
                var hyperlink = new Hyperlink { NavigateUri = new Uri(viewModel.Link) };
                
                hyperlink.Inlines.Add(linkText);
                link.Inlines.Add(hyperlink);

                Grid.SetColumn(linkDescription, 0);
                LinkRow.Children.Add(linkDescription);

                Grid.SetColumn(link, 2);
                LinkRow.Children.Add(link);
                LinkRow.Padding = new Thickness(10, 0, 0, 0);

                // Creating Exchanges List
                var index = 0;
                foreach(var exchange in viewModel.Exchanges)
                {
                    link = new TextBlock();
                    
                    // if no Link
                    if (string.IsNullOrEmpty(exchange.Link))
                    {
                        link.Text = exchange.Id;
                    }
                    // if we have Link
                    else
                    {
                        linkText = new Run { Text = exchange.Id };
                        hyperlink = new Hyperlink { NavigateUri = new Uri(exchange.Link) };

                        hyperlink.Inlines.Add(linkText);
                        link.Inlines.Add(hyperlink);
                    }
                    Grid.SetRow(link, index++);
                    Exchanges.Children.Add(link);
                }
            }
            // if Such Crypto not Exist
            else
            {
                Head.Children
                    .Add(new TextBlock
                    {
                        Margin = new Thickness(10, 5, 5, 5),
                        Text = $"Something wrong :( \nWe can`t find crypto '{search}', sorry. \nTry to use symbol or name of crypto",
                        FontSize = 23,
                        Foreground = new SolidColorBrush(Windows.UI.Colors.Red),
                    });
            }

        }
    }
}
