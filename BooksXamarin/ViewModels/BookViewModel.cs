using BooksXamarin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BooksXamarin.ViewModels
{
    public class BookViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        BooksListViewModel lvm;
        public Book Book { get; private set; }
        public BookViewModel()
        {
            Book = new Book();
        }
        public BooksListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string BookName
        {
            get { return Book.BookName; }
            set
            {
                if (Book.BookName != value)
                {
                    Book.BookName = value;
                    OnPropertyChanged("BookName");
                }
            }
        }
        public string Genre
        {
            get { return Book.Genre; }
            set
            {
                if (Book.Genre != value)
                {
                    Book.Genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        public string Author
        {
            get { return Book.Author; }
            set
            {
                if (Book.Author != value)
                {
                    Book.Author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public bool wasRead
        {
            get { return Book.wasRead; }
            set
            {
                if (Book.wasRead != value)
                {
                    Book.wasRead = value;
                    OnPropertyChanged("wasRead");
                }
            }
        }

        public string Commentary
        {
            get { return Book.Commentary; }
            set
            {
                if (Book.Commentary != value)
                {
                    Book.Commentary = value;
                    OnPropertyChanged("wasRead");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(BookName.Trim())) ||
                     (!string.IsNullOrEmpty(Genre.Trim())) ||
                     (!string.IsNullOrEmpty(Author.Trim())) ||
                     (!string.IsNullOrEmpty(Commentary.Trim())));

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
