using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Student", () =>
{
    string folderPath = "Data/students.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<StudentResModel>(jsonStr)!;
    return Results.Ok(result.Tbl_Student);
})
.WithName("StudentList")
.WithOpenApi();

app.MapGet("/Student/{id}", (int id) =>
{
    string folderPath = "Data/students.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<StudentResModel>(jsonStr)!;
    var student  = result.Tbl_Student.FirstOrDefault(x => x.Id == id);
    return Results.Ok(student);
})
.WithName("Student")
.WithOpenApi();

app.MapPost("/Student", (StudentModel studentModel) =>
{
    string folderPath = "Data/students.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<StudentResModel>(jsonStr)!;
    studentModel.Id = result.Tbl_Student.Count == 0 ? 1 : result.Tbl_Student.Max(x => x.Id) + 1;
    result.Tbl_Student.Add(studentModel);

    var jsonStrtoWrite = JsonConvert.SerializeObject(result, Formatting.Indented);
    File.WriteAllText (folderPath, jsonStrtoWrite);

    return Results.Ok(studentModel);
})
.WithName("InsertStudent")
.WithOpenApi();

app.MapPut("/Student/{id}", (int id, StudentModel studentModel) =>
{
    string folderPath = "Data/students.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<StudentResModel>(jsonStr)!;

    var updateStudent = result.Tbl_Student.FirstOrDefault(x => x.Id == id);

    result.Tbl_Student.Remove(updateStudent);

    studentModel.Id = id;
    result.Tbl_Student.Add(studentModel);

    var jsonStrtoWrite = JsonConvert.SerializeObject(result, Formatting.Indented);
    File.WriteAllText(folderPath, jsonStrtoWrite);

    return Results.Ok(studentModel);
})
.WithName("UpdateStudent")
.WithOpenApi();

app.MapDelete("/Student/{id}", (int id) =>
{
    string folderPath = "Data/students.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<StudentResModel>(jsonStr)!;

    var deleteStudent = result.Tbl_Student.FirstOrDefault(x => x.Id == id);

    result.Tbl_Student.Remove(deleteStudent);      

    var jsonStrtoWrite = JsonConvert.SerializeObject(result, Formatting.Indented);
    File.WriteAllText(folderPath, jsonStrtoWrite);

    return Results.Ok("Deleting Successfully.");
})
.WithName("DeleteStudent")
.WithOpenApi();

app.Run();


public class StudentResModel
{
    public List<StudentModel> Tbl_Student { get; set; }
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
}
