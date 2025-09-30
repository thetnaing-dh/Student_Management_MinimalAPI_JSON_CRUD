using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(String[] args)
    {
        var student = new StudentModel
        {
            Id = 1,
            Name = "Thiha",
            Age = 18,
            Grade = "Grade 11",
            School = "အထက(၁) မော်လမြိုင်",
            Major = "သိပ္ပံ",
            Address = "မော်လမြိုင်မြို့",
            Phone = "09-422196618",
            Email = "thiha@gmail.com",
            Subject = ["မြန်မာ", "အင်္ဂလိပ်", "သင်္ချာ", "ဓာတုဗေဒ", "ရူပဗေဒ"]
        };

    //  string jsonStr = JsonConvert.SerializeObject(student, Formatting.Indented);

       Console.WriteLine(student.ToJson());

        var student2 = JsonConvert.DeserializeObject<StudentModel>(student.ToJson());

    //  Console.WriteLine(student2.Name);      

    }
}

public class StudentModel()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public string School { get; set; }
    public string Major { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string[] Subject { get; set; }
}

public static class Extensions
{
    public static string ToJson(this object model)
    {
        string json = JsonConvert.SerializeObject(model, Formatting.Indented);
        return json;
    }
}
