/*
 * You will receive an unknown number of lines. On each line you will receive an array with 3 elements:

· The first element is a string - the name of the person

· The second element a string - the ID of the person

· The third element is an integer - the age of the person

If you get a person whose ID you have already received before, update the name and age for that ID with that of the new person. When you receive the command "End", print all of the people, ordered by age.
 */

class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        ID = id;
        Age = age;
    }

    public string Name { get; set; }
    public string ID { get; set; }
    public int Age { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            string[] tokens = input.Split();
            string name = tokens[0];
            string id = tokens[1];
            int age = int.Parse(tokens[2]);

            var existingPerson = people.FirstOrDefault(p => p.ID == id);

            if (existingPerson != null)
            {
                existingPerson.Name = name;
                existingPerson.Age = age;
            }
            else
            {
                Person newPerson = new Person(name, id, age);
                people.Add(newPerson);
            }
        }
        List<Person> orderedPeople = people.OrderBy(p => p.Age).ToList();
        foreach (Person person in orderedPeople)
        {
            Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
        }
    }
}
/*
Lewis 123456 20
James 78911 15
Robert 523444 11
Jennifer 345244 13
Mary 52424678 22
Patricia 567343 54
 */