namespace Task2 
{

    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("36", "на входе длина массива, на выходе массив заполненный случайными целыми числами (от -100 до 100) и сумма чисел четных элементов массива.");

            int[] array = ArrayRandom(InputInt("Задайте длину массива"), -100, 101);

            Console.WriteLine("");
            Console.WriteLine($"Сформирован массив: [{ArrayToString(array)}]");

            Console.WriteLine("");
            Console.WriteLine("Сумма четных элементов: " + OESumm(array, false));


            PrintFinishTask();
        } // === FINISH ===



        // Функция ввода и проверки данных числа int.
        static int InputInt(string inputText)
        {
            int rezult;

            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write(inputText + ": ");

                string str = Console.ReadLine()!.Trim();

                if (int.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: неcоответствие типу Integer!");

                    continue;
                }

                if (rezult <= 0) // доп проверка
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: количество должно быть натуральным числом!");

                    continue;
                }

                break;
            } while (true);

            return rezult;
        }

        //функция формирования массива со случайными элеменатми в задаваемом дипазоне
        int[] ArrayRandom(int count, int min = 0, int max = 1)
        {
            int[] rezult = new int[count];

            Random rnd = new();

            for (int i = 0; i < count; i++)
            {
                rezult[i] = rnd.Next(min, max + 1);
            }

            return rezult;
        }

        //функция преобразования массива чисел в строку
        static string ArrayToString(int[] array, string split = ",")
        {
            string rezult = "";

            foreach (int value in array)
            {
                if (rezult != "") rezult += $"{split} ";
                rezult += value;
            }

            return rezult;
        }

        // функция суммы четных/нечетных элементов массива
        // odd = true (нечетное)
        // odd = false (четное)
        static int OESumm(int[] array, bool odd)
        {
            int rezult = 0;

            int iStart = 0; // старт цикла для нечетных позиций 
            if (odd == false) iStart = 1; // старт цикла для четных позиций

            for (int i = iStart; i < array.Length; i+=2)
            {
                rezult += array[i];
            }

            return rezult;
        }

        // отрисовка заголовка задачи
        static void PrintStartTask(string taskNumber, string taskText, string infoText = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ЗАДАЧА {taskNumber}: " + taskText);
            if (infoText != "")
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("info: " + infoText);
            }

            Console.ResetColor();
        }

        // отрисовка завершения задачи
        static void PrintFinishTask()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        }








        //На случай запуска как самостоятельно проекта, не из под Главного Меню
        class Program
        {
            static void Main()
            {
                Task task = new();
                task.Start();
            }
        }
    }
}