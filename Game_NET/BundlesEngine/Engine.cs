using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BundlesEngine
{
    public static class Engine
    {
        public static GameTriplex PlayGame(GameTriplex[] triplexes, GameModes selectedMode = GameModes.ProgramVsProgram)
        {
            Random x = new Random(); // объявление переменной для генерации чисел

            int p = x.Next(1, 11);
            int q = x.Next(1, 11);
            int r = x.Next(1, 11);
            int NStep = 0;

            bool Al = false;
            bool Ak = false;
            bool Prn = true;

            Console.WriteLine($" {NStep}: {p}, {q}, {r}");

            GameTriplex newTriplexToWrite = null;

            while (p + q + r > 0)
            {
                if (selectedMode == GameModes.ManVsProgram)
                {
                    Console.WriteLine("Input P:");
                    var pFromUser = Console.ReadLine(); 
                    Console.WriteLine("Input Q:");
                    var qFromUser = Console.ReadLine();
                    Console.WriteLine("Input R:");
                    var rFromUser = Console.ReadLine();
                    int pFromUserInt, qFromUserInt, rFromUserInt;
                    try
                    {
                        pFromUserInt = int.Parse(pFromUser);
                        qFromUserInt = int.Parse(qFromUser);
                        rFromUserInt = int.Parse(rFromUser);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You have entered not correct values, please start a new game again.");
                        throw;
                    }

                    p = pFromUserInt;
                    q = qFromUserInt;
                    r = rFromUserInt;

                    NStep++;
                }

                int k = 0;
                while (k < triplexes.Length)
                {
                    GameTriplex tr = new GameTriplex(p, q, r);
                    if (tr.MakeStep(triplexes, k))
                    {
                        p = tr.A;
                        q = tr.B;
                        r = tr.C;
                        Console.WriteLine($"Well, {NStep + 1}: {p}, {q}, {r}");
                        NStep++;
                        Al = true;
                        break;
                    }
                    else
                        k++;
                }

                if (Al == false)
                {
                    GameTriplex tr1 = new GameTriplex(p, q, r);
                    if (tr1.MakeStepW(triplexes))
                    {
                        p = tr1.A;
                        q = tr1.B;
                        r = tr1.C;
                        Console.WriteLine($"Wel2, {NStep + 1}: {p}, {q}, {r}");
                        NStep++;
                        Ak = true;
                    }
                    else Ak = false;
                }

                if (Al == false & Ak == false & Prn == true)
                {
                    //Console.WriteLine($"Write {p},{q},{r}");
                    newTriplexToWrite = new GameTriplex(p, q, r);
                    newTriplexToWrite.OrderABC();
                    newTriplexToWrite.Print();
                    Prn = false;
                }

                if (Al == true | Ak == false)
                {
                    int s = x.Next(1, 3);

                    if (s == 1)
                    {
                        if (p > 0)
                        {
                            p = x.Next(0, p);
                            NStep++;
                        }
                        else if (q > 0)
                        {
                            q = x.Next(0, q);
                            NStep++;
                        }
                        else
                        {
                            r = x.Next(0, r);
                            NStep++;
                        }
                    }
                    if (s == 2)
                    {
                        if (q > 0)
                        {
                            q = x.Next(0, q);
                            NStep++;
                        }
                        else if (r > 0)
                        {
                            r = x.Next(0, r);
                            NStep++;
                        }
                        else
                        {
                            p = x.Next(0, p);
                            NStep++;
                        }
                    }
                    if (s == 3)
                    {
                        if (r > 0)
                        {
                            r = x.Next(0, r);
                            NStep++;
                        }
                        else if (p > 0)
                        {
                            p = x.Next(0, p);
                            NStep++;
                        }
                        else
                        {
                            q = x.Next(0, q);
                            NStep++;
                        }
                    }
                    Console.WriteLine($" Rand {NStep}: {p}, {q}, {r}");
                }
            }

            return newTriplexToWrite;
        }

        public static async Task<GameTriplex[]> ReadExistingTriplexes(GameTriplex[] triplexes)
        {
            // чтение данных
            using (FileStream fs = new FileStream("key.json", FileMode.Open))
            {
                triplexes = await JsonSerializer.DeserializeAsync<GameTriplex[]>(fs);
                for (int j = 0; j < triplexes.Length; j++)
                {
                    Console.WriteLine($"A1:{triplexes[j].A} A2:{triplexes[j].B} A3:{triplexes[j].C}");
                }
            }

            return triplexes;
        }

        public static async Task WriteWinTriplexes(GameTriplex[] triplexes, GameTriplex newTriplexToWrite)
        {
            if (newTriplexToWrite != null)
            {
                //сохранение данных
                using (FileStream fs = new FileStream("key.json", FileMode.Create))
                {
                    var listTriplexes = triplexes.ToList();
                    listTriplexes.Add(newTriplexToWrite);

                    await JsonSerializer.SerializeAsync<List<GameTriplex>>(fs, listTriplexes);
                    Console.WriteLine("Data has been saved to file");
                }
            }
        }
    }
}
