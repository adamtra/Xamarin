using Books.Models;
using SQLite;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace books.data
{
    public class BooksDatabase
    {


        readonly SQLiteAsyncConnection database;

        public BooksDatabase(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Book>().Wait();
            Debug.WriteLine("czy ty tutaj wchodzisz?");

        }

        public Task<List<Book>> GetBooksAsync()
        {
            return database.Table<Book>().ToListAsync();
        }


        public Task<Book> GetItemAsync(int id)
        {
            return database.Table<Book>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Book item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Book item)
        {
            return database.DeleteAsync(item);
        }

        private List<Book> GenerateInitialList()
        {
            var initial = new List<Book>
            {
                new Book { Id = 1, BookName = "Harry Potter", Author = "J.K Rowling", Description="Fajna ksiązka" },
                new Book { Id = 2, BookName = "Władca pierścieni", Author = "Tolkien", Description="całkiem spoko książka" },
                new Book { Id = 3, BookName = "Ksiązka", Author = "autor", Description="ksiazka bo ksiazka fajna jest" },

            };
            return initial;
        }
    }
}
