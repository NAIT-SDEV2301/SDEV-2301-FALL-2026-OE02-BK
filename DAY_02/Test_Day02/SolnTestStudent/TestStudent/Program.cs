Console.WriteLine("Hello, Welcome!");
// Declarations

string nameStudent ; // name of student
string courseName;
int stuID;
int stuMarks;

string inputValues;
//bool enrollment;




// Usage 
Console.WriteLine("Enter your Name: \t");
nameStudent = Console.ReadLine();

Console.WriteLine("Enter the Course you want to study: \t");
courseName = Console.ReadLine();

Console.WriteLine("Enter your student ID: \t");
inputValues = Console.ReadLine();
stuID = int.Parse(inputValues);

Console.WriteLine("Enter your Marks: \t");
inputValues = Console.ReadLine();
stuMarks = int.Parse(inputValues);

if (stuMarks >= 50)
{
    Console.WriteLine("You are enrolled for the course: \t");
}
else
{
    Console.WriteLine("You can not enroll for the course: \t");
}

Console.WriteLine("Have you enrolled for the new course: \t");
inputValues = Console.ReadLine();
if(bool.TryParse(inputValues, out bool enrollment1))
{
    Console.WriteLine($" I have enrolled the class: {enrollment1} ");
}
else
{
    Console.WriteLine("Conversion was not successful");
}


Console.WriteLine(" Welcome : " + nameStudent);
Console.WriteLine($" I am studying in : {courseName} ");
Console.WriteLine($" My student ID is : {stuID} ");



