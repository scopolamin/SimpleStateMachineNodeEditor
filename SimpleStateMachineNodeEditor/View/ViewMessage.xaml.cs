﻿using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ReactiveUI;
using System;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using System.Reactive.Linq;
using System.Windows.Markup;
using SimpleStateMachineNodeEditor.ViewModel;
using SimpleStateMachineNodeEditor.Helpers;

namespace SimpleStateMachineNodeEditor.View
{
    /// <summary>
    /// Interaction logic for ViewError.xaml
    /// </summary>
    public partial class ViewMessage : UserControl, IViewFor<ViewModelMessage>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(ViewModelMessage), typeof(ViewMessage), new PropertyMetadata(null));

        public ViewModelMessage ViewModel
        {
            get { return (ViewModelMessage)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelMessage)value; }
        }
        #endregion ViewModel
        public ViewMessage()
        {
            InitializeComponent();
            SetupBinding();
        }
        #region SetupBinding
        private void SetupBinding()
        {
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, x => x.Text, x => x.TextBlock.Text).DisposeWith(disposable);
            });
        }
        #endregion SetupBinding
    }
}