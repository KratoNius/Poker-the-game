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
		void Mass()
		{
			foreach (var image in Cards.allImages) 
			{
				int index1 = random.Next(Cards.allImages.Length);
				int index2 = random.Next(Cards.allImages.Length);
				int index3 = random.Next(Cards.allImages.Length);
				pictureBox1.Image = Cards.allImages[index1];
				pictureBox2.Image = Cards.allImages[index2];
				pictureBox3.Image = Cards.allImages[index3];
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Mass();	
		}
	}
}
