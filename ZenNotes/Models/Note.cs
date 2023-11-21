using SQLite;
using System;

namespace ZenNotes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
