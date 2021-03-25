using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookingVideoRental
{
    public partial class mainForm : Form
    {
        // set new connection string here 
        int RentID = 0;
        String optn = "";
        String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookingVideo;Integrated Security=True";
        public mainForm()
        {
            InitializeComponent();
        }
        

        //  adding the record into the customer table in database
        private void csInfo_Add_Click(object sender, EventArgs e)
        {
            if (csInfo_Name.Text.Equals("") && csInfo_email.Text.Equals("") && csInfo_Contact.Text.Equals("") && csInfo_City.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else {
                try
                {
                   
                    string sql = "insert into Customer(Name,Email,Contact,City) values (@name,@email,@address,@city)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name",csInfo_Name.Text);
                            cmd.Parameters.AddWithValue("@email",csInfo_email.Text);
                            cmd.Parameters.AddWithValue("@address",csInfo_Contact.Text);
                            cmd.Parameters.AddWithValue("@city",csInfo_City.Text);
                            // assign value to parameter 
                            cmd.ExecuteNonQuery();

                        }
                        conn.Close();
                        MessageBox.Show("Record is inserted ");
                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";
                    }

                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //  updating the record into the customer table in database

        private void csInfo_update_Click(object sender, EventArgs e)
        {
            if (rentalInfo_csID.Text.Equals("") && csInfo_Name.Text.Equals("") && csInfo_email.Text.Equals("") && csInfo_Add.Text.Equals("") && csInfo_City.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else
            {
                try
                {
                  
                    string sql = "update Customer set Name=@name,Email=@email,Contact=@address,City=@city where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(rentalInfo_csID.Text));
                            cmd.Parameters.AddWithValue("@name", csInfo_Name.Text);
                            cmd.Parameters.AddWithValue("@email", csInfo_email.Text);
                            cmd.Parameters.AddWithValue("@address", csInfo_Contact.Text);
                            cmd.Parameters.AddWithValue("@city", csInfo_City.Text);
                            // assign value to parameter 
                            cmd.ExecuteNonQuery();

                        }
                        conn.Close();
                        MessageBox.Show("Record is updated ");
                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }
            }
        }

        //  deleting the record into the customer table in database

        private void csInfo_delete_Click(object sender, EventArgs e)
        {
            if (rentalInfo_csID.Text.Equals("") && csInfo_Name.Text.Equals("") && csInfo_email.Text.Equals("") && csInfo_Add.Text.Equals("") && csInfo_City.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else
            {
                try
                {
                  
                    string sql = "delete from Customer where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(rentalInfo_csID.Text));
            
                            cmd.ExecuteNonQuery();

                        }
                        conn.Close();
                        MessageBox.Show("Record is deleted ");
                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }
            }

        }

        //  adding the record into the video table in database

        private void viInfo_add_Click(object sender, EventArgs e)
        {
            if (videorental_ID.Equals("") && viInfo_copies.Text.Equals("") && viInfo_cost.Text.Equals("") && viInfo_Genre.Text.Equals("") && viInfo_Name.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else
            {
                try
                {
                   
                    string sql = "insert into Video(Name,Ratting,year,Cost,Copies,Genre,Plot) values (@name,@ratting,@year,@cost,@copies,@genre,@plot)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name",viInfo_Name.Text);
                            cmd.Parameters.AddWithValue("@ratting", viInfo_points.Text);
                            cmd.Parameters.AddWithValue("@year", viInfo_year.Text);
                            cmd.Parameters.AddWithValue("@cost", viInfo_cost.Text);
                            cmd.Parameters.AddWithValue("@copies",viInfo_copies.Text);
                            cmd.Parameters.AddWithValue("@genre", viInfo_Genre.Text);
                            cmd.Parameters.AddWithValue("@plot", viInfo_Plot.Text);
                           cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        MessageBox.Show("video record is saved ");

                        viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }
            }

        }

        //  delete the record into the video table in database

        private void viInfo_delete_Click(object sender, EventArgs e)
        {

            if (videorental_ID.Equals("") && viInfo_copies.Text.Equals("") && viInfo_cost.Text.Equals("") && viInfo_Genre.Text.Equals("") && viInfo_Name.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else
            {
                try
                {
                 
                    string sql = "delete from Video where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id",Convert.ToInt32(videorental_ID.Text));
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        MessageBox.Show("video record is deleted ");

                        viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }
            }
        }

        // retrun the movie to the database 

        private void return_movie_info_Click(object sender, EventArgs e)
        {
            if (RentID==0 && rentalInfo_csID.Text.Equals("") && videorental_ID.Text.Equals(""))
            {
                MessageBox.Show("must need to select the video and Customer ");
            }
            else
            {
               // try
                //{
                  
                    string sql = "update Booking set Vid=@vid,Cid=@cid,issueDate=@issueDate,ReturnDate=@returnDate where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", RentID);
                            cmd.Parameters.AddWithValue("@vid", Convert.ToInt32(videorental_ID.Text));
                            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(rentalInfo_csID.Text));
                            cmd.Parameters.AddWithValue("@issueDate", dateTimePicker1.Text);
                            cmd.Parameters.AddWithValue("@returnDate",dateTimePicker2.Text);

               
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();

                        DataTable tbl = new DataTable();
                        tbl =SelectQuery("select * from Video where id=" + Convert.ToInt32(videorental_ID.Text) + "");
                        int Cost = Convert.ToInt32(tbl.Rows[0]["Cost"].ToString());



                        //

                        DateTime current_date = DateTime.Now;

                        //convert the old date from string to Date fromat
                        DateTime prev_date = Convert.ToDateTime(dateTimePicker1.Text);


                        //get the difference in the days fromat
                        String Daysdiff = (current_date - prev_date).TotalDays.ToString();


                        // calculate the round off value 
                        Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));
                    if (DaysInterval < 1) {
                        DaysInterval = 1;
                    }

                        int Bill = Cost * Convert.ToInt32(DaysInterval);

                    MessageBox.Show("video is returned bill is $" +Bill);

                    viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";

                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";

                        RentID = 0;
                    }
                /*}
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    MessageBox.Show(msg);
                }
                */

            }

        }

        // //  updating the record into the video table in database

        private void viInfo_update_Click(object sender, EventArgs e)
        {
            if (videorental_ID.Equals("") && viInfo_copies.Text.Equals("") && viInfo_cost.Text.Equals("") && viInfo_Genre.Text.Equals("") && viInfo_Name.Text.Equals(""))
            {
                MessageBox.Show("Must need to fill the details ");
            }
            else
            {
                try
                {
                 
                    string sql = "update Video set Name=@name,Ratting=@ratting,year=@year,Cost=@cost,Copies=@copies,Genre=@genre,Plot=@plot where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(videorental_ID.Text));
                            cmd.Parameters.AddWithValue("@name", viInfo_Name.Text);
                            cmd.Parameters.AddWithValue("@ratting", viInfo_points.Text);
                            cmd.Parameters.AddWithValue("@year", viInfo_year.Text);
                            cmd.Parameters.AddWithValue("@cost", viInfo_cost.Text);
                            cmd.Parameters.AddWithValue("@copies", viInfo_copies.Text);
                            cmd.Parameters.AddWithValue("@genre", viInfo_Genre.Text);
                            cmd.Parameters.AddWithValue("@plot", viInfo_Plot.Text);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        MessageBox.Show("video record is updated ");

                        viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }
            }
        }

        // issue new movie for rent 

        private void issue_movie_info_Click(object sender, EventArgs e)
        {
            if (rentalInfo_csID.Text.Equals("") && videorental_ID.Text.Equals(""))
            {
                MessageBox.Show("must need to select the video and Customer ");
            }
            else {
                try
                {
                  
                    string sql = "insert into Booking(Vid,Cid,issueDate,ReturnDate) values(@vid,@cid,@issueDate,@returnDate)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@vid", Convert.ToInt32(videorental_ID.Text));
                            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(rentalInfo_csID.Text));
                            cmd.Parameters.AddWithValue("@issueDate", dateTimePicker1.Text);
                            cmd.Parameters.AddWithValue("@returnDate","Booked");

              
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        MessageBox.Show("video is booked  ");


                        viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";

                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";

                        RentID = 0;
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }


            }
        }

        // delete the movie info

        private void delete_movie_info_Click(object sender, EventArgs e)
        {
            if ( RentID==0 && rentalInfo_csID.Text.Equals("") && videorental_ID.Text.Equals(""))
            {
                MessageBox.Show("must need to select the video to return ");
            }
            else
            {
                try
                {
                  
                    string sql = "delete from  Booking where id=@id";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", RentID);
                            
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        MessageBox.Show("Booked Video record is deleted ");

                        viInfo_copies.Text = "";
                        viInfo_cost.Text = "";
                        viInfo_Genre.Text = "";
                        viInfo_Name.Text = "";
                        viInfo_Plot.Text = "";
                        viInfo_points.Text = "";
                        viInfo_year.Text = "";
                        videorental_ID.Text = "";

                        rentalInfo_csID.Text = "";
                        csInfo_email.Text = "";
                        csInfo_Name.Text = "";
                        csInfo_Contact.Text = "";
                        csInfo_City.Text = "";

                        RentID = 0;
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                }


            }

        }

        // changing year format

        private void viInfo_year_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(viInfo_year.Text);
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                viInfo_cost.Text = "" + cost;
            }
            catch (Exception ex)
            {

            }

        }

        // show customers from database

        private void show_customers_Click(object sender, EventArgs e)
        {

            try
            {
                optn = "customer";
              
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable tbl = new DataTable();

                    SqlCommand sqlCmd = new SqlCommand("select * from Customer", conn);

                    SqlDataReader  sqlDatareader = sqlCmd.ExecuteReader();

                    tbl.Load(sqlDatareader);



                    conn.Close();
                    dataGridView1.DataSource = tbl;
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }


        }

        // showing videos

        private void show_videos_Click(object sender, EventArgs e)
        {
            try
            {
                optn = "video";
              

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable tbl = new DataTable();

                    SqlCommand sqlCmd = new SqlCommand("select * from Video", conn);

                    SqlDataReader sqlDatareader = sqlCmd.ExecuteReader();

                    tbl.Load(sqlDatareader);



                    conn.Close();
                    dataGridView1.DataSource = tbl;
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }

        }


        // showing rental informationn

        private void show_rentals_Click(object sender, EventArgs e)
        {
            try
            {
                optn = "rental";
              

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable tbl = new DataTable();

                    SqlCommand sqlCmd = new SqlCommand("select * from Booking", conn);

                    SqlDataReader sqlDatareader = sqlCmd.ExecuteReader();

                    tbl.Load(sqlDatareader);



                    conn.Close();
                    dataGridView1.DataSource = tbl;
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }

        }


        // selecting new connection string 

        public DataTable SelectQuery(String qry)
        {
            DataTable tbl = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);


            conn.Open();
         SqlCommand   sqlCmd = new SqlCommand(qry, conn);
            SqlDataReader sqlDatareader;
               sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            conn.Close();

            return tbl;
        }


        // showing record in data gridview

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (optn.Equals("customer")) {
                rentalInfo_csID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                csInfo_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                csInfo_email.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                csInfo_Contact.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                csInfo_City.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
            else if (optn.Equals("video")) {

                videorental_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                viInfo_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
               viInfo_points.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                viInfo_Plot.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                viInfo_year.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                viInfo_cost.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                viInfo_copies.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                viInfo_Genre.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            } else if (optn.Equals("rental")) {
                RentID = Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString());    
                rentalInfo_csID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                videorental_ID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


            }
            optn = "";
        }


        // function showing best customer

        private void show_best_customer_Click(object sender, EventArgs e)
        {

            
            DataTable tbl = new DataTable();

            tbl =SelectQuery("select * from Customer");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 =SelectQuery("select * from Booking where Cid='" + tbl.Rows[x]["id"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tbl.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Popular Customer Name is " + Title);
        }

        // function showing best movie

        private void showbestMovie_Click(object sender, EventArgs e)
        {

            DataTable tbl = new DataTable();

            tbl = SelectQuery("select * from Video");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = SelectQuery("select * from Booking where Vid='" + tbl.Rows[x]["id"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tbl.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Popular Video Name is " + Title);
        }

        private void csInfo_Contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
