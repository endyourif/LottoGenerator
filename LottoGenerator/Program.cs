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

            var lastDraw = convertedNumbers.First();
            var commonNumber1 = new Dictionary<int, int>();
            var commonNumber2 = new Dictionary<int, int>();
            var commonNumber3 = new Dictionary<int, int>();
            var commonNumber4 = new Dictionary<int, int>();
            var commonNumber5 = new Dictionary<int, int>();
            var commonNumber6 = new Dictionary<int, int>();

            for (var i = 1; i < convertedNumbers.Count; i++)
            {
                var currentData = convertedNumbers[i];
                if (currentData.Number1 == lastDraw.Number1)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber1.ContainsKey(nextDraw.Number1))
                        commonNumber1.Add(nextDraw.Number1, 0);

                    commonNumber1[nextDraw.Number1]++;
                }
                if (currentData.Number2 == lastDraw.Number2)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber2.ContainsKey(nextDraw.Number2))
                        commonNumber2.Add(nextDraw.Number2, 0);

                    commonNumber2[nextDraw.Number2]++;
                }
                if (currentData.Number3 == lastDraw.Number3)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber3.ContainsKey(nextDraw.Number3))
                        commonNumber3.Add(nextDraw.Number3, 0);

                    commonNumber3[nextDraw.Number3]++;
                }
                if (currentData.Number4 == lastDraw.Number4)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber4.ContainsKey(nextDraw.Number4))
                        commonNumber4.Add(nextDraw.Number4, 0);

                    commonNumber4[nextDraw.Number4]++;
                }
                if (currentData.Number5 == lastDraw.Number5)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber5.ContainsKey(nextDraw.Number5))
                        commonNumber5.Add(nextDraw.Number5, 0);

                    commonNumber5[nextDraw.Number5]++;
                }
                if (currentData.Number6 == lastDraw.Number6)
                {
                    var nextDraw = convertedNumbers[i - 1];
                    if (!commonNumber6.ContainsKey(nextDraw.Number6))
                        commonNumber6.Add(nextDraw.Number6, 0);

                    commonNumber6[nextDraw.Number6]++;
                }
            }

            var topNumber1 = new List<CommonNumber>();
            foreach (var kvp in commonNumber1)
            {
                topNumber1 = topNumber1.OrderByDescending(c => c.Count).ToList();

                if (topNumber1.Count < 5)
                    topNumber1.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber1[4].Count)
                    {
                        topNumber1[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }
            var topNumber2 = new List<CommonNumber>();
            foreach (var kvp in commonNumber2)
            {
                topNumber2 = topNumber2.OrderByDescending(c => c.Count).ToList();

                if (topNumber2.Count < 5)
                    topNumber2.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber2[4].Count)
                    {
                        topNumber2[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }
            var topNumber3 = new List<CommonNumber>();
            foreach (var kvp in commonNumber3)
            {
                topNumber3 = topNumber3.OrderByDescending(c => c.Count).ToList();

                if (topNumber3.Count < 5)
                    topNumber3.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber3[4].Count)
                    {
                        topNumber3[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }
            var topNumber4 = new List<CommonNumber>();
            foreach (var kvp in commonNumber4)
            {
                topNumber4 = topNumber4.OrderByDescending(c => c.Count).ToList();

                if (topNumber4.Count < 5)
                    topNumber4.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber4[4].Count)
                    {
                        topNumber4[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }
            var topNumber5 = new List<CommonNumber>();
            foreach (var kvp in commonNumber5)
            {
                topNumber5 = topNumber5.OrderByDescending(c => c.Count).ToList();

                if (topNumber5.Count < 5)
                    topNumber5.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber5[4].Count)
                    {
                        topNumber5[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }
            var topNumber6 = new List<CommonNumber>();
            foreach (var kvp in commonNumber6)
            {
                topNumber6 = topNumber6.OrderByDescending(c => c.Count).ToList();

                if (topNumber6.Count < 5)
                    topNumber6.Add(new CommonNumber
                    {
                        Count = kvp.Value,
                        Number = kvp.Key
                    });
                else
                {
                    if (kvp.Value > topNumber6[4].Count)
                    {
                        topNumber6[4] = new CommonNumber
                        {
                            Count = kvp.Value,
                            Number = kvp.Key
                        };
                    }
                }
            }

            for (var i = 0; i < topNumber1.Count; i++)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}", topNumber1[i].Number, topNumber2[i].Number, topNumber3[i].Number, topNumber4[i].Number, topNumber5[i].Number, topNumber6[i].Number);
            }
            Console.ReadKey();
        }
    }
}
