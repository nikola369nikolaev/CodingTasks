/*
 * You will be given two hands of cards, which will be represented by integers. Assume each one is held by a different player. You have to find which one has the winning deck. You start from the beginning of both hands of cards. Compare the cards from the first deck to the cards from the second deck. The player, who holds the more powerful card on the current iteration, takes both cards and puts them at the back of his hand - the second player's card is placed last and the first person's card (the winning one) comes after it (second to last). If both players' cards have the same values - no one wins and the two cards must be removed from both hands. The game is over only when

one of the decks is left without any cards. You have to display the result on the console and the sum of the remaining cards: "{First/Second} player wins! Sum: {sum}".

Examples

Input Output

20 30 40 50

10 20 30 40 First player wins! Sum: 240

10 20 30 40 50

50 40 30 30 10 Second player wins! Sum: 50
 */

List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();


while (firstPlayer.Count!=0 && secondPlayer.Count!=0)
{
    
    if (firstPlayer[0] > secondPlayer[0])
    {
            firstPlayer.Add(secondPlayer[0]);
            firstPlayer.Add(firstPlayer[0]);
    }
    else if (firstPlayer[0] < secondPlayer[0])
    {
        secondPlayer.Add(firstPlayer[0]);
        secondPlayer.Add(secondPlayer[0]);
    }
    
    secondPlayer.RemoveAt(0);
    firstPlayer.RemoveAt(0);
}

int firstPlayerSum = firstPlayer.Sum();
int secondPlayerSum = secondPlayer.Sum();

if (firstPlayerSum > secondPlayerSum)
{
    Console.WriteLine($"First player wins! Sum: {firstPlayerSum}");
}
else if (secondPlayerSum > firstPlayerSum)
{
    Console.WriteLine($"Second player wins! Sum: {secondPlayerSum}");
}