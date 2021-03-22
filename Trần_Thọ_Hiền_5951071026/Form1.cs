using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Trần_Thọ_Hiền_5951071026
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = DemoCURD; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
            GetStudensRecord();
        }
        public void GetStudensRecord()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsTB", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataView.DataSource = dt;
        }
        private bool IsValiData()
        {
            if(HName.Text == string.Empty
                    || NName.Text == string.Empty
                    || Adress.Text == string.Empty
                    || string.IsNullOrEmpty(Phone.Text)
                    || string.IsNullOrEmpty(Roll.Text))
            {
                MessageBox.Show("Có chổ chưa nhập dữ liệu!!! ", "Lối dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValiData())
            {
               
                SqlCommand cmd = new SqlCommand("INSERT  INTO StudentsTB(Name,FatherName,RollNumber,Address,Mobile) VALUES (@Name,@FatherName,@RollNumber,@Address,@Mobile)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", HName.Text);
                cmd.Parameters.AddWithValue("@FatherName", NName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", Roll.Text);
                cmd.Parameters.AddWithValue("@Address", Adress.Text);
                cmd.Parameters.AddWithValue("@Mobile", Phone.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudensRecord();
            }    
        }
        public int StudentID;

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text= DataView.SelectedRows[0].Cells[0].Value.ToString();
            HName.Text = DataView.SelectedRows[0].Cells[1].Value.ToString();
            NName.Text = DataView.SelectedRows[0].Cells[2].Value.ToString();
            Roll.Text = DataView.SelectedRows[0].Cells[3].Value.ToString();
            Adress.Text = DataView.SelectedRows[0].Cells[4].Value.ToString();
            Phone.Text = DataView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentTB SET "+ "Name = @Name,FatherName = @FatherName,"+"RollNumber = @RollNumber,Address  = @Address,"+"Mobile = @Mobile WHERE StudentID = @ID",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name",HName.Text);
                cmd.Parameters.AddWithValue("@FatherName", NName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", Roll.Text);
                cmd.Parameters.AddWithValue("@Address", Adress.Text);
                cmd.Parameters.AddWithValue("@Mobile", Phone.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudensRecord();
                ResetData();


            }
            else
            {
                MessageBox.Show("Cập nhập bị lỗi!!!", "Lỗi!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetData()
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(StudentID>0)
            {
                SqlCommand cmd = new SqlCommand("");
            }    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
