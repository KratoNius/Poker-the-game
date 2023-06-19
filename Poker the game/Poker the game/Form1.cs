using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_the_game
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		Random random = new Random();
		int Max_fishki = 200;
		void FLOP()
		{
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
			MessageBox.Show("Игра началась! Время раздачи карт игрокам!");
			label1.BackColor = Color.Transparent;
			pictureBox1.Visible = false;
			pictureBox2.Visible = false;
			pictureBox3.Visible = false;
			pictureBox4.Visible = false;
			pictureBox5.Visible = false;
			//CARD();
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

		}
	}
}
