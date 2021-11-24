using System;
using System.Linq;
using System.Collections.Generic;

namespace PAROSOCHETANIE
{
	class Program
	{
		static void Main(string[] args)
		{
			int n, k;
			int[][] g; //ребра из левой части в правую
			int[] mt; //с какой вершиной соединена вершина из правой доли 
			bool[] used;

			string[] str = Console.ReadLine().Split(" ");
			n = Convert.ToInt32(str[0]);
			k = Convert.ToInt32(str[1]);
			g = new int[n][];

			for (int i = 0; i < n; i++)
			{
				str = Console.ReadLine().Split(" ");
				List<int> stroka = new List<int>();

				foreach (string num in str)
				{
					int int_num = Convert.ToInt32(num);
					if (int_num == 0) break;
					int_num--;
					stroka.Add(int_num);
				}
				g[i] = stroka.ToArray();
			}

			mt = Enumerable.Repeat(-1, k).ToArray();

			for (int v = 0; v < n; v++)
			{
				used = Enumerable.Repeat(false, n).ToArray(); ;
				try_kuhn(v);
			}

			int count = 0;
			for (int i = 0; i < k; i++)
            {
				if (mt[i] != -1) count++;
			}
			Console.WriteLine(count);

			for (int i = 0; i < k; i++)
				if (mt[i] != -1)
					Console.WriteLine(Convert.ToString(mt[i] + 1) + " " + Convert.ToString(i + 1));


			bool try_kuhn(int v)
			{
				if (used[v]) return false;
				used[v] = true;
				for (int i = 0; i < g[v].Length; i++)
				{
					int to = g[v][i];
					if (mt[to] == -1 || try_kuhn(mt[to]))
					{
						mt[to] = v;
						return true;
					}
				}
				return false;
			}
		}
	}
}
