using System;
using System.Collections.Generic;

namespace FPSbots
{
    public class SimpleView
    {
        private ConsoleColor empty;
        private ConsoleColor wall;
        private ConsoleColor bot;
        private ConsoleColor item;

        public SimpleView()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            empty = ConsoleColor.Gray;
            wall = ConsoleColor.Black;
            bot = ConsoleColor.DarkMagenta;
            item = ConsoleColor.Blue;
        }

        public void ShowInit(List<List<FieldType>> map, List<Bot> bots)
        {
            List<Tuple<Position, Boolean>> agents_tmp = new List<Tuple<Position, Boolean>>();
            for (int i = 0; i < bots.Count; i++)
                agents_tmp.Add(new Tuple<Position, Boolean>(new Position(bots[i].Pos.X, bots[i].Pos.Y), false));

            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    // Check if it is an agent's position
                    Boolean isagent = false;
                    Int32 k = 0;
                    while (!isagent && k < agents_tmp.Count)
                    {
                        if (agents_tmp[k].Item2 == false && (int)(agents_tmp[k].Item1.X) == i && (int)(agents_tmp[k].Item1.Y) == j)
                        {
                            isagent = true;
                            agents_tmp[k] = new Tuple<Position, Boolean>(new Position(bots[k].Pos.X, bots[k].Pos.Y), true);
                        }
                        else
                            k++;
                    }

                    if (isagent)
                    {
                        Console.ForegroundColor = bot;
                        Console.Write(" " + (bots[k].Id + 1));
                    }
                    else if (map[i][j] == FieldType.Empty)
                    {
                        Console.ForegroundColor = empty;
                        Console.Write("  ");
                    }
                    else if (map[i][j] == FieldType.Wall)
                    {
                        Console.ForegroundColor = wall;
                        Console.Write(" X");
                    }
                    else if (map[i][j] == FieldType.Item)
                    {
                        Console.ForegroundColor = item;
                        Console.Write(" ■");
                    }
                }

                Console.WriteLine();
            }
        }

        public void Show(List<List<FieldType>> map, List<Bot> bots)
        {
            Boolean showprogress = false;

            if (showprogress)
            {
                List<Tuple<Position, Boolean>> agents_tmp = new List<Tuple<Position, Boolean>>();
                for (int i = 0; i < bots.Count; i++)
                    agents_tmp.Add(new Tuple<Position, Boolean>(new Position(bots[i].Pos.X, bots[i].Pos.Y), false));

                for (int i = 0; i < map.Count; i++)
                {
                    for (int j = 0; j < map[i].Count; j++)
                    {
                        // Check if it is an agent's position
                        Boolean isagent = false;
                        Int32 k = 0;
                        while (!isagent && k < agents_tmp.Count)
                        {
                            if (agents_tmp[k].Item2 == false && (int)(agents_tmp[k].Item1.X) == i && (int)(agents_tmp[k].Item1.Y) == j)
                            {
                                isagent = true;
                                agents_tmp[k] = new Tuple<Position, Boolean>(new Position(bots[k].Pos.X, bots[k].Pos.Y), true);
                            }
                            else
                                k++;
                        }

                        if (isagent)
                        {
                            Console.ForegroundColor = bot;
                            Console.Write(" " + (bots[k].Id + 1));
                        }
                        else if (map[i][j] == FieldType.Empty)
                        {
                            Console.ForegroundColor = empty;
                            Console.Write("  ");
                        }
                        else if (map[i][j] == FieldType.Wall)
                        {
                            Console.ForegroundColor = wall;
                            Console.Write(" X");
                        }
                        else if (map[i][j] == FieldType.Item)
                        {
                            Console.ForegroundColor = item;
                            Console.Write(" ■");
                        }
                    }

                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
}
