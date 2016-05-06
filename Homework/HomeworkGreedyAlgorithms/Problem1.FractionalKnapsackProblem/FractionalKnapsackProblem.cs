namespace Problem1.FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FractionalKnapsackProblem
    {
        static void Main()
        {
            double capacity = int.Parse(Console.ReadLine().Substring(10));
            int itemsCount = int.Parse(Console.ReadLine().Substring(7));

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                int price = int.Parse(parameters[0]);
                int weight = int.Parse(parameters[1]);

                Item item = new Item(price, weight);
                items.Add(item);
            }

            items = items.OrderByDescending(i => i.Average).ToList();

            double totalPrice = 0;

            while (capacity > 0)
            {
                Item item = items[0];
                if (capacity - item.Weight >= 0)
                {
                    capacity -= item.Weight;
                    totalPrice += item.Price;

                    Console.WriteLine("Take 100% of item with price {0:0.00} and weight {1:0.00}", item.Price, item.Weight);
                }
                else if (capacity - item.Weight < 0)
                {
                    double percent = capacity / item.Weight;

                    capacity -= item.Weight;
                    totalPrice += percent * item.Price;
                    percent = percent * 100;

                    Console.WriteLine("Take {0:0.00}% of item with price {1:0.00} and weight {2:0.00}",
                        percent, item.Price, item.Weight);
                }

                items.Remove(item);
            }

            Console.WriteLine("Total price: {0:0.00}", totalPrice);
        }
    }
}