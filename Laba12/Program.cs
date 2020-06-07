using System;
using System.Net.Configuration;
using System.Runtime.ConstrainedExecution;

namespace Laba12
{
    internal class Program
    {
        
        public const string MainMenu = "1.Односвязанный список\n2.Двусвязный список\n3.Дерево\n4.Очередь на базе однонаправленного списка\n0.Выход";

        public const string LinkedListMenuStr =
            "1.Создать список\n2.Печать списка\n3.Удаление списка\n4.Удаление элемента после заданного значения\n0.Выход";
        
        public const string DoubleLinkedListMenuStr =
            "1.Создать список\n2.Печать списка\n3.Удаление списка\n4.Удаление элементов с четной стоимостью\n0.Выход";

        public const string TreeMenuStr = "1.Создать дерево.\n2.Печать дерева\n3.Удаление дерева\n4.Преобразование в дерево поиска\0.Выход";

        public const string MyCollectionMenuStr = "1.Создать коллекцию\n2.Печать коллекции\n3.Количество элементов\n4.Добавление элементов\n" +
                                                  "5.Удаление элементов\n6.Поиск по значению\n7.Клонирование коллекции\n8.Поверхностное копирование\n" +
                                                  "9.Удаление коллекции\n0.Выход";

        public static void Main(string[] args)
        {
            DoubleLinkedListMenu();
        }

        public static void TreeMenu()
        {
            int userChoice;


        }

        public static void MyCollectionMenu()
        {
            int userChoice;
            Queue<Goods> queue = new Queue<Goods>();
            bool isExcist = false;

            do
            {
                Console.WriteLine(MyCollectionMenuStr);
                userChoice = InputNumber("", 0, 9);
                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        int size = InputNumber("Введите размер списка", 1, 10000);
                        for (int i = 0; i < size; i++)
                        {
                            queue.Enqueue(CreateRandomGood());
                        }

                        Console.WriteLine("Список создан");
                        isExcist = true;
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 2:
                        foreach (var item in queue)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 3:
                        Console.WriteLine($"Количество элементов: {queue.Count}");
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 4:
                        int number = InputNumber("Введите количество добавляемых элементов", 1, 10000);
                        for (int i = 0; i < number; i++)
                        {
                            queue.Enqueue(CreateRandomGood());
                        }
                        Console.WriteLine("Элементы добавлены");
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 6:
                        Goods data = queue.firstPoint.Data;
                        Console.WriteLine("Посик первого элемента....");
                        if (queue.Contains(data, out Goods result))
                        {
                            Console.WriteLine("Элемент найден");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден");
                        }
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 5:
                        int deleteNumber = InputNumber("Введите число удаляемых элементов", 1, queue.Count);
                        queue.Dequeue(deleteNumber);
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                    
                    case 7:
                        //clone
                        break;
                    
                    case 8:
                        //shallow copy
                        break;
                        
                    case 9:
                        queue.Clear();
                        Console.WriteLine("Очередь удалена");
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                }
            } while (userChoice != 0);
        }

        public static void LinkedListMenu()
        {
            int userChoice;
            LinkedList<Goods> list = new LinkedList<Goods>();;
            bool isListExcist = false;

            do
            {
                Console.WriteLine(LinkedListMenuStr);
                userChoice = InputNumber("", 0, 4);
                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        int size = InputNumber("Введите размер списка", 1, 10000);
                        for (int i = 0; i < size; i++)
                        {
                            list.Add(CreateRandomGood());
                        }

                        Console.WriteLine("Список создан");
                        isListExcist = true;
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 2:
                        if (list.count > 0 && isListExcist)
                        {
                            Point<Goods> temp = list.firstPoint;
                            /*for (int i = 0; i < list.count; i++)
                            {
                                Console.WriteLine(temp.Data.ToString());
                                temp = temp.Next;
                            }*/
                            foreach (var item in list)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 3:
                        if (list.count > 0 && isListExcist)
                        {
                            list.Clear();
                            Console.WriteLine("Список удален");
                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 4:
                        if (list.count > 0 && isListExcist)
                        {
                            int number = InputNumber("Введите номер элемента, после которого удалить", 1,
                                list.count - 1);
                            Point<Goods> tempo = list.firstPoint;
                            for (int i = 1; i < number; i++)
                            {
                                tempo = tempo.Next;
                            }

                            list.Remove(tempo.Next.Data);
                            Console.WriteLine("Элемент удален");
                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                }
            } while (userChoice != 0);
        }

        public static void DoubleLinkedListMenu()
        {
            int userChoice;
            DoublyLinkedList<Goods> list = new DoublyLinkedList<Goods>();
            bool isListExcist = false;

            do
            {
                Console.WriteLine(DoubleLinkedListMenuStr);
                userChoice = InputNumber("", 0, 4);
                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        int size = InputNumber("Введите размер списка", 1, 10000);
                        for (int i = 0; i < size; i++)
                        {
                            list.Add(CreateRandomGood());
                        }

                        Console.WriteLine("Список создан");
                        isListExcist = true;
                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 2:
                        if (list.count > 0 && isListExcist)
                        {
                            DoublePoint<Goods> temp = list.firstPoint;
                            for (int i = 0; i < list.count; i++)
                            {
                                Console.WriteLine(temp.Data.ToString());
                                temp = temp.Next;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 3:
                        if (list.count > 0 && isListExcist)
                        {
                            list.Clear();
                            Console.WriteLine("Список удален");
                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;

                    case 4:
                        if (list.count > 0 && isListExcist)
                        {
                            foreach (var item in list)
                            {
                                if (item % 2 == 0)
                                {
                                    list.Remove(item);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список не создан!");
                        }

                        Console.WriteLine(
                            "--------------------------------------------------------------------------------------");
                        break;
                }
            } while (userChoice != 0);
        }
        
        public static int InputNumber(string text, int left, int right)
        {
            int number = 0;
            var ok = false;
            Console.WriteLine(text);
            do
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    if (number <= right && number >= left)
                        ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка! Введено число за пределами границ!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Неверно введено число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод!");
                }
            } while (!ok);

            return number;
        }
        
        public static Goods CreateRandomGood()
        {
            Random random = new Random();
            int numberOfGood = random.Next(1, 4);
            if (numberOfGood == 1)
                return new Product();
            if (numberOfGood == 2)
                return new Toy();
            return new MilkProduct();
        }
    }
}