using LibraryProjectMain.ServiceReference1;
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
    public partial class Filters : Form
    {
        public string booktype;
        public string currency;
        public int finalminprice;
        public int finalmaxprice;
        public int finalmaxpages;
        public int finalminpages;
        public Boolean deafautValuesSet = false;
        public Filters()
        {
            InitializeComponent();
        }

        static int minpages = ClientOperations.getPageNumbers()[0];
        static int maxpages = ClientOperations.getPageNumbers()[1];

        int pagecountmin = minpages;
        int pagecountmax = maxpages;

        int minprice;
        int maxprice;

        int pricecountmin;
        int pricecountmax;


        private void Filters_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var type in ClientOperations.getBookTypes())
            {
                comboBox1.Items.Add(type);
            }

            comboBox2.Items.Clear();
            foreach (var cur in ClientOperations.getCurrency())
            {
                comboBox2.Items.Add(cur);
            }

            label9.Text = minpages.ToString();
            label10.Text = maxpages.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: ZMIANA WALUTY WE WSZYSTKICH KSIAZKACH NA WYBRANA
            string currentcurrency = comboBox2.SelectedItem.ToString();

            List<Book> books = new List<Book>();
            Book[] copiedlistbook = new Book[ClientOperations.getBooksObject().Length];
            Array.Copy(ClientOperations.getBooksObject(),copiedlistbook, ClientOperations.getBooksObject().Length);

            switch (currentcurrency){
                case "PLN": foreach(Book book in copiedlistbook)
                    {
                        if (!book.Currency.Equals(currentcurrency))
                        {
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "EUR")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 4.68);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "USD")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 4.46);
                            }
                        }
                        books.Add(book);
                    }
                    break;
                case "EUR":
                    foreach (Book book in copiedlistbook)
                    {
                        if (!book.Currency.Equals(currentcurrency))
                        {
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "PLN")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price / 4.68);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "USD")))
                            {
                                book.Price = ((int)Math.Ceiling((double)book.Price / 1.05));
                            }
                        }
                        books.Add(book);
                    }
                    break;
                case "USD":
                    foreach (Book book in copiedlistbook)
                    {
                        if (!book.Currency.Equals(currentcurrency))
                        {
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "PLN")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price / 4.46);
                            }
                            if (book.Currency.Equals((Currency)Enum.Parse(typeof(Currency), "EUR")))
                            {
                                book.Price = (int)Math.Ceiling((double)book.Price * 1.05);
                            }
                        }
                        books.Add(book);
                    }
                    break;

            }

            minprice = books.Min(x => x.Price);
            maxprice = books.Max(x => x.Price);

            label6.Text = minprice.ToString();
            label7.Text = maxprice.ToString();

            pricecountmin = minprice;
            pricecountmax = maxprice;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(pagecountmin <= minpages)
            {
                pagecountmin = minpages;
                return;
            }

            pagecountmin -=10;
            label9.Text = pagecountmin.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pagecountmin >= pagecountmax)
            {
                pagecountmin = pagecountmax;
                return;
            }

            pagecountmin+=10;
            if(pagecountmin > pagecountmax)
            {
                pagecountmin = pagecountmax;
            }

            label9.Text = pagecountmin.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(pagecountmin >= pagecountmax)
            {
                pagecountmin = pagecountmax;
                return;
            }

            pagecountmax -= 10;
            if (pagecountmax < pagecountmin)
            {
                pagecountmax = pagecountmin;
            }

            label10.Text = pagecountmax.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pagecountmax >= maxpages)
            {
                pagecountmax = maxpages;
                return;
            }
            if (pagecountmin >= pagecountmax)
            {
                pagecountmin = pagecountmax;
                return;
            }

            pagecountmax +=10;
            label10.Text = pagecountmax.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pricecountmin <= minprice)
            {
                pricecountmin = minprice;
                return;
            }
            
            //TODO: NAPRAWIĆ TO!

            pricecountmin -= 10;
            label6.Text = pricecountmin.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(pricecountmin >= pricecountmax)
            {
                pricecountmin = pricecountmax;
                return;
            }
            pricecountmin += 10;
            if(pricecountmin > pricecountmax)
            {
                pricecountmin = pricecountmax;
            }


            label6.Text = pricecountmin.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pricecountmin >= pricecountmax)
            {
                pricecountmax = pricecountmin;
                return;
            }
            pricecountmax -=10;
            if (pricecountmax < pricecountmin)
            {
                pricecountmax = pricecountmin;
            }
            label7.Text = pricecountmax.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(pricecountmax >= maxprice)
            {
                pricecountmax = maxprice;
                return;
            }

            pricecountmax += 10;
            label7.Text = pricecountmax.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label6.Text = minprice.ToString();
            label7.Text = maxprice.ToString();
            label9.Text = minpages.ToString();
            label10.Text = maxpages.ToString();

            pagecountmax = maxpages;
            pagecountmin = minpages;

            pricecountmax = maxprice;
            pricecountmin = minprice;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Fill all the blanks!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.finalminprice = int.Parse(label6.Text);
                this.finalmaxprice = int.Parse(label7.Text);

                this.finalminpages = int.Parse(label9.Text);
                this.finalmaxpages = int.Parse(label10.Text);

                this.booktype = comboBox1.Text;
                this.currency = comboBox2.Text;
            }


            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            this.deafautValuesSet = true;

            this.Close();
        }
    }
}
