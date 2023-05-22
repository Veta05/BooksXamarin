using BooksXamarin.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBBookPage : ContentPage
    {
        public DBBookPage()
        {
            InitializeComponent();
        }
        private void SaveBook(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            if (!String.IsNullOrEmpty(book.BookName))
            {
                App.DataBase.SaveItem(book);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteBook(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            App.DataBase.DeleteItem(book.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}