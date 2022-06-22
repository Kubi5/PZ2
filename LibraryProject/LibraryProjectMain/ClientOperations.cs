using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProjectMain.ServiceReference1;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectMain
{
    public class ClientOperations
    {

       static LibraryServiceClient client = new LibraryServiceClient();

        public static Boolean sentUserDataToService(string email,string password1,string password2)
        {
            return client.AddUserToDatabase(email,password1,password2);
        }

        public static Boolean sentUserDataToServiceSignIn(string email, string password)
        {
            return client.IfUserExist(email, password);
        }

        public static Boolean sentBookDatatoAddition(string title, string author, string type, int price, string currency, int pages)
        {
            return client.AddBookToDatabase(title, author, type, price, currency, pages);
        }

        public static string[] getAllBooks()
        {
            return client.ReturnsBooks();
        }
        public static string[] getBookTypes()
        {
            return client.ReturnBookTypes();
        }
        public static string[] getCurrency()
        {
            return client.ReturnAvailableCurrency();
        }
        public static int[] getPageNumbers()
        {
            return client.GetPageNumbers();
        }

        public static Book[] getBooksObject()
        {
            return client.GetAllBooksObject();
        }

        public static string[] getFilteredBooks(string type, string currency, int minpages, int maxpages,
            int minprice, int maxprice)
        {
            return client.GetAllFilteredBooks(type,currency,minprice,maxprice,minpages,maxpages);
        }

        public static string getUserRole(string email)
        {
            return client.getUserRole(email);
        }

        public static void AddAdmin()
        {
            client.AddAdmin();
        }

        public static bool LoanUserBook(int bookid, int userid)
        {
            return client.LoanBook(bookid,userid);
        }

        public static int getUserID(string email)
        {
            return client.ReturnUserID(email);
        }
        
        public static Book[] getLoanInfo(int userid)
        {
            return client.ReturnLoanInfo(userid);
        }

        public static void RemoveBook(int bookid)
        {
            client.RemoveBook(bookid);
        }

        public static Loan getLoanObject(int bookid)
        {
            return client.getLoanObject(bookid);
        }

        public static void clearUserBooks(int userid)
        {
            client.ClearUserBooks(userid);
        }

        public static void fillUserBooks(int userid)
        {
            client.FillUserBooks(userid);
        }

        



    }
}
