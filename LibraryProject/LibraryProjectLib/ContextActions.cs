using LibraryProjectLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectLib
{
    internal class ContextActions
    {
        static LibraryContext context = new LibraryContext();

        public static void AddUsertoDB(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public static bool IsEmailAlreadyinDatabase(string email)
        {
            var user = context.Users
                            .Where(x => x.Email == email);

            return user.Any();
        }
        public static bool isEmailandPasswordinDB(string email, string password)
        {
            var userpassword = context.Users
                            .Where(x => x.Email == email)
                            .Select(x => x.Password);

            string hashedPassword = SafetySystem.hashingPassword(password);

            foreach (string var in userpassword)
            {
                return hashedPassword.Equals(var);
            }

            return false;
        }

        public static bool AddBooktoDatabase(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return true;
        }

        public static List<string> ReturnBooks()
        {
            List<string> returnBooks = new List<string>();

            var books = context.Books
                .Select(x => x);

            foreach (var book in books)
            {
                returnBooks.Add(book.ToString());
            }

            return returnBooks;
        }

        public static List<int> GetPageNumbers()
        {
            List<int> pricepages = new List<int>();

            int maxpages = context.Books
                .Max(x => x.Pages);

            int minpages = context.Books
                .Min(x => x.Pages);

            pricepages.Add(minpages);
            pricepages.Add(maxpages);

            return pricepages;

        }

        public static List<Book> getBooksObject()
        {
            var books = context.Books
                .Select(x => x)
                .ToList();

            return books;
        }

        public static List<string> getFilteredBooks(string type,string currency,int minpages,int maxpages,
            int minprice,int maxprice)
        {

            Boolean ifBookwasAdded = false;
            //TODO: biore liste ksiazek zmieniam im walute a pozniej dopiero filtruje max cena itd musze wziac najpierw
            //walute ksiazki i pozniej zmieniam i leci se nie?
            List<string> returnlist = new List<string>();
            List<Book> books = new List<Book>();
            //po to zeby nie modyfikowac tamtej orygianlnej listy
            List<Book> newlist = context.Books.Select(x => new Book(x.BookID,x.Title,x.Author,x.BookType,x.Price,x.Currency,x.Pages)).ToList();
            List<Book> booksobjectOnlyForThisMethod = new List<Book>(ContextActions.getBooksObject());


            foreach (Book book in booksobjectOnlyForThisMethod)
            {
                if (!(book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), currency)))) {

                    switch (currency)
                    {
                        case "PLN":

                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "EUR")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 4.68);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "USD")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 4.46);
                            }

                            books.Add(book);
                            ifBookwasAdded = true;
                            break;

                        case "EUR":

                            
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "PLN")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price / 4.68);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "USD")))
                            {
                                book.Price = ((int)Math.Ceiling((double)book.Price / 1.05));
                            }

                            books.Add(book);
                            ifBookwasAdded = true;
                            break;

                        case "USD":

                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "PLN")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price / 4.46);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "EUR")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 1.05);
                            }

                            books.Add(book);
                            ifBookwasAdded = true;
                            break;
                    }
                    
                }
                //i tak dodaje ta ksiazke ktora ma ta sama walute 
                if (!ifBookwasAdded)
                {
                    books.Add(book);
                }

                ifBookwasAdded = false;

            }

             var filteredbooks=   books
                .Where(x => x.BookType.Equals((BookType)Enum.Parse(typeof(BookType), type)) &&
                x.Price >= minprice && x.Price <= maxprice &&
                x.Pages >= minpages && x.Pages <= maxpages)
                .Select(x => x);

            //przeiteruj se pozniej po books i porownuj indeksy z cala baza ksiazek i wybieraj tylko te wybrane 
            //do wyswietlenia
                
            foreach(Book book in filteredbooks)
            {
                foreach(Book book2 in newlist)
                {
                    if (book.BookID.Equals(book2.BookID))
                    {
                        returnlist.Add(book2.ToString());
                    }

                }
            }

            return returnlist;

        }

        public static string ReturnRole(string email)
        {
            var list = context.Users.Where(x => x.Email == email).Select(x => x.Role);
            return list.FirstOrDefault();
        }

        public static void AddAdmin()
        {
            User admin = new User();
            admin.Email = "ADMIN";
            admin.Password = SafetySystem.hashingPassword("ADMIN");
            admin.Role = "ADMIN";

            context.Users.Add(admin);
            context.SaveChanges();
        }

        public static bool LoanUserBook(int bookid, int userid)
        {
            DateTime now = DateTime.Now;
            //dodaje ksiazke do usera
            User user = context.Users.Where(x => x.UserID.Equals(userid)).FirstOrDefault();
            var book = context.Books.Where(x => x.BookID.Equals(bookid)).Select(x=>x).FirstOrDefault();
            //book.UserID = userid;
            user.Books.Add(book);
            //dodaje pozyczona ksiazke
            Loan loan = new Loan();
            loan.UserID = userid;
            loan.BookID = bookid;
            loan.DateOfLoan = now;
            loan.DateOfReturn = now.AddMonths(3);
            context.Loans.Add(loan);
            //usuwam ksiazke z biblioteki (MyLibrary)
            //context.Books.Remove(context.Books.Where(x => x.BookID.Equals(bookid)).FirstOrDefault());

            context.SaveChanges();

            return true;
        }

        public static int ReturnUserID(string email)
        {
            var list = context.Users.Where(x => x.Email == email).Select(x => x.UserID);
            return list.FirstOrDefault();
        }

        public static List<Book> ReturnLoanInfo(int userid)
        {
            return context.Users.Find(userid).Books.Select(x => x).ToList();
        }

        public static void RemoveBook(int bookid)
        {
            context.Books.Remove(context.Books.Where(x => x.BookID.Equals(bookid)).SingleOrDefault());
            context.SaveChanges();
        }

        public static Loan getLoanObject(int bookid)
        {
            Loan loan = context.Loans.Where(x => x.BookID.Equals(bookid)).Select(x => x).FirstOrDefault();

            return loan;
        }

        public static void FillUserBooks(int userid)
        {
            /*
           // var books = context.Loans()

            foreach(var book in books)
            {
                context.Users.Find(userid).Books.Add(book);
            }
            */
        }

        public static void ClearUserBooks(int userid)
        {
            var user = context.Users.Find(userid);

            user.Books = new List<Book>();
            user.Books.Clear();
            
        }

    }
}
