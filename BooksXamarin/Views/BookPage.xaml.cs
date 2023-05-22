using BooksXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public BookViewModel ViewModel { get; private set; }
        public BookPage(BookViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}