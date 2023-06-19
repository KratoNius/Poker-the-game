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
		byte[] imageBytes;
		private void Form1_Load(object sender, EventArgs e)
		{
			string imageUrl = "https://github.com/KratoNius/Poker-the-game/blob/main/1670225311_grizly-club-p-shablon-igralnikh-kart-6.jpg";

			using (var client = new WebClient())
			{
				imageBytes = client.DownloadData(imageUrl);
			}

			using (var stream = new MemoryStream(imageBytes))
			{
				var image = Image.FromStream(stream);
				pictureBox1.Image = image;
			}
		}
	}
}
