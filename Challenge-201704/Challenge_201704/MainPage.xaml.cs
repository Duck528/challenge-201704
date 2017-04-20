using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge_201704
{
	public partial class MainPage : ContentPage
	{
        private MainViewModel viewModel = null;
		public MainPage()
		{
			InitializeComponent();
            this.viewModel = new MainViewModel();
            this.BindingContext = viewModel;
		}

        private async void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var u = e.Item as UserModel;
            if (u != null)
            {
                if (u == this.viewModel.Users.Last())
                {
                    if (this.viewModel.LoadingStatus != LoadStatus.LoadingNow)
                    {
                        await this.viewModel.LoadUsers();
                    }
                }
            }
        }
    }
}
