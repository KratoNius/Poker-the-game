﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_the_game
{
	public partial class Help : Form
	{
		public Help()
		{
			InitializeComponent();
		}

		private void Help_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

		private void Help_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				//this.Hide();
				this.Close();
			}
		}
	}
}
