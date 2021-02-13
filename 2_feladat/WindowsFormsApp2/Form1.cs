using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        string line = "";

        

        
        public void randomszamos()
        {
            

                int[] tomb = new int[10];
                int a, b;
                Random rnd = new Random();
                for (a = 0; a < 10; a++)
                {
                    tomb[a] = rnd.Next(1, 50);
                    for (b = a; b >= 0; b--)
                    {
                        if (a == b)
                        {
                            continue;
                        }
                        if (tomb[a] == tomb[b])
                        {
                            tomb[a] = rnd.Next(1, 50);
                            b = a;
                        }


                    }
                }
                using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(@"C:\BOSCH\randomszam.txt"))
                    for (a = 0; a < 10; a++)
                    {
                        file.WriteLine(tomb[a]);
                        Console.Write(tomb[a] + " ");
                    }
            
        }
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            runQuery();
        }
        private void runQuery()
        {
            string[] userid = System.IO.File.ReadAllLines("C:/BOSCH/formazott3.txt");
            string query = textBox1.Text;
            int[] useridszamok = new int[userid.Length];
            int v = 0;
            for (int l = 0; l < userid.Length; l++)
            {
                int.TryParse(userid[l], out v);
                useridszamok[l] = v;
            }
            for (int l = 0; l < useridszamok.Length; l++)
            {
                Console.WriteLine(useridszamok[l]);
            }




            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=cs_beugro";

                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);

       
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT user.name, car.brand, car.model from car inner join user_car on user_car.car = car.id inner join user on user.id = user_car.user where user.id = "+useridszamok[0]+" or user.id = "+useridszamok[1]+" or user.id = "+useridszamok[2]+" or user.id = "+useridszamok[3]+" or user.id = "+useridszamok[3]+" or user.id = "+useridszamok[4]+" or user.id = "+useridszamok[5]+" or user.id = "+useridszamok[6]+" or user.id = "+useridszamok[7]+ " or user.id = " + useridszamok[8] + " or user.id = " + useridszamok[9], databaseConnection);


                databaseConnection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, textBox1.Text);
                dataGridView1.DataSource = ds.Tables[textBox1.Text];
                databaseConnection.Close();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                using (TextWriter tw = new StreamWriter("C:/BOSCH/lekerdezes.txt"))
                {
                    tw.WriteLine("Tulajdonos\tMárka\tTípus");
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}"+"\t");

                            if (j == dataGridView1.Columns.Count - 1)
                            {
                                tw.Write("");
                            }
                        }
                        tw.WriteLine();
                    }
                }


            }


            File.Delete(@"C:/BOSCH/randomszam.txt");
            File.Delete(@"C:/BOSCH/formazott.txt");
            File.Delete(@"C:/BOSCH/formazott2.txt");
            File.Delete(@"C:/BOSCH/formazott3.txt");
            File.Delete(@"C:/BOSCH/userid.txt");



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            randomszamos();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Console.Write(" ");
        }

       


        
        
        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false; 
        }
        

      
        private void Button3_Click(object sender, EventArgs e)
        {
            {


                string szamok = File.ReadAllText(@"C:\BOSCH\randomszam.txt");
                Console.WriteLine(szamok);
                string olvass = File.ReadAllText(@"C:\BOSCH\olvass.txt");
                Console.WriteLine(olvass);


                string[] olvasss = olvass.Split(Convert.ToChar("|"));
                System.Console.WriteLine($"{olvasss.Length} words in text:");
                string fileName = @"C:\BOSCH\formazott.txt";
                FileStream stream = null;
                try
                {

                    stream = new FileStream(fileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        foreach (var word in olvasss)
                        {

                            writer.WriteLine($"{word}");
                        }

                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }



                string[] lines = System.IO.File.ReadAllLines("C:/BOSCH/formazott.txt");

                string fileNamee = @"C:\BOSCH\formazott2.txt";
                FileStream streamm = null;
                int linenumber;
                try
                {

                    streamm = new FileStream(fileNamee, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(streamm, Encoding.UTF8))
                    {
                        for (linenumber = 2; linenumber < lines.Length; linenumber++)
                        {
                            if (linenumber % 2 == 0)
                            {
                                writer.WriteLine(lines[linenumber]);
                            }
                        }


                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

                string[] randomszamok2 = System.IO.File.ReadAllLines("C:/BOSCH/randomszam.txt");
                string[] formazott2 = System.IO.File.ReadAllLines("C:/BOSCH/formazott2.txt");




                string fileNameee = @"C:\BOSCH\formazott3.txt";
                FileStream streammm = null;
                try
                {

                    streammm = new FileStream(fileNameee, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(streammm, Encoding.UTF8))
                    {


                        for (int s = 0; s < randomszamok2.Length; s++)
                        {
                            for (int r = 0; r < formazott2.Length; r++)
                            {
                                if (randomszamok2[s] == formazott2[r])
                                {
                                    writer.WriteLine(lines[r + 5]);
                                }
                            }
                        }

                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
                string[] userid = System.IO.File.ReadAllLines("C:/BOSCH/formazott3.txt");
                string fileNameeee = @"C:\BOSCH\userid.txt";
                FileStream streammmm = null;
                try
                {

                    streammmm = new FileStream(fileNameeee, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(streammmm, Encoding.UTF8))
                    {
                        for (int r = 0; r < userid.Length; r++)
                        {
                            if (userid[r] != "null")
                            {
                                writer.WriteLine(userid[r]);
                            }

                        }
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

                

            }



        }
    }
    }

