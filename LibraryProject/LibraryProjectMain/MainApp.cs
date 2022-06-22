using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectMain
{
    public partial class MainApp : Form
    {
        Filters filters;

        public string UserRole;

        public string booktype;
        public string currency;
        public int finalminprice;
        public int finalmaxprice;
        public int finalmaxpages;
        public int finalminpages;

        Boolean defaultValuesSet;

        public MainApp(string userrole)
        {
            InitializeComponent();
            this.UserRole = userrole;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            filters = new Filters();
            filters.ShowDialog();
            this.defaultValuesSet = filters.deafautValuesSet;

            if (this.defaultValuesSet)
            {
                this.listView1.Items.Clear();
                foreach (var book in ClientOperations.getAllBooks())
                {
                    listView1.Items.Add(book);
                }
            }
            else
            {
                this.booktype = filters.booktype;
                this.currency = filters.currency;
                this.finalminprice = filters.finalminprice;
                this.finalmaxprice = filters.finalmaxprice;
                this.finalmaxpages = filters.finalmaxpages;
                this.finalminpages = filters.finalminpages;

                this.ApplyingUserFilters();
            }
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Blue;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Black;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox1.Checked = false;
            button1.Visible = false;
            label12.Visible = true;
            textBox7.Visible = true;
            button2.Visible = true;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            label12.Visible = false;
            textBox7.Visible = false;
            button1.Visible=true;
            button2.Visible=false;
        }

        public void CleanTextboxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (ClientOperations.sentBookDatatoAddition(textBox1.Text, textBox2.Text, comboBox1.Text
                , int.Parse(textBox4.Text), comboBox2.Text, int.Parse(textBox6.Text)))
            {
                MessageBox.Show("Book was successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listView1.Items.Clear();
                foreach (var book in ClientOperations.getAllBooks())
                {
                    listView1.Items.Add(book);
                }

                this.CleanTextboxes();
            }
        }

        

        private void MainApp_Load(object sender, EventArgs e)
        {

            if (this.UserRole.Equals("logged"))
            {
                panel1.Visible = true;
            }
            if (this.UserRole.Equals("ADMIN"))
            {
                panel1.Visible = false;
            }


            foreach (var book in ClientOperations.getAllBooks()) {
                listView1.Items.Add(book);
            }

            foreach (string type in ClientOperations.getBookTypes())
            {
                comboBox1.Items.Add(type);
            }

            foreach (string cur in ClientOperations.getCurrency())
            {
                comboBox2.Items.Add(cur);
            }
            
            //uzupelniam liste ksiazek usera
            /*
            foreach (Book book in ClientOperations.getLoanInfo(LoggedUser.ID))
            {
                foreach (Book book2 in ClientOperations.getBooksObject())
                {
                    if (book.BookID.Equals(book2.BookID))
                    {
                        listView2.Items.Add($"{book2.BookLoanToString()} {ClientOperations.getLoanObject(book.BookID)}");
                    }
                }
            }
            */
            
            


        }


        private void ApplyingUserFilters()
        {
            listView1.Items.Clear();

            foreach(string book in ClientOperations.getFilteredBooks(booktype,currency,
                finalminprice,finalmaxprice,finalminpages,finalmaxpages))
            {
                listView1.Items.Add(book);
            }
        }


        private void listView1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult;

            dialogResult = MessageBox.Show("Do you want to loan this book?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (dialogResult.Equals(DialogResult.OK)) {
                var firstSelectedItem = listView1.SelectedItems[0];
                string[] subs = firstSelectedItem.Text.Split('-');

                int selectedBookID = int.Parse(subs[1]);

                ClientOperations.LoanUserBook(selectedBookID,LoggedUser.ID);

                foreach (Book book in ClientOperations.getLoanInfo(LoggedUser.ID))
                {
                    foreach (Book book2 in ClientOperations.getBooksObject())
                    {
                        if (book.BookID.Equals(book2.BookID))
                        {
                            listView2.Items.Add($"{book2.BookLoanToString()} {ClientOperations.getLoanObject(book.BookID)}");
                        }
                    }
                }

                ClientOperations.RemoveBook(selectedBookID);

                listView1.Items.Clear();
                foreach (var item in ClientOperations.getBooksObject())
                {
                    listView1.Items.Add(item.ToString());
                }
            }
        }
    }
}
