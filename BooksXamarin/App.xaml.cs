using BooksXamarin.Models;
using BooksXamarin.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace BooksXamarin
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "book.db";
        public static BookRepository database;
        public static BookRepository DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new BookRepository
                        (Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }
    }
}
