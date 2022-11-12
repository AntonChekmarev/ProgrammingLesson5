namespace Task1
{
    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("34", "на входе длина массива, на выходе массив заполненный случайными натуральными трехзначными числами и информация о том, какое кол-во в этом массиве четных чисел.");

            int[] array = ArrayRandom(InputInt("Задайте длину массива"), 100, 1000);

            Console.WriteLine("");
            Console.WriteLine($"Сформирован массив: [{ArrayToString(array)}]");

            Console.WriteLine("");
            Console.WriteLine("Кол-во четных чисел: " + OECount(array, false));

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

        //функция подсчета кол-ва четных/нечетных чисел в массиве
        // odd = true (нечетное)
        // odd = false (четное)
        static int OECount(int[] array, bool odd)
        {
            int rezult = 0;

            foreach (int value in array)
            {
                if (odd && value % 2 != 0) rezult++; //нечетное
                if (odd == false && value % 2 == 0) rezult++; //четное
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