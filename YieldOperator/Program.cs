var students = Generator.GetStudents();
var studentEnumerator = students.GetEnumerator();

while (true)
{
    if (studentEnumerator.MoveNext())
    {
        Console.WriteLine(studentEnumerator.Current.FirstName);
    }
    else break;
}

static List<Student> ToList(IEnumerable<Student> students)
{
    var result = new List<Student>();
    var enumerator = students.GetEnumerator();

    while (true)
    {
        if (enumerator.MoveNext())
            result.Add(enumerator.Current);
        else
            break;
    }

    return result;
}

class Generator
{
    private static int counter = 0;

    public static IEnumerable<int> GetOddNumbers()
    {
        while (true)
        {
            counter++;
            if (counter % 2 == 1)
            {
                yield return counter;
            }
        }
    }
    
    public static IEnumerable<Student> GetStudents()
    {
        yield return GetStudent("Salih", "Cantekin");
        yield return GetStudent("Oğuz", "Kaplan");
        yield return GetStudent("Kerem", "Gün");
        yield return GetStudent("Ünal", "Top");
        yield return GetStudent("Emrah", "Yaman");
    }

    private static Student GetStudent(string firstName, string lastName)
    {
        Task.Delay(1000).Wait();
        return new Student(firstName,lastName);
    }
}

class Student
{
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Console.WriteLine("Student Class Created");
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}