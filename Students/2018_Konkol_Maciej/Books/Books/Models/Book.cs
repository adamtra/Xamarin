using SQLite;
using System;

namespace Books.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}