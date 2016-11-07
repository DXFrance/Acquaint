﻿namespace Acquaint.Native.UWP.Mvvm
{
    using Abstractions;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;
    using Models;

    /// <summary>
    /// ViewModelLocator
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ViewModel>();
        }

        /// <summary>
        /// Gets MeetupViewModel default instance.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModel Default => ServiceLocator.Current.GetInstance<ViewModel>();
    }
}
