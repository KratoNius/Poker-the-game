using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Poker_the_game
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private readonly string path = "config.txt";
		Random random = new Random();
		MySqlDataAdapter adapterMain;
		DataTable dtMain;
		MySqlCommand Command;
		int Max_fishki = 200;
		double xp;
		void FLOP()
		{
			
				//флоп
				foreach (var image in Cards.allImages)
				{
					//флоп
					int indexF1 = random.Next(Cards.allImages.Length);
					int indexF2 = random.Next(Cards.allImages.Length);
					int indexF3 = random.Next(Cards.allImages.Length);
					pictureBox1.Image = Cards.allImages[indexF1];
					pictureBox2.Image = Cards.allImages[indexF2];
					pictureBox3.Image = Cards.allImages[indexF3];

				}

			
		}
		void CARD()
		{
			//раздача карт игрокам
			int indexCD1 = random.Next(Cards.allImages.Length);
			int indexCD2 = random.Next(Cards.allImages.Length);
			int indexCD3 = random.Next(Cards.allImages.Length);
			int indexCD4 = random.Next(Cards.allImages.Length);
			int indexCD5 = random.Next(Cards.allImages.Length);
			int indexCD6 = random.Next(Cards.allImages.Length);
			int indexCD7 = random.Next(Cards.allImages.Length);
			int indexCD8 = random.Next(Cards.allImages.Length);
			//1 игрок
			pictureBox6.Image = Cards.allImages[indexCD1];
			pictureBox7.Image = Cards.allImages[indexCD2];
			//2 игрок
			pictureBox12.Image = Cards.allImages[indexCD3];
			pictureBox13.Image = Cards.allImages[indexCD4];
			//3 игрок
			pictureBox14.Image = Cards.allImages[indexCD5];
			pictureBox15.Image = Cards.allImages[indexCD6];
			//4 игрок
			pictureBox20.Image = Cards.allImages[indexCD7];
			pictureBox21.Image = Cards.allImages[indexCD8];

			

		}
		void tirn()
		{
			//терн
			int indexCD1 = random.Next(Cards.allImages.Length);
			pictureBox4.Image = Cards.allImages[indexCD1];
			
		}
		void river()
		{
			//ривер
			int indexCD2 = random.Next(Cards.allImages.Length);
			pictureBox5.Image = Cards.allImages[indexCD2];
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			progressBar1.Minimum = 0;
			string text = "";
			MySqlConnection conn = new MySqlConnection();
			using (StreamReader reader = new StreamReader(path))
			{
				text = reader.ReadToEnd();
				conn = new MySqlConnection(text);
			}
			MessageBox.Show("Игра началась! Время раздачи карт игрокам!");
			label1.BackColor = Color.Transparent;
			pictureBox1.Visible = false;
			pictureBox2.Visible = false;
			pictureBox3.Visible = false;
			pictureBox4.Visible = false;
			pictureBox5.Visible = false;
			CARD();
			pictureBox12.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
			pictureBox13.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
			pictureBox14.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
			pictureBox15.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

			pictureBox12.Invalidate();
			pictureBox13.Invalidate();
			pictureBox14.Invalidate();
			pictureBox15.Invalidate();
			MessageBox.Show("У всех по 200 фишек");
			label1.Text = label1.Text+"0";

			label5.Text = label5.Text + Max_fishki.ToString();
			label2.Text = label2.Text + Max_fishki.ToString();
			label7.Text = label7.Text + Max_fishki.ToString();
			label9.Text = label9.Text + Max_fishki.ToString();

			label4.Text = label4.Text + "0";
			label8.Text = label8.Text + "0";
			label6.Text = label6.Text + "0";
			label3.Text = label3.Text + "0";
			conn.Open();
			string combox1 = "SELECT `Требование к уровню` FROM `уровни` WHERE id=1";
			MySqlCommand command1 = new MySqlCommand(combox1, conn);
			command1.CommandTimeout = 0;
			MySqlDataReader reader1 = command1.ExecuteReader();
			while (reader1.Read())
			{
				progressBar1.Maximum = Convert.ToInt32(reader1[0]);
				label11.Text = reader1[0].ToString() + " xp";

			}
			reader1.Close();
			conn.Close();

			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string text = "";
			MySqlConnection conn = new MySqlConnection();
			using (StreamReader reader = new StreamReader(path))
			{
				text = reader.ReadToEnd();
				conn = new MySqlConnection(text);
			}
			xp += 100;
			Command = new MySqlCommand();
			conn.Open();
			Command = conn.CreateCommand();
			Command.CommandText = "INSERT INTO `dbpok`.`прогресc`\r\n(`Прогресc`)\r\nVALUES\r\n(\""+xp.ToString()+"\");";
			Command.ExecuteNonQuery();

			string combox1 = "SELECT `Требование к уровню` FROM `уровни` WHERE id=1";
			MySqlCommand command1 = new MySqlCommand(combox1, conn);
			command1.CommandTimeout = 0;
			MySqlDataReader reader1 = command1.ExecuteReader();
			while (reader1.Read())
			{
				progressBar1.Maximum = Convert.ToInt32(reader1[0]);
				label11.Text = reader1[0].ToString() + " xp";

			}
			reader1.Close();
			conn.Close();

			conn.Open();
			string combox2 = "SELECT `Прогресc` FROM `прогресc` WHERE id=1";
			MySqlCommand command2 = new MySqlCommand(combox2, conn);
			command2.CommandTimeout = 0;
			MySqlDataReader reader2 = command2.ExecuteReader();
			while (reader2.Read())
			{
				double fieldValue = reader2.GetDouble(0);
				progressBar1.Value = (int)Math.Round((fieldValue / progressBar1.Maximum) * progressBar1.Maximum);
			}

			reader2.Close();
			conn.Close();
			string str = label11.Text;
			double n = Convert.ToDouble(str.Substring(0, str.Length - 3));
			double num = n - progressBar1.Value;
			label11.Text = num.ToString();

		}

		private void progressBar1_BackColorChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Help help = new Help();
			help.ShowDialog();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				//this.Hide();
				this.Close();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox1.Visible = true;
			pictureBox2.Visible = true;
			pictureBox3.Visible = true;
			pictureBox4.Visible = true;
			pictureBox5.Visible = true;
			FLOP();
			tirn();
			river();
		}
	}
}
