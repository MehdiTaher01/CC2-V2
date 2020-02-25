using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

namespace CC2_V2
{
    public partial class reservation : Form
    {
        public reservation()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=HP8470P-PC;Initial Catalog=CC2_V2;Integrated Security=True");
        private void Client_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //------Navigation------------------
                SqlCommand com = new SqlCommand("select * from Reservations", con);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                BS.DataSource = dt;
                textBox1.DataBindings.Add("Text", BS, "NReservation");
                dateTimePicker1.DataBindings.Add("Text", BS, "DateDebut");
                dateTimePicker2.DataBindings.Add("Text", BS, "DateFin");
                dateTimePicker3.DataBindings.Add("Text", BS, "DatePaye");
                textBox2.DataBindings.Add("Text", BS, "Montant");
                ComboBoxClient.DataBindings.Add("Text", BS, "CodeClient");
                ComboBoxChambre.DataBindings.Add("Text", BS, "NChambre");
                dr.Close();

                //------ComboBoxClient------------------
                SqlCommand com1 = new SqlCommand("select * from Clients", con);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    ComboBoxClient.Items.Add(dr1[0]); ;
                }
                dr1.Close();

                //------ComboBoxChambre------------------
                SqlCommand com2 = new SqlCommand("select * from Chambres", con);
                SqlDataReader dr2 = com2.ExecuteReader();
                while (dr2.Read())
                {
                    ComboBoxChambre.Items.Add(dr2[0]);
                }
                dr2.Close();


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("select * from Clients where CodeClient=" + ComboBoxClient.Text, con);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    textBox4.Text = dr1[1].ToString();
                    textBox5.Text = dr1[2].ToString();
                    textBox6.Text = dr1[7].ToString();
                }
                dr1.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxChambre_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("select * from Chambres where NChambre=" + ComboBoxChambre.Text, con);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    textBox7.Text = dr1[1].ToString();
                }
                dr1.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            textBox2.Text = "";
            ComboBoxClient.Text = "";
            ComboBoxChambre.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                TimeSpan duration = dateTimePicker2.Value - dateTimePicker1.Value ;

              

                if (duration.TotalDays > 7 )
                {

                    if (DateTime.Now.Hour.Equals(22) || DateTime.Now.Hour.Equals(23) || DateTime.Now.Hour.Equals(00) || DateTime.Now.Hour.Equals(01)
                        || DateTime.Now.Hour.Equals(02) || DateTime.Now.Hour.Equals(03) || DateTime.Now.Hour.Equals(04) || DateTime.Now.Hour.Equals(05)
                        || DateTime.Now.Hour.Equals(06) || DateTime.Now.Hour.Equals(07))
                    {
                        MessageBox.Show("pas maintenant!");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Reservations  values (" + textBox1.Text + ",'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "'," + textBox2.Text + ",'" + ComboBoxChambre.Text + "','" + ComboBoxClient.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ajout bien!");
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("duration de "+ duration.Days+ " jours, il faut au moins une semaine.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                if (DateTime.Now.Hour.Equals(22) || DateTime.Now.Hour.Equals(23) || DateTime.Now.Hour.Equals(00) || DateTime.Now.Hour.Equals(01)
                    || DateTime.Now.Hour.Equals(02) || DateTime.Now.Hour.Equals(03) || DateTime.Now.Hour.Equals(04) || DateTime.Now.Hour.Equals(05)
                    || DateTime.Now.Hour.Equals(06) || DateTime.Now.Hour.Equals(07))
                {
                    MessageBox.Show("pas maintenant!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete Reservations where NReservation=" + textBox1.Text, con);
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

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                if (DateTime.Now.Hour.Equals(22) || DateTime.Now.Hour.Equals(23) || DateTime.Now.Hour.Equals(00) || DateTime.Now.Hour.Equals(01)
                    || DateTime.Now.Hour.Equals(02) || DateTime.Now.Hour.Equals(03) || DateTime.Now.Hour.Equals(04) || DateTime.Now.Hour.Equals(05)
                    || DateTime.Now.Hour.Equals(06) || DateTime.Now.Hour.Equals(07))
                {
                    MessageBox.Show("pas maintenant!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Reservations set DateDebut='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',DateFin='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',DatePaye='" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "',Montant=" + textBox2.Text + ",NChambre='" + ComboBoxChambre.Text + "',CodeClient='" + ComboBoxClient.Text + "' where NReservation=" + textBox1.Text, con);
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

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("select * from Reservations where NReservation=" + textBox3.Text, con);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    textBox1.Text = dr1[0].ToString();
                    dateTimePicker1.Text = dr1[1].ToString();
                    dateTimePicker2.Text = dr1[2].ToString();
                    dateTimePicker3.Text = dr1[3].ToString();

                    textBox2.Text = dr1[4].ToString();

                    ComboBoxClient.Text = dr1[5].ToString();
                    ComboBoxClient.Text = dr1[6].ToString();
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
