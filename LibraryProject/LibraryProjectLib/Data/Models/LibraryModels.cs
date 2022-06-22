using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectLib.Data.Models
{
    public class LibraryModels
    {
        public class User
        {
            public int UserID { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }

            public string Role { get; set; }

            public IList<Book> Books { get; set; }


            public User()
            {
                Role = "logged";
            }

           
        }
        public enum BookType
        {
            ForKids,Thriller,Tragedy,War,Horror,SciFi,Biography,Fantastic
        }

        public enum Currency
        {
            PLN,EUR,USD
        }

        public class Book
        {
            public int BookID { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Author { get; set; }
            [Required]
            public BookType BookType { get; set; }
            [Required]
            public int Price { get; set; }
            
            public Currency Currency { get; set; }
            [Required]
            public int Pages { get; set; }
            //[ForeignKey("UserID")]
            //public User user { get; set; }
            //public int? UserID { get; set; }

            public Book(int id,string title,string author, BookType booktype,int price, Currency currency,int pages)
            {
                this.BookID = id;
                this.Title = title;
                this.Author = author;
                this.BookType = booktype;
                this.Price = price;
                this.Currency = currency;
                this.Pages = pages;

            }

            public Book() { }


            public override string ToString()
            {
                return $"-{BookID}- '{Title}' - {Author}, {BookType}, Price: {Price} {Currency}, {Pages} pages";
            }

            public string BookLoanToString()
            {
                return $"-{BookID}- '{Title}' - {Author}";
            }

        }

        public class Loan
        {
            public int LoanID { get; set; }
            [Required]
            public int BookID { get; set; }
            [Required]
            public int UserID { get; set; }
            [Required]
            public DateTime DateOfLoan { get; set; }
            [Required]
            public DateTime DateOfReturn { get; set; }

            public override string ToString()
            {
                return $"{DateOfLoan} - {DateOfReturn}";
            }
        }
    }
}
