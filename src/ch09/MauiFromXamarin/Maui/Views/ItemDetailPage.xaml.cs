using MauiFromXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MauiFromXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}