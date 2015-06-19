using System;
using System.Collections.Generic;
using System.Linq;
using LottoGenerator.Models;

namespace LottoGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const int startPosition = 1;

            var csvParser = new CsvParser<LottoNumbersCsv>();

            var numbers = csvParser.ParseAndIgnoreCsvColumnHeaders("C:\\Users\\jmunro.FBCORP\\Desktop\\lottonumbers.csv");

            var convertedNumbers = numbers.Select(n => new LottoNumbers
            {
                Bonus = Convert.ToInt32(n.Bonus),
                Number1 = Convert.ToInt32(n.Number1),
                Number2 = Convert.ToInt32(n.Number2),
                Number3 = Convert.ToInt32(n.Number3),
                Number4 = Convert.ToInt32(n.Number4),
                Number5 = Convert.ToInt32(n.Number5),
                Number6 = Convert.ToInt32(n.Number6),
                DrawDate = DateTime.Parse(n.DrawDate + " " + n.Year)
            }).ToList();

            var lastDraw = convertedNumbers[startPosition];
            var commonNumber1 = new Dictionary<int, int>();
            var commonNumber2 = new Dictionary<int, int>();
            var commonNumber3 = new Dictionary<int, int>();
            var commonNumber4 = new Dictionary<int, int>();
            var commonNumber5 = new Dictionary<int, int>();
            var commonNumber6 = new Dictionary<int, int>();

            for (var i = startPosition + 1; i < convertedNumbers.Count; i++)
            {
                var currentData = convertedNumbers[i];
                var nextDraw = convertedNumbers[i - 1];

                CompareAllNumbersForMatch(currentData, lastDraw.Number1, nextDraw, commonNumber1);
                CompareAllNumbersForMatch(currentData, lastDraw.Number2, nextDraw, commonNumber2);
                CompareAllNumbersForMatch(currentData, lastDraw.Number3, nextDraw, commonNumber3);
                CompareAllNumbersForMatch(currentData, lastDraw.Number4, nextDraw, commonNumber4);
                CompareAllNumbersForMatch(currentData, lastDraw.Number5, nextDraw, commonNumber5);
                CompareAllNumbersForMatch(currentData, lastDraw.Number6, nextDraw, commonNumber6);
            }

            var topNumber1 = GetTopNumbers(commonNumber1);
            var topNumber2 = GetTopNumbers(commonNumber2);
            var topNumber3 = GetTopNumbers(commonNumber3);
            var topNumber4 = GetTopNumbers(commonNumber4);
            var topNumber5 = GetTopNumbers(commonNumber5);
            var topNumber6 = GetTopNumbers(commonNumber6);

            var uniqueNumbers = new HashSet<int>();
            for (var i = 0; i < 8; i++)
            {
                var line = new List<int> {topNumber1[i].Number};
                GetUniqueValue(i, line, topNumber2);
                GetUniqueValue(i, line, topNumber3);
                GetUniqueValue(i, line, topNumber4);
                GetUniqueValue(i, line, topNumber5);
                GetUniqueValue(i, line, topNumber6);

                foreach (var i1 in line.OrderBy(l => l))
                {
                    Console.Write(i1 + " ");
                    if (!uniqueNumbers.Contains(i1))
                        uniqueNumbers.Add(i1);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Unique numbers: " + uniqueNumbers.Count);
            Console.ReadKey();
        }

        private static void GetUniqueValue(int i, List<int> line, List<CommonNumber> topNumber)
        {
            var j = i;
            while (line.Contains(topNumber[j].Number) && j < topNumber.Count)
                j++;
            line.Add(topNumber[j].Number);
        }

        private static List<CommonNumber> GetTopNumbers(Dictionary<int, int> commonNumber)
        {
            return commonNumber.Select(kvp => new CommonNumber
            {
                Count = kvp.Value, Number = kvp.Key
            }).OrderByDescending(c => c.Count).ToList();
        }

        private static void CompareAllNumbersForMatch(LottoNumbers currentData, int lastDraw, LottoNumbers nextDraw, Dictionary<int, int> commonNumber)
        {
            if (currentData.Number1 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number1))
                    commonNumber.Add(nextDraw.Number1, 0);

                commonNumber[nextDraw.Number1]++;
            }
            else if (currentData.Number2 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number2))
                    commonNumber.Add(nextDraw.Number2, 0);

                commonNumber[nextDraw.Number2]++;
            }
            else if (currentData.Number3 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number3))
                    commonNumber.Add(nextDraw.Number3, 0);

                commonNumber[nextDraw.Number3]++;
            }
            else if (currentData.Number4 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number4))
                    commonNumber.Add(nextDraw.Number4, 0);

                commonNumber[nextDraw.Number4]++;
            }
            else if (currentData.Number5 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number5))
                    commonNumber.Add(nextDraw.Number5, 0);

                commonNumber[nextDraw.Number5]++;
            }
            else if (currentData.Number6 == lastDraw)
            {
                if (!commonNumber.ContainsKey(nextDraw.Number6))
                    commonNumber.Add(nextDraw.Number6, 0);

                commonNumber[nextDraw.Number6]++;
            }
        }
    }
}
