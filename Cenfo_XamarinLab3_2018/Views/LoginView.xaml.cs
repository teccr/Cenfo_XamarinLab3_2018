﻿using System;
using System.Collections.Generic;
using Cenfo_XamarinLab3_2018.ViewModels;
using Xamarin.Forms;

namespace Cenfo_XamarinLab3_2018.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            BindingContext = LoginViewModel.GetInstance();
        }
    }
}
