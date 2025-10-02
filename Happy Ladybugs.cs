using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
        if (b.Length == 1) return "YES"; // Single cell is happy

        Dictionary<char, int> count = new Dictionary<char, int>();
        bool hasEmpty = false;

        for (int i = 0; i < b.Length; i++)
        {
            char c = b[i];
            if (c == '_')
            {
                hasEmpty = true;
                continue;
            }

            if (!count.ContainsKey(c))
                count[c] = 0;
            count[c]++;
        }

        // Check if any ladybug has only 1 occurrence
        foreach (var kvp in count)
        {
            if (kvp.Value == 1)
                return "NO";
        }

        if (hasEmpty)
            return "YES"; // Can rearrange to make all happy

        // No empty space, check if already happy
        for (int i = 0; i < b.Length; i++)
        {
            if ((i > 0 && b[i] == b[i - 1]) || (i < b.Length - 1 && b[i] == b[i + 1]))
                continue;
            return "NO"; // Unhappy ladybug with no space to move
        }

        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
