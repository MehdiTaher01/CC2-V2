using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace CC2_V2
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=HP8470P-PC;Initial Catalog=CC2_V2;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {

            string text = textBox1.Text.Trim();
            string text1 = textBox2.Text.Trim();
            string text2 = textBox3.Text.Trim();
            string text3 = textBox4.Text.Trim();
            string text4 = textBox5.Text.Trim();
            string text5 = textBox6.Text.Trim();
            string text6 = textBox7.Text.Trim();
            string text7 = textBox8.Text.Trim();
            string text8 = textBox9.Text.Trim();
            if (text.Length != 0 && text1.Length != 0 && text2.Length != 0 && text3.Length != 0 && text4.Length != 0 && text5.Length != 0 && text6.Length != 0 && text7.Length != 0 && text8.Length != 0 && text8.Length != 0)
            {
                try
                {
                    Regex model = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (model.IsMatch(textBox9.Text))
                    {

                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Clients values(" + textBox1.Text + ",'" + textBox2.Text +
                            "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ajout bien!");
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Valider le champ email du client.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("saisie tous les champs est obligatoire.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if(MessageBox.Show("Confirmation de modification?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Clients set Nom='" + textBox2.Text +
                        "',Prenom='" + textBox3.Text +
                        "',Adresse='" + textBox4.Text +
                        "',Ville='" + textBox5.Text +
                        "',CP='" + textBox6.Text +
                        "',Pays='" + textBox7.Text +
                        "',Tel='" + textBox8.Text +
                        "',Email='" + textBox9.Text +
                        "' where CodeClient=" + textBox1.Text, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void client_Load(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                //------Navigation------------------
                SqlCommand com = new SqlCommand("select * from Clients", con);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                BS.DataSource = dt;

                
                textBox1.DataBindings.Add("Text", BS, "CodeClient");
                textBox2.DataBindings.Add("Text", BS, "Nom");
                textBox3.DataBindings.Add("Text", BS, "Prenom");
                textBox4.DataBindings.Add("Text", BS, "Adresse");
                textBox5.DataBindings.Add("Text", BS, "Ville");
                textBox6.DataBindings.Add("Text", BS, "CP");
                textBox7.DataBindings.Add("Text", BS, "Pays");
                textBox8.DataBindings.Add("Text", BS, "Tel");
                textBox9.DataBindings.Add("Text", BS, "Email");
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BS.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            BS.MovePrevious();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            BS.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            BS.MoveLast();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                if (MessageBox.Show("Confirmation de suppression?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete Clients where CodeClient=" + textBox1.Text, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suppression bien!");
                    con.Close();
                    button1_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("select * from clients where CodeClient=" + textBox10.Text, con);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    textBox1.Text = dr1[0].ToString();
                    textBox2.Text = dr1[1].ToString();
                    textBox3.Text = dr1[2].ToString();
                    textBox4.Text = dr1[3].ToString();
                    textBox5.Text = dr1[4].ToString();
                    textBox6.Text = dr1[5].ToString();
                    
                    //combobox
                    textBox7.Text = dr1[6].ToString();

                    textBox8.Text = dr1[7].ToString();
                    textBox9.Text = dr1[8].ToString();
                }
                dr1.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
