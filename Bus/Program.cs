/*
 * Напишете програма, която изчислява и отпечатва печалбата на подвижен ресторант "Burger Bus" за обиколка от няколко града. В зависимост от реда на града, приходите и разходите могат да бъдат променени поради специални обстоятелства.

Вход:
Първи ред – цяло число n, представляващо броя на градовете.
За всеки град:
Име на града – текст.
Приходи – реално число.
Разходи – реално число.
Условия:
Ако номерът на града (редът) е кратен на 5, вали дъжд, и приходите намаляват с 10%.
Ако номерът на града е кратен на 3 (но не на 5), разходите се увеличават с 50%.
Във всички останали случаи печалбата се изчислява като разликата между приходите и разходите.
Печалбата за всеки град и общата печалба трябва да бъдат отпечатани.
 */

using System.Threading.Channels;

int cities = int.Parse(Console.ReadLine());

double totalProfit = 0.0;
for (int i = 1; i <= cities; i++)
{
    string name = Console.ReadLine();
    double income = double.Parse(Console.ReadLine());
    double expenses = double.Parse(Console.ReadLine());
    double profit = 0.0;

    bool isRaining = false;

    if (i % 5 == 0)
    {
        isRaining = true;
        income = income - (income * 0.10);
        profit = income - expenses;

        totalProfit = totalProfit + profit;
        Console.WriteLine($"In {name} Burger Bus earned {profit:F2} leva.");
        continue;
    }

    if (!isRaining)
    {
        if (i % 3 == 0)
        {
            profit = income - (expenses + (expenses / 2.0));
            totalProfit = totalProfit + profit;
            Console.WriteLine($"In {name} Burger Bus earned {profit:F2} leva.");
            continue;
        }
    }
    
    profit = income - expenses;
    totalProfit = totalProfit + profit;

    Console.WriteLine($"In {name} Burger Bus earned {profit:F2} leva.");
}
Console.WriteLine($"Burger Bus total profit: {totalProfit:F2} leva." );
