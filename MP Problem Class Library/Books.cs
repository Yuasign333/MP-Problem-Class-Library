using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Problem_Class_Library
{
    internal class Books
    {
        private string BookID;
        private string BookTitle;
        private string BookAuthor;
        private int BookYear;

        // Constructor
        public Books(string title, string author, int year, int idNumber)
        {
            BookTitle = title;
            BookAuthor = author;
            BookYear = year;

            // BookID pattern = B + number
            BookID = "B" + idNumber;
        }

        // Getters
        public string getBookID()
        {
            return BookID;
        }

        public string getTitle()
        {
            return BookTitle;
        }

        public string getAuthor()
        {
            return BookAuthor;
        }

        public int getYear()
        {
            return BookYear;
        }

        public string getFullInfo()
        {
            return $"{BookID} - {BookTitle} by {BookAuthor} ({BookYear})";
        }


    }
}
