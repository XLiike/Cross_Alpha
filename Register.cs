using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Cross_Alpha
{
    public partial class Register : Form
    {
        private Tools function;
        private string name, firstname;

        public Register()
        {
            InitializeComponent();
            function = new Tools();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ArrayList Name_List = new ArrayList();
            ArrayList Firstname_List = new ArrayList();
            name = comboBox1.Text;
            Name_List = function.Read_Name(name);
            Firstname_List = function.Read_Firstname(name);
            this.comboBox1.Items.Clear();
            for (int i = 0; i < Name_List.Count; i++)
                this.comboBox1.Items.Add(Name_List[i]+" "+Firstname_List[i]);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = comboBox1.SelectedItem.ToString(); 
            firstname = comboBox1.SelectedItem.ToString();
            name = name.Split()[0];
            firstname = firstname.Remove(0, firstname.IndexOf(' ') + 1);
            string[] donnees = function.Read_Data(name, firstname);
            this.label_Name.Text = "" + name;
            this.label_Firstname.Text = "" + firstname;
            this.label_Class.Text = "" + donnees[0];
        }
    }
}