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
            var convertedNumbers = GetHistoricalNumbers();

            for (var i = 1; i <= 10; i++)
                GuessTheNumbers(convertedNumbers, i);

            Console.ReadKey();
        }

        private static void GuessTheNumbers(List<LottoNumbers> convertedNumbers, int startPosition)
        {
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

            var finalCombinationNumbers = new List<int>();
            //for (int i = 1; i < 5; i += 3)
            //{
                finalCombinationNumbers.Add(topNumber1[5].Number);
                finalCombinationNumbers.Add(topNumber2[2].Number);
                finalCombinationNumbers.Add(topNumber3[3].Number);
                finalCombinationNumbers.Add(topNumber4[4].Number);
                finalCombinationNumbers.Add(topNumber5[0].Number);
                finalCombinationNumbers.Add(topNumber6[0].Number);
                finalCombinationNumbers.Add(topNumber1[2].Number);
                finalCombinationNumbers.Add(topNumber2[2].Number);
                finalCombinationNumbers.Add(topNumber3[2].Number);
            //}

            finalCombinationNumbers = finalCombinationNumbers.Take(9).ToList();

            //foreach (var finalCombinationNumber in finalCombinationNumbers.Take(9).OrderBy(i => i))
            //{
            //    Console.Write(finalCombinationNumber + " ");
            //}
            //Console.WriteLine("");

            var nextDrawLine = convertedNumbers[startPosition - 1];
            var matches = 0;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number1))
                matches++;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number2))
                matches++;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number3))
                matches++;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number4))
                matches++;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number5))
                matches++;
            if (finalCombinationNumbers.Contains(nextDrawLine.Number6))
                matches++;

            Console.WriteLine("Based off of the {0} draw, found {1} matches for the {2} draw", lastDraw.DrawDate.ToShortDateString(), matches, nextDrawLine.DrawDate.ToShortDateString());
            Console.WriteLine("");
        }

        private static List<LottoNumbers> GetHistoricalNumbers()
        {
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
            return convertedNumbers;
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
