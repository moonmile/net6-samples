using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Commands;

namespace Net6WPFPrism
{
    internal class MainViewModel : Prism.Mvvm.BindableBase
    {
        private string _title = "";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value, nameof(Title));
        }
        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        public DelegateCommand Clicked { get; private set; }
        public MainViewModel()
        {
            this.Title = "Hello .NET 6 World.";
            Clicked = new DelegateCommand(
                () => { Title = $"こんにちは {Name} さん"; },
                () => true);
        }
    }
}
