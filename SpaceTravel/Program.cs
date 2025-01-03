/*
 * Напишете програма, която симулира мисия на космически кораб. Корабът трябва да достигне до планетата Титан, като изпълнява поредица от команди. Всяка команда може да бъде една от следните:

Travel {дистанция}: Корабът пътува на зададеното разстояние, като изразходва гориво.
Enemy {броня}: Корабът среща противник и трябва да го победи с муниции или да избяга, използвайки гориво.
Repair {стойност}: Корабът получава ремонт, като добавя гориво и муниции.
Titan: Корабът достига крайната си цел – планетата Титан.
При липса на достатъчно ресурси за изпълнение на команда, мисията се проваля.

Вход:

Първи ред: низ с поредица от команди, разделени с ||.
Втори ред: цяло число – началното количество гориво.
Трети ред: цяло число – началното количество муниции.
Изход:

Резултат от всяка изпълнена команда.
Съобщение за успех или провал на мисията.
 */

string line = Console.ReadLine();
int fuel = int.Parse(Console.ReadLine());
int ammunition = int.Parse(Console.ReadLine());

string[] lineTokens = line.Split("||").ToArray();

foreach (var token in lineTokens)
{
    string[] command = token.Split().ToArray();
    string name = command[0];

    if (name == "Travel")
    {
        int value = int.Parse(command[1]);
        if (value <= fuel)
        {
            fuel = fuel - value;
            Console.WriteLine($"The spaceship travelled {value} light-years.");
        }
        else
        {
            Console.WriteLine("Mission failed.");
            return;
        }
    }
    else if (name == "Enemy")
    {
        int value = int.Parse(command[1]);
        if (value <= ammunition)
        {
            ammunition = ammunition - value;
            Console.WriteLine($"An enemy with {value} armour is defeated.");
        }
        else
        {
            if (fuel < value * 2)
            {
                Console.WriteLine("Mission failed.");
                return;
            }
            else
            {
                fuel = fuel - 2 * value;
                Console.WriteLine($"An enemy with {value} armour is outmaneuvered.");
            }
        }
    }
    else if (name == "Repair")
    {
        int value = int.Parse(command[1]);
        fuel = fuel + value;
        ammunition = ammunition + (value * 2);
        Console.WriteLine($"Ammunitions added: {value * 2}.");
        Console.WriteLine($"Fuel added: {value}.");
    }
    else if (name == "Titan")
    {
        Console.WriteLine("You have reached Titan, all passengers are safe.");
        break;
    }
}