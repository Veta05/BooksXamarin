using SQLite;
using System.Collections.Generic;

namespace BooksXamarin.Models
{
    public class BookRepository
    {
        SQLiteConnection database;
        public BookRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Book>();
        }
        public IEnumerable<Book> GetItems()
        {
            return database.Table<Book>().ToList();
        }
        public Book GetItem(int id)
        {
            return database.Get<Book>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Book>(id);
        }
        public int SaveItem(Book item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
