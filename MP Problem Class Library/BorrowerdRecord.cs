using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Problem_Class_Library
{
    internal class BorrowedRecord
    {
        private Borrowers borrower;
        private Books borrowedBook;

        // Constructor
        public BorrowedRecord(Borrowers borrower, Books borrowedBook)
        {
           //using this to make it clear we are assigning It to the class fields (since same name)
           this.borrower = borrower;
           this.borrowedBook = borrowedBook;
        }

        // Methods to access the data
        public Borrowers GetBorrower()
        {
            return borrower;
        }

        public Books GetBook()
        {
            return borrowedBook;
        }

        public string GetRecordInfo()
        {
            return $"{borrower.getFullName()} borrowed \"{borrowedBook.getTitle()}\" by {borrowedBook.getAuthor()}";
        }
    }
}
