using BooksXamarin.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksXamarin.ViewModels
{
    public class BooksListViewModel
    {
        private int totalBooksCount;
        public int TotalBooksCount
        {
            get { return totalBooksCount; }
            set
            {
                if (totalBooksCount != value)
                {
                    totalBooksCount = value;
                    OnPropertyChanged("TotalBooksCount");
                }
            }
        }

        private int readBooksCount;
        public int ReadBooksCount
        {
            get { return readBooksCount; }
            set
            {
                if (readBooksCount != value)
                {
                    readBooksCount = value;
                    OnPropertyChanged("ReadBooksCount");
                }
            }
        }

        private int unreadBooksCount;
        public int UnreadBooksCount
        {
            get { return unreadBooksCount; }
            set
            {
                if (unreadBooksCount != value)
                {
                    unreadBooksCount = value;
                    OnPropertyChanged("UnreadBooksCount");
                }
            }
        }
        private void UpdateBooksCounts()
        {
            TotalBooksCount = App.DataBase.GetItems().Count();
            ReadBooksCount = App.DataBase.GetItems().Count(b => b.wasRead == true);
            UnreadBooksCount = TotalBooksCount - ReadBooksCount;
        }

        public ObservableCollection<BookViewModel> Books { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateBookCommand { protected set; get; }
        public ICommand DeleteBookCommand { protected set; get; }
        public ICommand SaveBookCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        BookViewModel selectedBook;
        public INavigation Navigation { get; set; }
        public BooksListViewModel()
        {
            Books = new ObservableCollection<BookViewModel>();
            CreateBookCommand = new Command(CreateBook);
            DeleteBookCommand = new Command(DeleteBook);
            SaveBookCommand = new Command(SaveBook);
            BackCommand = new Command(Back);
        }
        public BookViewModel SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (selectedBook != value)
                {
                    BookViewModel tempBook = value;
                    selectedBook = null;
                    OnPropertyChanged("SelectedBook");
                    Navigation.PushAsync(new BookPage(tempBook));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateBook()
        {
            Navigation.PushAsync(new BookPage(new BookViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveBook(object bookObject)
        {
            BookViewModel book = bookObject as BookViewModel;
            if (book != null && book.IsValid && !Books.Contains(book))
            {
                Books.Add(book);
            }
            Back();
        }
        private void DeleteBook(object bookObject)
        {
            BookViewModel book = bookObject as BookViewModel;
            if (book != null)
            {
                Books.Remove(book);
            }
            Back();
        }
    }
}
