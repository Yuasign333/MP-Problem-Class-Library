using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using MP_Problem_Class_Library;


namespace Class
{
    internal class Program
    {

      // --- Static Fields (Global Data Collections) ---
     // These fields are accessible by all static methods in the Program class.

        private static Books[] bookArray;
        private static Borrowers[] borrowerList;
        static BorrowedRecord[] borrowedList;
        static int borrowedCount;


        static void Main(string[] args)
        {
            AllMethods(); // one call method
        }

        static void AllMethods()
        {

            // delcare global fields 

            bookArray = new Books[50]; // fixed 50 books
            borrowerList = new Borrowers[5]; // fixed 5 borrowers
            borrowedList = new BorrowedRecord[50]; // max 50 borrowed records
            borrowedCount = 0; // initialize borrowed count

            // method calling 

            GraphicalInterface();

            BorrowerClass(); // class method call

            BookClass(); // class method call

            BorrowedRecordClass(); // class method call

            ViewBorrowers();

            // note: othwr method calls are inside ViewBorrowers, UserLogIn and ShowMainMenu methods

        }

        static void BorrowerClass()
        {
           
            // Add Borrowers using constructor
            borrowerList[0] = new Borrowers("Mendoza","Yuan", 1);
            borrowerList[1] = new Borrowers("Magbuhos","Chris", 2);
            borrowerList[2] = new Borrowers("Velasquez","Eudrick", 3);
            borrowerList[3] = new Borrowers("Gonda","John", 4);
            borrowerList[4] = new Borrowers("Fabiculanan","Justin", 5);
       
        }


        public static void BookClass()
        {
           

            for (int i = 0; i < 50; i++)
            {
                // Prepare the dynamic data for the current book
                string title = $"Title {i + 1}";
                string author = $"Author {i + 1}";
                int year = 2000 + (i % 20);
                int idNumber = i + 1;

                // Create and assign the new Books object directly to the array index 'i'
                bookArray[i] = new Books(title, author, year, idNumber);
            }

        }
        public static void BorrowedRecordClass()
        {
            // This method is intentionally left empty as borrowed records are created dynamically during borrowing
        }

        static void GraphicalInterface()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("SISC Library Management System"); // Added full name
            Console.SetCursorPosition(80, 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("                                   ___      ___   _______  ______    _______  ______    __   __ ");
            Console.WriteLine("                                  |   |    |   | |  _    ||    _ |  |   _   ||    _ |  |  | |  |");
            Console.WriteLine("                                  |   |    |   | | |_|   ||   | ||  |  |_|  ||   | ||  |  |_|  |");
            Console.WriteLine("                                  |   |    |   | |       ||   |_||_ |       ||   |_||_ |       |");
            Console.WriteLine("                                  |   |___ |   | |  _   | |    __  ||       ||    __  ||_     _|");
            Console.WriteLine("                                  |       ||   | | |_|   ||   |  | ||   _   ||   |  | |  |   |  ");
            Console.WriteLine("                                  |_______||___| |_______||___|  |_||__| |__||___|  |_|  |___|  ");
            Console.ResetColor();
            Console.ResetColor();
            Console.SetCursorPosition(44, 25);
            Console.WriteLine("     Press any key to continue...");
            Console.ReadKey();

            Console.SetCursorPosition(49, 28);
            Console.Write("  Loading");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }

