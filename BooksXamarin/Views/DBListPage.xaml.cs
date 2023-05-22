using BooksXamarin.Models;
using BooksXamarin.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var viewModel = new BooksListViewModel();
            viewModel.TotalBooksCount = App.DataBase.GetItems().Count();
            viewModel.ReadBooksCount = App.DataBase.GetItems().Count(b => b.wasRead);
            viewModel.UnreadBooksCount = viewModel.TotalBooksCount - viewModel.ReadBooksCount;

            BindingContext = viewModel;
            booksList.ItemsSource = App.DataBase.GetItems();

            var sortedList = App.DataBase.GetItems().OrderBy(b => b.wasRead).ToList();
            booksList.ItemsSource = sortedList;

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)e.SelectedItem;
            DBBookPage bookPage = new DBBookPage();
            bookPage.BindingContext = selectedBook;
            await Navigation.PushAsync(bookPage);
        }

        private async void CreateBook(object sender, EventArgs e)
        {
            Book book = new Book();
            DBBookPage bookPage = new DBBookPage();
            bookPage.BindingContext = book;
            await Navigation.PushAsync(bookPage);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var book = cell?.BindingContext as Book;

            if (book != null && book.wasRead)
                cell.View.BackgroundColor = Color.Green;
            else
                cell.View.BackgroundColor = Color.Red;

            cell.ForceUpdateSize();
        }
    }
}
