using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ILibraryService
    {
        [OperationContract]
        Boolean AddUserToDatabase(string email,string password1,string password2);
        [OperationContract]
        Boolean IfUserExist(string email, string password);
        [OperationContract]
        Boolean AddBookToDatabase(string title, string author,string type,int price,string currency,int pages);
        [OperationContract]
        List<string> ReturnsBooks();
        [OperationContract]
        List<string> ReturnBookTypes();
        [OperationContract]
        List<string> ReturnAvailableCurrency();
        [OperationContract]
        List<int> GetPageNumbers();
        [OperationContract]
        List<Book> GetAllBooksObject();
        [OperationContract]
        List<string> GetAllFilteredBooks(string type, string currency, int minpages, int maxpages,
            int minprice, int maxprice);
        [OperationContract]
        string getUserRole(string email);
        [OperationContract]
        void AddAdmin();
        [OperationContract]
        Boolean LoanBook(int userid, int bookid);
        [OperationContract]
        int ReturnUserID(string email);
        [OperationContract]
        List<Book> ReturnLoanInfo(int userid);
        [OperationContract]
        void RemoveBook(int bookid);
        [OperationContract]
        Loan getLoanObject(int bookid);
        [OperationContract]
        void ClearUserBooks(int userid);
        [OperationContract]
        void FillUserBooks(int userid);
    }

}