            Console.Clear();
        }
        static void ViewBorrowers()
        {
            // important ViewBorrowers method variables
            bool Yes = true;
            string input = "";

            Console.Clear();
           
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nDo you want to view the borrower database before logging in? (press Y if yes or any key if no): ");
            input = Console.ReadLine().ToUpper();
            Console.ResetColor();

            if (input == "Y")
            {
                Yes = true;
            }
            else
            {
                Yes  = false;
                UserLogin(); // enter user login method
            }
            if (Yes)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=========== BORROWER DATABASE ===========");
                Console.ResetColor();

                foreach (Borrowers borrower in borrowerList) // loop to display borrower info
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n{borrower.getBorrowerID()} - {borrower.getFullName()}");
                }
                Console.WriteLine("\nPress any key to proceed to login...");
                Console.ReadKey();
                UserLogin(); // enter user login method
            }
      

        }

 
        static void UserLogin()
        {
            // important UserLogin method variables

            bool validInput = false;
            string userName = "";

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========= LIBRARY LOGIN =========");
                Console.ResetColor();

                Console.Write("\nEnter your name (Lastname, Firstname): "); // This should be the exact format (cause this is case-sensitive)
                userName = Console.ReadLine().Trim().ToUpper();

                
                Borrowers currentUser = null;

                foreach (var borrower in borrowerList)
                {
                    // Check if borrower is not null, and if name matches any part of full name (case-insensitive)
                    if (borrower.getFullName().ToUpper().Contains(userName))
                    {
                        currentUser = borrower;

                        validInput = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nWelcome, {currentUser.getFullName()}! Your ID is {currentUser.getBorrowerID()}");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        // Pass the current user to main menu
                        ShowMainMenu(currentUser);
                        break;
                    }
                }

                  
              
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYour name is not in the library database.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                

            } while (!validInput);
        }


        static void ShowMainMenu(Borrowers currentUser)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"===== WELCOME {currentUser.getFullName()} =====");
                Console.ResetColor();

                Console.WriteLine("\n1. View Available Books");
                Console.WriteLine("\n2. Borrow Book");
                Console.WriteLine("\n3. View Borrowed Books");
                Console.WriteLine("\n4. Return Book");
                Console.WriteLine("\n5. Logout");

                Console.Write("\nSelect an option (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAvailableBooks();
                        break;
                    case "2":
                        BorrowBook(currentUser);
                        break;
                    case "3":
                        ViewBorrowedBooks(currentUser);
                        break;
                    case "4":
                        ReturnBook(currentUser);
                        break;
                    case "5":
                        Console.WriteLine("\nLogging out...");
                        Thread.Sleep(800);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
                if (exit)
                {
                    UserLogin(); // return to login screen
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have logged out. Goodbye!");
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        // method cases
        static void ViewAvailableBooks()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=========== AVAILABLE BOOKS ===========");
            Console.ResetColor();

            // Use a counter variable to track available books
            int availableBooksCount = 0;

            // Print the total size first
            Console.WriteLine($"\nTotal Books in Library: {bookArray.Length}");

            foreach (var book in bookArray)
            {
                if (book != null)
                {
                    bool isBorrowed = false;

                    // Check if the current book is in the borrowedList
                    for (int j = 0; j < borrowedCount; j++)
                    {
                        // Compare the current book object with the book object in the borrowed record
                        if (borrowedList[j] != null && borrowedList[j].GetBook() == book)
                        {
                            isBorrowed = true;
                            break;
                        }
                    }

                    if (isBorrowed)
                    {
                      
                        Console.ForegroundColor = ConsoleColor.Red;
                  
                    }
                    else
                    {
              
                        Console.ForegroundColor = ConsoleColor.Green;
                      
                        availableBooksCount++;
                    }

                    // Display the book information (will be red or green based on status)
                    Console.WriteLine(book.getFullInfo());

                    Console.ResetColor(); 
                }
            }

            // Print the summary count at the end
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n====================================================");
            Console.WriteLine($"\nTotal Books Available: {availableBooksCount}");
            Console.ResetColor();
        }
        static void BorrowBook(Borrowers currentUser)
        {
            Console.Clear();
            Console.WriteLine("=========== BORROW A BOOK ===========");

          

            // Check if user already borrowed
            bool alreadyBorrowed = false;
            for (int i = 0; i < borrowedCount; i++)
            {
                if (borrowedList[i].GetBorrower() == currentUser)
                {
                    alreadyBorrowed = true;
                    break;
                }
            }

            if (alreadyBorrowed)
            {
                Console.WriteLine("\nYou already borrowed a book. You can only borrow one.");
                Console.ReadKey();
                return;
            }

            // Show available books
            Console.WriteLine("\nAvailable books:\n");
            for (int i = 0; i < bookArray.Length; i++)
            {
                bool isBorrowed = false;
                for (int j = 0; j < borrowedCount; j++) // how many borrowed
                {
                    if (borrowedList[j].GetBook() == bookArray[i])
                    {
                        isBorrowed = true;
                        break;
                    }
                }

                if (bookArray[i] != null && isBorrowed == false) // only display the books that are not borrowed
                {
                    Console.WriteLine(bookArray[i].getFullInfo());
                }
            }

            Console.Write("\nEnter Book ID to borrow: ");
            string id = Console.ReadLine().Trim().ToUpper();

            Books selectedBook = null;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].getBookID().ToUpper() == id)
                {
                    selectedBook = bookArray[i];
                    break;
                }
            }

            if (selectedBook == null)
            {
                Console.WriteLine("\nBook not found!");
                Console.ReadKey();
                return;
            }

           

            // Add record
            borrowedList[borrowedCount] = new BorrowedRecord(currentUser, selectedBook);
            borrowedCount++;

            Console.WriteLine("\nYou successfully borrowed \"" + selectedBook.getTitle() + "\"!");
            Console.ReadKey();
        }


        static void ViewBorrowedBooks(Borrowers currentUser)
        {
            Console.Clear();
            Console.WriteLine("=========== YOUR BORROWED BOOK ===========");

            bool found = false;

            for (int i = 0; i < borrowedCount; i++)
            {
                if (borrowedList[i].GetBorrower() == currentUser)
                {
                    Console.WriteLine("\n" + borrowedList[i].GetRecordInfo());
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine("\nYou have not borrowed any books.");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        static void ReturnBook(Borrowers currentUser)
        {
            Console.Clear();
            Console.WriteLine("=========== RETURN BOOK ===========");

            int index = -1;

            for (int i = 0; i < borrowedCount; i++)
            {
                if (borrowedList[i].GetBorrower() == currentUser)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("\nYou have no borrowed book to return.");
                Console.ReadKey();
                return;
            }

            Books returnedBook = borrowedList[index].GetBook();

            // Shift array
            for (int i = index; i < borrowedCount - 1; i++)
            {
                borrowedList[i] = borrowedList[i + 1];
            }
            borrowedList[borrowedCount - 1] = null;
            borrowedCount--;

            Console.WriteLine("\nYou returned \"" + returnedBook.getTitle() + "\" successfully!");
            Console.ReadKey();
        }



    }
}
