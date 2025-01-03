/*
 * 
Напишете програма, която сравнява сумите на стойностите в лявата и дясната страна на масив спрямо дадена начална точка (индекс), като взема предвид определен критерий.

Вход:
Масив от цели числа, разделени със запетая и интервал (, ).
Цяло число entryPoint, представляващо индекса на началната точка.
Текст "cheap" или "expensive", определящ критерия:
"cheap": включват се само стойности, по-малки от стойността на началната точка.
"expensive": включват се стойности, равни или по-големи от стойността на началната точка.
Изход:
Отпечатайте:

Left - {сума}, ако лявата страна има по-голяма или равна сума.
Right - {сума}, ако дясната страна има по-голяма сума.
 */

// Step 1: Parse the input
int[] priceRatings = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();
        
int entryPoint = int.Parse(Console.ReadLine());
string type = Console.ReadLine();

// Step 2: Find the entry point index
int entryIndex = Array.IndexOf(priceRatings,entryPoint);

// Step 3: Determine the type of items to break
int[] itemsToBreak;
if (type == "cheap")
{
    itemsToBreak = priceRatings.Where(rating => rating < entryPoint).ToArray();
}
else if (type == "expensive")
{
    itemsToBreak = priceRatings.Where(rating => rating >= entryPoint).ToArray();
}
else
{
    throw new ArgumentException("Invalid item type.");
}

// Step 4: Calculate the damage to the left and right
int leftDamage = itemsToBreak.Take(entryIndex).Sum();
int rightDamage = itemsToBreak.Skip(entryIndex + 1).Sum();

// Step 5: Compare and print the result
if (leftDamage >= rightDamage)
{
    Console.WriteLine($"Left - {leftDamage}");
}
else
{
    Console.WriteLine($"Right - {rightDamage}");
}
