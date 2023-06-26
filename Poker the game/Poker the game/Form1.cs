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
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using DrawingImage = System.Drawing.Image;
using MediaTypeNamesImage = System.Net.Mime.MediaTypeNames.Image;
using static System.Net.Mime.MediaTypeNames;
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
		double xp;
		public class Card
		{
			public string Suit { get; set; }
			public string Value { get; set; }
			public DrawingImage Image { get; set; }

			// метод загрузки изображения карты
			public void LoadImage()
			{
				string imageName = $"{Value}_of_{Suit}.png"; // имя файла изображения карты
				Image = System.Drawing.Image.FromFile(imageName); // загрузка изображения из файла
			}
		}

		// метод для определения комбинации карт
		public static List<Card> GetBestHand(List<Card> playerCards, List<Card> tableCards)
		{
			List<Card> cards = new List<Card>();
			cards.AddRange(playerCards);
			cards.AddRange(tableCards);

			// Сортировка карт по достоинству
			cards.Sort((card1, card2) => CardValueToInt(card2.Value).CompareTo(CardValueToInt(card1.Value)));

			// Поиск комбинаций
			List<Card> bestHand = null;
			foreach (List<Card> hand in GetAllPossibleHands(cards))
			{
				if (bestHand == null || CompareHands(hand, bestHand) > 0)
				{
					bestHand = hand;
				}
			}

			return bestHand;
		}

		// метод для получения всех возможных комбинаций из пяти карт
		private static List<List<Card>> GetAllPossibleHands(List<Card> cards)
		{
			List<List<Card>> hands = new List<List<Card>>();
			for (int i = 0; i < cards.Count - 4; i++)
			{
				for (int j = i + 1; j < cards.Count - 3; j++)
				{
					for (int k = j + 1; k < cards.Count - 2; k++)
					{
						for (int m = k + 1; m < cards.Count - 1; m++)
						{
							for (int n = m + 1; n < cards.Count; n++)
							{
								List<Card> hand = new List<Card>();
								hand.Add(cards[i]);
								hand.Add(cards[j]);
								hand.Add(cards[k]);
								hand.Add(cards[m]);
								hand.Add(cards[n]);
								hands.Add(hand);
							}
						}
					}
				}
			}
			return hands;
		}

		// метод для сравнения двух комбинаций и определения наилучшей
		private static int CompareHands(List<Card> hand1, List<Card> hand2)
		{
			int rank1 = GetRank(hand1);
			int rank2 = GetRank(hand2);

			if (rank1 > rank2)
			{
				return 1;
			}
			else if (rank2 > rank1)
			{
				return -1;
			}
			else
			{
				// если ранги равны, сравниваем по старшим карта
				for (int i = 0; i < 5; i++)
				{
					int value1 = CardValueToInt(hand1[i].Value);
					int value2 = CardValueToInt(hand2[i].Value);
					if (value1 > value2)
					{
						return 1;
					}
					else if (value2 > value1)
					{
						return -1;
					}
				}
				// если старшие карты тоже равны, то комбинации равны
				return 0;
			}
		}

		// метод для определения ранга комбинации
		private static int GetRank(List<Card> hand)
		{
			if (IsRoyalFlush(hand))
			{
				return 10;
			}
			else if (IsStraightFlush(hand))
			{
				return 9;
			}
			else if (IsFourOfAKind(hand))
			{
				return 8;
			}
			else if (IsFullHouse(hand))
			{
				return 7;
			}
			else if (IsFlush(hand))
			{
				return 6;
			}
			else if (IsStraight(hand))
			{
				return 5;
			}
			else if (IsThreeOfAKind(hand))
			{
				return 4;
			}
			else if (IsTwoPairs(hand))
			{
				return 3;
			}
			else if (IsOnePair(hand))
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}

		// методы для определения наличия комбинации
		private static bool IsRoyalFlush(List<Card> hand)
		{
			for (int i = 0; i < 5; i++)
			{
				if (hand[i].Value != "10" && hand[i].Value != "Jack" && hand[i].Value != "Queen" && hand[i].Value != "King" && hand[i].Value != "Ace")
				{
					return false;
				}
			}
			return IsFlush(hand);
		}

		private static bool IsStraightFlush(List<Card> hand)
		{
			return IsFlush(hand) && IsStraight(hand);
		}

		private static bool IsFourOfAKind(List<Card> hand)
		{
			return CountValues(hand)[0] == 4;
		}

		private static bool IsFullHouse(List<Card> hand)
		{
			int[] values = CountValues(hand);
			return values[0] == 3 && values[1] == 2;
		}

		private static bool IsFlush(List<Card> hand)
		{
			return hand.All(c => c.Suit == hand[0].Suit);
		}

		private static bool IsStraight(List<Card> hand)
		{
			int[] values = CountValues(hand);
			return values[0] - values[4] == 4 || (values[0] == 14 && values[1] == 5 && values[2] == 4 && values[3] == 3 && values[4] == 2);
		}

		private static bool IsThreeOfAKind(List<Card> hand)
		{
			return CountValues(hand)[0] == 3;
		}

		private static bool IsTwoPairs(List<Card> hand)
		{
			int[] values = CountValues(hand);
			return values[0] == 2 && values[1] == 2;
		}

		private static bool IsOnePair(List<Card> hand)
		{
			return CountValues(hand)[0] == 2;
		}

		// метод для подсчета количества карт каждого достоинства
		private static int[] CountValues(List<Card> hand)
		{
			var groups = hand.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).ThenByDescending(g => CardValueToInt(g.Key)).Select(g => g.Count());
			return groups.Concat(Enumerable.Repeat(0, 5 - groups.Count())).ToArray();
		}

		// метод для преобразования значения карты в число (для сравнения)
		private static int CardValueToInt(string value)
		{
			switch (value)
			{
				case "Ace":
					return 14;
				case "King":
					return 13;
				case "Queen":
					return 12;
				case "Jack":
					return 11;
				default:
					return int.Parse(value);
			}
		}


		
		private void Form1_Load(object sender, EventArgs e)
		{

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
			
			
		}

		private void button4_Click(object sender, EventArgs e)
		{
			
			
		}
	}
}
