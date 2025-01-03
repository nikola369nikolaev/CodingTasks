/*
 * Create a program that sorts some students by their grade in descending order. Each student should have:

· First name (string)

· Last name (string)

· Grade (a floating-point number)

Input

· On the first line, you will receive a number n - the count of all students.

· On the next n lines, you will be receiving information about these students in the following format: "{first name} {second name} {grade}".

Output

· Print out the information about each student in the following format: "{first name} {second name}: {grade}".
 */
class Student
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }   
    public float Grade { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:F2}";
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();

        for (int i = 0; i < studentsCount; i++)
        {
            string[] studentArgs = Console.ReadLine().Split().ToArray();
            
            Student student = new Student();

            student.FirstName = studentArgs[0];
            student.LastName = studentArgs[1];
            student.Grade = float.Parse(studentArgs[2]);
            
            students.Add(student);
        }

       List<Student> orderedStudents = students.
           OrderByDescending(student => student.Grade)
           .ToList();

       Console.WriteLine(string.Join("\n",orderedStudents));
    }
}
