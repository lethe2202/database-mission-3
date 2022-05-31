using System;
using MySql.Data.MySqlClient;
namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            readdatabase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void readdatabase()
        {
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=student;";
            
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                string sql = "select * from student";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("s_id");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("s_name");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("s_birth");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetString("s_sex");


                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



