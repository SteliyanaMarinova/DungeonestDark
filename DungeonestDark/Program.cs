using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonestDark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            int room = 1;
            var rooms = Console.ReadLine().Split('|');
            List<string> items = new List<string>();
            List<int> values = new List<int>();
            foreach (var item in rooms)
            {
                string[] things = item.Split();
                items.Add(things[0]);
                values.Add(int.Parse(things[1]));
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == "potion")
                {
                    int bonus = values[i];
                    if (health + bonus < 100)
                    {
                        Console.WriteLine($"You healed for {bonus} hp.");
                        health += bonus;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                    room++;
                }
                else if (items[i] == "chest")
                {
                    int bonus = values[i];
                    coins += bonus;
                    Console.WriteLine($"You found {bonus} coins.");
                    room++;
                }
                else
                {
                    int bonus = values[i];
                    health -= bonus;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {items[i]}.");
                        room++;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {items[i]}.");
                        Console.WriteLine($"Best room: {room}");
                        break;
                    }
                }
            }
            if (health > 0)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
        
   

