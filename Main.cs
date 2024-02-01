using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Tab
{
    // Поверхность блока (одна из трёх).
    class Surface
    {
        /// <summary>
        /// Конструктор поверхности блока.
        /// </summary>
        /// <param name="color"> Цвет </param>
        /// <param name="orientation"> Направление </param>
        public Surface(string color, string orientation)
        {
            Color = color;
            Orientation = orientation;
        }
        public string Color { get; set; }
        public string Orientation { get; set; }
    }

    // Блок кубика.
    class Block
    {
        Surface[] _surfaces = new Surface[3];
        public Block(string[] surface1Info, string[] surface2Info, string[] surface3Info)
        {
            _surfaces[0] = new Surface(surface1Info[0], surface1Info[1]);
            _surfaces[1] = new Surface(surface2Info[0], surface2Info[1]);
            _surfaces[2] = new Surface(surface3Info[0], surface3Info[1]);
        }
        public Surface[] Surfaces
        {
            get { return _surfaces; }
            set { _surfaces = value; }
        }
    }

    // Кубик 2x2.
    class Cube
    {
        Block[,,] _blocks;

        /// <summary>
        /// Конструктор кубика (обнуляющий).
        /// </summary>
        public Cube()
        {
            _blocks = new Block[2, 2, 2];
            _blocks[0, 0, 0] = new Block(new string[] { "Green", "Front" },
                                      new string[] { "White", "Top" },
                                      new string[] { "Orange", "Left" });

            _blocks[0, 0, 1] = new Block(new string[] { "Blue", "Back" },
                                      new string[] { "White", "Top" },
                                      new string[] { "Orange", "Left" });

            _blocks[0, 1, 0] = new Block(new string[] { "Green", "Front" },
                                      new string[] { "White", "Top" },
                                      new string[] { "Red", "Right" });

            _blocks[0, 1, 1] = new Block(new string[] { "Blue", "Back" },
                                      new string[] { "White", "Top" },
                                      new string[] { "Red", "Right" });

            _blocks[1, 0, 0] = new Block(new string[] { "Green", "Front" },
                                      new string[] { "Yellow", "Bottom" },
                                      new string[] { "Orange", "Left" });

            _blocks[1, 0, 1] = new Block(new string[] { "Blue", "Back" },
                                      new string[] { "Yellow", "Bottom" },
                                      new string[] { "Orange", "Left" });

            _blocks[1, 1, 0] = new Block(new string[] { "Green", "Front" },
                                      new string[] { "Yellow", "Bottom" },
                                      new string[] { "Red", "Right" });

            _blocks[1, 1, 1] = new Block(new string[] { "Blue", "Back" },
                                      new string[] { "Yellow", "Bottom" },
                                      new string[] { "Red", "Right" });
        }

        /// <summary>
        /// Блоки кубика.
        /// </summary>
        public Block[,,] GetBlocks
        {
            get { return _blocks; }
            set { _blocks = value; }
        }

        /// <summary>
        /// Вывод цветов стороны кубика.
        /// </summary>
        /// <param name="side"> Сторона кубика </param>
        public void PrintSide(string side)
        {
            string[] sides = new string[] { "Left", "Right", "Top", "Bottom", "Front", "Back" };
            if (!sides.Contains(side))
            {
                throw new ArgumentException("Несуществующее название стороны");
            }

            for (int i = 0; i < _blocks.GetLength(0); i++)
            {
                for (int j = 0; j < _blocks.GetLength(1); j++)
                {
                    for (int k = 0; k < _blocks.GetLength(2); k++)
                    {
                        for (int l = 0; l < _blocks[i, j, k].Surfaces.Length; l++)
                        {
                            if (_blocks[i, j, k].Surfaces[l].Orientation == side)
                                Console.WriteLine($"{_blocks[i, j, k].Surfaces[l].Color} {i} {j} {k}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Проверка на собраность кубика.
        /// </summary>
        /// <returns> Собран кубик или нет </returns>
        public bool IsCubeSolve()
        {
            string[] colors = new string[6];
            for (int i = 0; i < _blocks.GetLength(0); i++)
            {
                for (int j = 0; j < _blocks.GetLength(1); j++)
                {
                    for (int k = 0; k < _blocks.GetLength(2); k++)
                    {
                        for (int l = 0; l < _blocks[i, j, k].Surfaces.Length; l++)
                        {
                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Front" && colors[0] == null)
                                colors[0] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Front" && colors[0] != null)
                                if (colors[0] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;

                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Back" && colors[1] == null)
                                colors[1] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Back" && colors[1] != null)
                                if (colors[1] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;

                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Left" && colors[2] == null)
                                colors[2] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Left" && colors[2] != null)
                                if (colors[2] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;

                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Right" && colors[3] == null)
                                colors[3] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Right" && colors[3] != null)
                                if (colors[3] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;

                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Top" && colors[4] == null)
                                colors[4] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Top" && colors[4] != null)
                                if (colors[4] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;

                            if (_blocks[i, j, k].Surfaces[l].Orientation == "Bottom" && colors[5] == null)
                                colors[5] = _blocks[i, j, k].Surfaces[l].Color;
                            else if (_blocks[i, j, k].Surfaces[l].Orientation == "Bottom" && colors[5] != null)
                                if (colors[5] != _blocks[i, j, k].Surfaces[l].Color)
                                    return false;
                        }
                    }
                }
            }
            return true;
        }

        private void MultiSideTurner(string side, int quantity)
        {
            if (quantity == -1)
                quantity = 3;
            Block n1 = null;
            Block n2 = null;
            Block n3 = null;
            Block n4 = null;
            Block[] arr = new Block[] { n4, n3, n2, n1 };
            string[] sideChange = new string[0];
            int iStart = 0;
            int jStart = 0;
            int kStart = 0;
            int iStop = 0;
            int jStop = 0;
            int kStop = 0;

            if (side == "Front")
            {
                sideChange = new string[] { "Left", "Top", "Right", "Bottom" };
                arr[3] = _blocks[1, 0, 0];
                arr[2] = _blocks[0, 0, 0];
                arr[1] = _blocks[0, 1, 0];
                arr[0] = _blocks[1, 1, 0];
                _blocks[1, 0, 0] = arr[(3 + quantity) % 4];
                _blocks[0, 0, 0] = arr[(2 + quantity) % 4];
                _blocks[0, 1, 0] = arr[(1 + quantity) % 4];
                _blocks[1, 1, 0] = arr[(quantity) % 4];
                iStart = 0;
                jStart = 0;
                kStart = 0;
                iStop = 2;
                jStop = 2;
                kStop = 1;
            }
            else if (side == "Back")
            {
                sideChange = new string[] { "Left", "Top", "Right", "Bottom" };
                arr[3] = _blocks[1, 0, 1];
                arr[2] = _blocks[0, 0, 1];
                arr[1] = _blocks[0, 1, 1];
                arr[0] = _blocks[1, 1, 1];
                _blocks[1, 0, 1] = arr[(3 + quantity) % 4];
                _blocks[0, 0, 1] = arr[(2 + quantity) % 4];
                _blocks[0, 1, 1] = arr[(1 + quantity) % 4];
                _blocks[1, 1, 1] = arr[(quantity) % 4];
                iStart = 0;
                jStart = 0;
                kStart = 1;
                iStop = 2;
                jStop = 2;
                kStop = 2;
            }
            else if (side == "Top")
            {
                sideChange = new string[] { "Front", "Left", "Back", "Right" };
                arr[3] = _blocks[0, 0, 0];
                arr[2] = _blocks[0, 0, 1];
                arr[1] = _blocks[0, 1, 1];
                arr[0] = _blocks[0, 1, 0];
                _blocks[0, 0, 0] = arr[(3 + quantity) % 4];
                _blocks[0, 0, 1] = arr[(2 + quantity) % 4];
                _blocks[0, 1, 1] = arr[(1 + quantity) % 4];
                _blocks[0, 1, 0] = arr[(quantity) % 4];
                iStart = 0;
                jStart = 0;
                kStart = 0;
                iStop = 1;
                jStop = 2;
                kStop = 2;
            }
            else if (side == "Bottom")
            {
                sideChange = new string[] { "Front", "Left", "Back", "Right" };
                arr[3] = _blocks[1, 0, 0];
                arr[2] = _blocks[1, 0, 1];
                arr[1] = _blocks[1, 1, 1];
                arr[0] = _blocks[1, 1, 0];
                _blocks[1, 0, 0] = arr[(3 + quantity) % 4];
                _blocks[1, 0, 1] = arr[(2 + quantity) % 4];
                _blocks[1, 1, 1] = arr[(1 + quantity) % 4];
                _blocks[1, 1, 0] = arr[(quantity) % 4];
                iStart = 1;
                jStart = 0;
                kStart = 0;
                iStop = 2;
                jStop = 2;
                kStop = 2;
            }
            else if (side == "Left")
            {
                sideChange = new string[] { "Front", "Top", "Back", "Bottom" };
                arr[3] = _blocks[0, 0, 0];
                arr[2] = _blocks[0, 0, 1];
                arr[1] = _blocks[1, 0, 1];
                arr[0] = _blocks[1, 0, 0];
                _blocks[0, 0, 0] = arr[(3 + quantity) % 4];
                _blocks[0, 0, 1] = arr[(2 + quantity) % 4];
                _blocks[1, 0, 1] = arr[(1 + quantity) % 4];
                _blocks[1, 0, 0] = arr[(quantity) % 4];
                iStart = 0;
                jStart = 0;
                kStart = 0;
                iStop = 2;
                jStop = 1;
                kStop = 2;
            }
            else if (side == "Right")
            {
                sideChange = new string[] { "Front", "Top", "Back", "Bottom" };
                arr[3] = _blocks[0, 1, 0];
                arr[2] = _blocks[0, 1, 1];
                arr[1] = _blocks[1, 1, 1];
                arr[0] = _blocks[1, 1, 0];
                _blocks[0, 1, 0] = arr[(3 + quantity) % 4];
                _blocks[0, 1, 1] = arr[(2 + quantity) % 4];
                _blocks[1, 1, 1] = arr[(1 + quantity) % 4];
                _blocks[1, 1, 0] = arr[(quantity) % 4];
                iStart = 0;
                jStart = 1;
                kStart = 0;
                iStop = 2;
                jStop = 2;
                kStop = 2;
            }

            for (int i = iStart; i < iStop; i++)
            {
                for (int j = jStart; j < jStop; j++)
                {
                    for (int k = kStart; k < kStop; k++)
                    {
                        for (int l = 0; l < _blocks[i, j, k].Surfaces.Length; l++)
                        {
                            if (sideChange.Contains(_blocks[i, j, k].Surfaces[l].Orientation))
                            {
                                int num1 = Array.IndexOf(sideChange, _blocks[i, j, k].Surfaces[l].Orientation);
                                int newNum = (num1 + quantity) % 4;
                                _blocks[i, j, k].Surfaces[l].Orientation = sideChange[newNum];
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Поворот стороны кубика.
        /// </summary>
        /// <param name="side"> Сторона кубика </param>
        /// <param name="quantity"> Количество поворотов </param>
        /// <exception cref="ArgumentException"></exception>
        public void TurnSide(string side, int quantity)
        {
            string[] sides = new string[] { "Left", "Right", "Top", "Bottom", "Front", "Back" };
            if (!sides.Contains(side))
            {
                throw new ArgumentException("Несуществующее название стороны");
            }
            MultiSideTurner(side, quantity);
        }

        public void DoCombination(string combination, int quantity)
        {
            string[] combinations = new string[] { "Pifpaf", "West", "Island"};
            if (!combinations.Contains(combination))
            {
                throw new ArgumentException("Несуществующее название комбинации");
            }

            if (combination== "Pifpaf")
            {
                TurnSide("Right", 1);
                TurnSide("Top", 1);
                TurnSide("Right", -1);
                TurnSide("Top", -1);
            }
            else if (combination == "West")
            {
                TurnSide("Right", 1);
                TurnSide("Top", 1);
                TurnSide("Right", -1);
                TurnSide("Top", -1);
                TurnSide("Right", -1);
                TurnSide("Front", 1);
                TurnSide("Right", 2);
                TurnSide("Top", -1);
                TurnSide("Right", -1);
                TurnSide("Top", -1);
                TurnSide("Right", 1);
                TurnSide("Top", 1);
                TurnSide("Right", -1);
                TurnSide("Front", -1);
            }
            else if (combination == "Island")
            {
                TurnSide("Front", 1);
                TurnSide("Right", 1);
                TurnSide("Top", -1);
                TurnSide("Right", -1);
                TurnSide("Top", -1);
                TurnSide("Right", 1);
                TurnSide("Top", 1);
                TurnSide("Right", -1);
                TurnSide("Front", -1);
                TurnSide("Right", 1);
                TurnSide("Top", 1);
                TurnSide("Right", -1);
                TurnSide("Top", -1);
                TurnSide("Right", -1);
                TurnSide("Front", 1);
                TurnSide("Right", 1);
                TurnSide("Front", -1);
            }
        }
    }



    // Программа.
    class Program
    {
        public static string[] RandomTurns()
        {
            string[] turns = { "Left", "Top", "Right", "Bottom", "Front", "Back" };
            Random random = new Random();
            int quantityOfTurns = random.Next(1, 21);

            string[] randomResult = new string[quantityOfTurns];
            for (int i = 0; i < randomResult.Length; i++)
            {
                int val=random.Next(0,6);

                if (val == 0)
                    randomResult[i] = "Left";
                else if (val == 1)
                    randomResult[i] = "Top";
                else if (val == 2)
                    randomResult[i] = "Right";
                else if (val == 3)
                    randomResult[i] = "Bottom";
                else if (val == 4)
                    randomResult[i] = "Front";
                else if (val == 5)
                    randomResult[i] = "Back";
            }
            return randomResult;
        }
        public static void Main()
        {
            /*int[] statistic = new int[20];
            for (int j = 0; j < statistic.Length; j++)
            {
                statistic[j] = int.MaxValue;
            }

            for (int j = 0; j < 10000; j++)
            {
                Random random = new Random();
                Cube cube = new Cube();
                string[] turns = RandomTurns();

                int[] intTurns = new int[turns.Length];
                for (int i = 0; i < intTurns.Length; i++)
                {
                    intTurns[i] = random.Next(1, 4);
                }

                int k = 0;
                do
                {
                    for (int i = 0; i < turns.Length; i++)
                    {
                        cube.TurnSide(turns[i], intTurns[i]);
                    }
                    k += 1;
                    if (cube.IsCubeSolve())
                        break;
                } while (true);

                if (statistic[turns.Length - 1] > k)
                    statistic[turns.Length - 1] = k;
            }
            for (int i = 0; i < statistic.Length; i++)
            {
                Console.WriteLine($"{i+1} - {statistic[i]}");
            }*/
            Cube cube1 = new Cube();
            /*cube1.DoCombination("Pifpaf", 5);
            cube1.PrintSide("Right");*/
            cube1.TurnSide("Right", 4);
            /*cube1.TurnSide("Right", 2);*/
            Console.WriteLine(cube1.IsCubeSolve());
        }
    }
}
