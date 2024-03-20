class Program
{
    static int MaxEnvelopes(int[][] envelopes)
    {
        if (envelopes == null || envelopes.Length == 0)
            return 0;

        //sort by width (else by height)
        Array.Sort(envelopes, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1] - a[1];
            return a[0] - b[0];
        });

       
        int[] dp = new int[envelopes.Length];
        Array.Fill(dp, 1);

        for (int i = 1; i < envelopes.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (envelopes[i][1] > envelopes[j][1])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp.Max();
    }

    static void Main(string[] args)
    {
        int[][] envelopes1 = new int[][]
        {
            new int[] {5, 4},
            new int[] {6, 4},
            new int[] {6, 7},
            new int[] {2, 3}
        };

        int[][] envelopes2 = new int[][]
        {
            new int[] {1, 1},
            new int[] {1, 1},
            new int[] {1, 1}
        };

        Console.WriteLine(MaxEnvelopes(envelopes1)); 
        Console.WriteLine(MaxEnvelopes(envelopes2)); 
    }
}

