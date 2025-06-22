class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public string grade { get; set; }

}
class StudentView
{
    public void DisplayStudentDetails(int id,string name, string grade)
    {
        Console.WriteLine($"Student : {name}  ;  Rollnumber : {id}  ; Grade : {grade}");
    }
}
class StudentController
{
    Student student;
    StudentView studentView;

    public StudentController(Student student, StudentView studentView)
    {
        this.student = student;
        this.studentView = studentView;
    }
    public void setname(string name)
    {
        student.name = name;
    }
    public void setid(int id)
    {
        student.id = id;
    }
    public void setgrade(string grade)
    {
        student.grade = grade;
    }

    public String getname()
    {
        return student.name;
    }
    public int getid()
    {
        return student.id;
    }
    public String getgrade()
    {
        return student.grade;
    }

    public void update()
    {
        studentView.DisplayStudentDetails(getid(), getname(), getgrade());
    }
}

class MVCPatternExample
{
    public static void Main(String[] args)
    {
        Student student = new Student();
        StudentView view = new StudentView();
        StudentController controller = new StudentController(student, view);
        controller.setname("Shake");
        controller.setid(1);
        controller.setgrade("A+");
        controller.update();
    }
}