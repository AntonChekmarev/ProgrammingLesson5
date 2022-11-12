namespace Task4
{

    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("HARD START", "на входе длина массива. Массив заполняется случайными целыми числами (0...10). На выходе объединенная в одном массиве информация: 1) мин элемент + его индексы; 2) макс элемент + его индексы; 3) среднее арифметическое массива. Отдельно выводится медианное значение массива.");

            decimal[] array = ArrayRandom(InputInt("Задайте длину массива"), 0, 10); // массив

            Console.WriteLine("");
            Console.WriteLine($"Сформирован массив: [{ArrayToString(array)}]");

            decimal[][] finishArray = MinMaxValuesWithIndexsAndArithmeticMeanInArray(array); //см комменты перед функцией                  

            Console.WriteLine("");
            Console.WriteLine("Минимальный элемент: " + finishArray[0][0]);
            Console.WriteLine($"Индекс{(finishArray[1].Length > 1 ? "ы" : "")} расположения: [{ArrayToString(finishArray[1])}]");
            
            Console.WriteLine("");
            Console.WriteLine("Максимальный элемент: " + finishArray[2][0]);
            Console.WriteLine($"Индекс{(finishArray[3].Length > 1 ? "ы" : "")} расположения: [{ArrayToString(finishArray[3])}]");

            Console.WriteLine("");
            Console.WriteLine("Среднее арифметическое: " + finishArray[4][0].ToString("0.###").Replace(",","."));

            Console.WriteLine("");
            Console.WriteLine("Миданное значение массива: " + MedianValueInArray(array).ToString("0.###").Replace(",", "."));

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

        //функция преобразования массива чисел в строку
        static string ArrayToString(decimal[] array, string split = ",")
        {
            string rezult = "";

            foreach (int value in array)
            {
                if (rezult != "") rezult += $"{split} ";
                rezult += value;
            }

            return rezult;
        }

        //функция формирования массива со случайными элеменатми в задаваемом дипазоне
        static decimal[] ArrayRandom(int count, int min = 0, int max = 1)
        {
            decimal[] rezult = new decimal[count];

            Random rnd = new();

            for (int i = 0; i < count; i++)
            {
                rezult[i] = rnd.Next(min, max + 1);
            }

            return rezult;
        }

        // функция возвращает зубчатый массив.
        // Массив 0: мин значение массива
        // Массив 1: индексы мин значений
        // Массив 2: макс значение массива
        // Массив 3: индексы макс значений
        // Массив 4: среднее арифметическое массива    
        static decimal[][] MinMaxValuesWithIndexsAndArithmeticMeanInArray(decimal[] array)
        {
            decimal minValue = array[0]; // мин значение в массиве
            int minCount = 0; // кол-во мин значений в массиве
            decimal maxValue = array[0]; // макс значение в массиве
            int maxCount = 0; // кол-во макс значений в массиве            

            // поиск мин и макс значений и их кол-ва в массиве
            foreach (decimal value in array)
            {
                if (value == minValue) minCount++;
                if (value == maxValue) maxCount++;

                if (value < minValue) { minValue = value; minCount = 1; }
                if (value > maxValue) { maxValue = value; maxCount = 1; }
            }

            decimal[] minIndexs = new decimal[minCount]; // массив индексов для мин значения
            int minI = 0; // текущий индекс в массиве индексов для мин значения
            decimal[] maxIndexs = new decimal[maxCount];// массив индексов для макс значения
            int maxI = 0; // текущий индекс в массиве индексов для мин значения

            // формируются массивы с индексами мин и макс значений
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == minValue) { minIndexs[minI] = i; minI++; }
                if (array[i] == maxValue) { maxIndexs[maxI] = i; maxI++; }
            }

            // результат
            decimal[][] rezult = {
                                new decimal[1], // мин значение
                                new decimal[minCount], // индексы мин значения 
                                new decimal[1], // макс значение
                                new decimal[maxCount], // индексы макс значения 
                                new decimal[1] // среднее арифметическое
                               };


            rezult[0][0] = minValue; 
            rezult[1] = minIndexs;
            rezult[2][0] = maxValue;
            rezult[3] = maxIndexs;
            rezult[4][0] = ArithmeticMeanInArray(array);                      

            return rezult;
        }

        // функция получения среднего арифметического числа из массива чисел
       static decimal ArithmeticMeanInArray(decimal[] array)
        {
            decimal rezult =0;
            decimal sum = 0;

            foreach (decimal number in array)
            {
                sum += number;
            }
            rezult = sum / array.Length;

            return rezult; 
        }

        //функция получения медианного значения
        static decimal MedianValueInArray(decimal[] array)
        {
            decimal rezult;         
            
            //сортировка по возрастанию
            Array.Sort(array);

            if (array.Length % 2 != 0) rezult = array[array.Length / 2]; // для не четного кол-ва элементов (средний элемент)
            else rezult = (array[array.Length / 2 - 1] + array[array.Length / 2]) / 2; // для четного кол-ва элементов (сумма двух центральных разделенная на 2)

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