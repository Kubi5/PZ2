using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_menagment
{
    public partial class UserEquipment : Form
    {
        public UserEquipment()
        {
            InitializeComponent();
        }

        string characterToDelete;

        private void UserEquipment_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Fighter Character");
            comboBox1.Items.Add("Nature item");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ContextActions.clearUsersItems();
            ContextActions.setUsersItems();

            if(comboBox1.Text == "Fighter Character")
            {
                foreach(string item in ContextActions.getAllUsersCharacters())
                {
                    listView1.Items.Add(item);
                }
            }
            else
            {
                foreach (string item in ContextActions.getAllUsersNature())
                {
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = listView1.SelectedItems[0];
            string[] subs = firstSelectedItem.Text.Split('-');
            characterToDelete = subs[1];
            
            DialogResult = MessageBox.Show("Are you sure to DELETE your item?", "Confirm your decision",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(DialogResult == DialogResult.Yes)
            {
                ContextActions.DeleteItem(characterToDelete);
                MessageBox.Show("Item deleted successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
