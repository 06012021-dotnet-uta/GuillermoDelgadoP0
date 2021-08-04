using System;
using System.Collections.Generic;
using System.IO;


class Program {

    static int MOD = 1000000007;

    static long pow_mod(long x, int y, int z)
    {
        long number = 1;
        while (y > 0)
        {
            if ((y & 1) != 0) number = number * x % z;
            y >>= 1;
            x = x * x % z;
        }
        return number;
    }

    static int[,] A_table = new int[1000, 1000];

    static int A(int H, int W)
    {
        if (A_table[H - 1, W - 1] == 0)
        {   
            int i = 0;
            while (i < W && A_table[H - 1, i] != 0) i++;
            for (; i < W; i++)
            {
                int r = 0;
                if (i < 4)
                {
                    r = A_table[0, i];
                }
                else
                {
                    for (int j = i - 1; j > i - 5; j--)
                    {
                        r += A_table[0, j];
                        r %= MOD;
                    }
                    A_table[0, i] = (int)r;
                }
                A_table[H - 1, i] = (int)pow_mod(r, H, MOD);
            }
        }
        return A_table[H - 1, W - 1];
    }

    static int[,] S_table = new int[1000, 1000];

    static int S(int H, int W)
    {
        if (S_table[H - 1, W - 1] == 0)
        {
            int i = 1;
            while (S_table[H - 1, i] != 0) i++;
            for (; i < W; i++)
            {
                long sum = 0;
                long prod;
                for (int j = 1; j < i + 1; j++)
                {
                    prod = (long)S_table[H - 1, j - 1] * (long)A(H, i - j + 1);
                    prod %= MOD;
                    sum += prod;
                }
                S_table[H - 1, i] = (int)((A(H, i + 1) - sum) % MOD);
                if (S_table[H - 1, i] < 0) S_table[H - 1, i] += MOD;
            }
        }
        return S_table[H - 1, W - 1];
    }

    static void Main(string[] args)
    {
        A_table[0, 0] = 1; A_table[0, 1] = 2; A_table[0, 2] = 4; A_table[0, 3] = 8;
        for (int i = 0; i < 1000; i++)
        {
            S_table[i, 0] = 1;
        }
        S_table[0, 1] = 1; S_table[0, 2] = 1; S_table[0, 3] = 1;
        int T = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            int H = Convert.ToInt32(line[0]);
            int W = Convert.ToInt32(line[1]);
            Console.WriteLine(S(H, W));
        }
    }
}