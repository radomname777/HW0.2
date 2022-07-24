namespace Proxy;

public interface Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    void Request();
}


class Student : Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public Student(string name, string surname, string fatherName, string address, int age)
    {
        Name = name;
        Surname = surname;
        FatherName = fatherName;
        Address = address;
        Age = age;
    }
    public void Request() => Console.WriteLine("Student Class");
    
}

class Proxy : Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }

    private Student _Student;

    public Proxy(Student studnet) => _Student = studnet;
    

    public void Request()
    {
        if (this.CheckAccess())
        {
            this._Student.Request();
            Console.WriteLine("Proxy Class");
        }
    }

    public bool CheckAccess()
      => _Student.Name!=null&& _Student.Surname!=null&& _Student.FatherName!=null&& _Student.FatherName!=null&& _Student.Age>=6;
   
}


public class School
{
    public void Schools(Person person)
     =>person.Request();
    
}

class Program
{
    static void Main()
    {
        School client = new School();
        Student studnet = new("XXXX","XXXX","XXX","323.322",12);
        client.Schools(studnet);
        Proxy proxy = new Proxy(studnet);
        client.Schools(proxy);
    }
}