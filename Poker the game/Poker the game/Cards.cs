using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_the_game
{
	internal class Cards
	{
		//номерные карты бубен
		static Image b2 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\2b.JPG");
		static Image b3 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\3b.JPG");
		static Image b4 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\Номерные карты\\4b.JPG");
		static Image b5 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\5b.JPG");
		static Image b6 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\6b.JPG");
		static Image b7 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\7b.JPG");
		static Image b8 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\8b.JPG");
		static Image b9 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\9b.JPG");
		static Image b10 = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Номерные карты\\10b.JPG");
		//старшие карты бубен
		static Image bA = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Старшие карты\\Ab.JPG");
		static Image bJ = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Старшие карты\\Jb.JPG");
		static Image bQ = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Старшие карты\\Kb.JPG");
		static Image bK = Image.FromFile(@"Resources\\Игральные карты\\Бубны\\Старшие карты\\Qb.JPG");

		//номерные карты крести
		static Image k2 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\2k.JPG");
		static Image k3 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\3k.JPG");
		static Image k4 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\4k.JPG");
		static Image k5 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\5k.JPG");
		static Image k6 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\6k.JPG");
		static Image k7 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\7k.JPG");
		static Image k8 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\8k.JPG");
		static Image k9 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\9k.JPG");
		static Image k10 = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Номерные карты\\10k.JPG");
		//старшие карты крести
		static Image kA = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Старшие карты\\Ak.JPG");
		static Image kJ = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Старшие карты\\Jk.JPG");
		static Image kQ = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Старшие карты\\Kk.JPG");
		static Image kK = Image.FromFile(@"Resources\\Игральные карты\\Крести\\Старшие карты\\Qk.JPG");

		//номерные карты пик
		static Image p2 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\2p.JPG");
		static Image p3 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\3p.JPG");
		static Image p4 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\4p.JPG");
		static Image p5 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\5p.JPG");
		static Image p6 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\6p.JPG");
		static Image p7 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\7p.JPG");
		static Image p8 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\8p.JPG");
		static Image p9 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\9p.JPG");
		static Image p10 = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Номерные карты\\10p.JPG");
		//старшие карты пик
		static Image pA = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Старшие карты\\Ap.JPG");
		static Image pJ = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Старшие карты\\Jp.JPG");
		static Image pQ = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Старшие карты\\Kp.JPG");
		static Image pK = Image.FromFile(@"Resources\\Игральные карты\\Пики\\Старшие карты\\Qp.JPG");

		//номерные карты червей
		static Image ch2 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\2ch.JPG");
		static Image ch3 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\3ch.JPG");
		static Image ch4 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\4ch.JPG");
		static Image ch5 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\5ch.JPG");
		static Image ch6 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\6ch.JPG");
		static Image ch7 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\7ch.JPG");
		static Image ch8 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\8ch.JPG");
		static Image ch9 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\9ch.JPG");
		static Image ch10 = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Номерные карты\\10ch.JPG");
		//старшие карты червей
		static Image chA = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Старшие карты\\Ach.JPG");
		static Image chJ = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Старшие карты\\Jch.JPG");
		static Image chQ = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Старшие карты\\Kch.JPG");
		static Image chK = Image.FromFile(@"Resources\\Игральные карты\\Черви\\Старшие карты\\Qch.JPG");

		public static Image[] Крести = { k2, k3, k4, k5, k6, k7, k8, k9, k10, kA, kJ, kQ, kK};
		public static Image[] Бубны = {b2, b3, b4, b5, b6, b7, b8, b9, b10, bA, bJ, bQ, bK};
		public static Image[] Черви = { ch2, ch3, ch4, ch5, ch6, ch7, ch8, ch9, ch10, chA, chJ, chQ, chK };
		public static Image[] Пики = { p2, p3, p4, p5, p6, p7, p8, p9, p10, pA, pJ, pQ, pK };

		public static Image[] Двойка = { b2, ch2, p2, k2 };
		public static Image[] Тройка = { b3, ch3, p3, k3 };
		public static Image[] Четверка = { b4, ch4, p4, k4 };
		public static Image[] Пятерка = { b5, ch5, p5, k5 };
		public static Image[] Шестерка = { b6, ch6, p6, k6 };
		public static Image[] Семерка = { b7, ch7, p7, k7 };
		public static Image[] Восьмерка = { b8, ch8, p8, k8 };
		public static Image[] Девятка = { b9, ch9, p9, k9 };
		public static Image[] Десятка = { b10, ch10, p10, k10 };
		public static Image[] Валет = { bJ, chJ, pJ, kJ };
		public static Image[] Дама = { bQ, chQ, pQ, kQ };
		public static Image[] Король = { bK, chK, pK, kK };
		public static Image[] Туз = { bA, chA, pA, kA };

		public static Image[] ALL = Крести.Concat(Бубны).Concat(Черви).Concat(Пики).ToArray();
	}
}
