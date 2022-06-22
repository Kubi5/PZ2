using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectLib
{
    public class LibraryService : ILibraryService
    {
        public Boolean AddUserToDatabase(string email, string password1,string password2)
        {
            if (ContextActions.IsEmailAlreadyinDatabase(email))
            {
                return false;
            }

            if (SafetySystem.arePasswordtheSame(password1, password2) &&
               SafetySystem.isEmailValid(email) && SafetySystem.isPasswordValid(password1))
            {
                User user = new User();
                user.Email = email;
                user.Password = SafetySystem.hashingPassword(password1);
                ContextActions.AddUsertoDB(user);

                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean IfUserExist(string email, string password)
        {
            if (ContextActions.isEmailandPasswordinDB(email, password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean AddBookToDatabase(string title, string author, string type, int price, string currency, int pages)
        {
            Book book = new Book();

            book.Title = title;
            book.Author = author;

            BookType bookType = (BookType)Enum.Parse(typeof(BookType), type);
            foreach (BookType enum_ in Enum.GetValues(typeof(BookType)))
            {
                if (enum_.Equals(bookType))
                {
                    book.BookType = enum_;
                }
            }

            book.Price = price;
            Currency currencyType = (Currency)Enum.Parse(typeof(Currency), currency);
            foreach (Currency enum_ in Enum.GetValues(typeof(Currency)))
            {
                if (enum_.Equals(currencyType))
                {
                    book.Currency = enum_;
                }
            }

            book.Pages = pages;

            ContextActions.AddBooktoDatabase(book);

            return true;
        }

        public List<string> ReturnsBooks()
        {
            return ContextActions.ReturnBooks();
        }

        public List<string> ReturnBookTypes()
        {
            List<string> bookTypes = new List<string>();
            foreach(string type in Enum.GetNames(typeof(BookType))){
                bookTypes.Add(type);
            }

            return bookTypes;
        }

        public List<string> ReturnAvailableCurrency()
        {
            List<string> cur = new List<string>();
            foreach (string type in Enum.GetNames(typeof(Currency))){
                cur.Add(type);
            }

            return cur;
        }

        public List<int> GetPageNumbers()
        {
            return ContextActions.GetPageNumbers();
        }
        
        public List<Book> GetAllBooksObject()
        {
            return ContextActions.getBooksObject();
        }

        public List<string> GetAllFilteredBooks(string type, string currency, int minpages, int maxpages,
            int minprice, int maxprice)
        {
            return ContextActions.getFilteredBooks(type, currency,minpages, maxpages, minprice,maxprice);
        }

        public string getUserRole(string email)
        {
            return ContextActions.ReturnRole(email);
        }

        public void AddAdmin()
        {
            ContextActions.AddAdmin();
        }

        public Boolean LoanBook(int userid, int bookid)
        {
            return ContextActions.LoanUserBook(userid, bookid);
        }

        public int ReturnUserID(string email)
        {
            return ContextActions.ReturnUserID(email);
        }

        public List<Book> ReturnLoanInfo(int userid)
        {
            var x = ContextActions.ReturnLoanInfo(userid);
            return x;
          
        }

        public void RemoveBook(int bookid)
        {
            ContextActions.RemoveBook(bookid);
        }


        public Loan getLoanObject(int bookid)
        {
            return ContextActions.getLoanObject(bookid);
        }

        public void ClearUserBooks(int userid)
        {
            ContextActions.ClearUserBooks(userid);
        }

        public void FillUserBooks(int userid)
        {
            ContextActions.FillUserBooks(userid);
        }
    }
}
