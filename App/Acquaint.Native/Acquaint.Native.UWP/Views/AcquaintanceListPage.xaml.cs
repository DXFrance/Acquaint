using Acquaint.Abstractions;
using Acquaint.Models;
using Acquaint.Native.UWP.Mvvm;
using Microsoft.Practices.ServiceLocation;
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


namespace Acquaint.Native.UWP.Views
{
    public sealed partial class AcquaintanceListPage : Page
    {
        public AcquaintanceListPage()
        {
            this.InitializeComponent();
        }

        public ViewModel Default
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewModel>();
            }
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Acquaintance;
            this.Frame.Navigate(typeof(Views.AcquaintanceDetailPage), item);
        }
    }
}
