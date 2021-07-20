using MonkeyCacheExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyCacheExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartWorkView : ContentPage
    {
        public StartWorkView()
        {
            InitializeComponent();
            BindingContext = new StartWorkViewModel();
        }
    }
}