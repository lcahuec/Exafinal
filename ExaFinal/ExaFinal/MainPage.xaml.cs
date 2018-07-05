﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExaFinal.Views;

namespace ExaFinal
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.Master = new MasterPage();
            this.Detail = new NavigationPage( new LoginPage());
            App.MasterD = this;
		}
	}
}