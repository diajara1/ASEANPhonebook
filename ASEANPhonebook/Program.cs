using System;
using System.Collections.Generic;

class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public string Gender { get; set; }
    public int CountryCode { get; set; }
    public string AreaCode { get; set; }
    public string PhoneNumber { get; set; }

    public Student(string studentNumber, string surname,
        string firstName, string occupation, string gender,
        int countryCode, string areaCode, string phoneNumber)
    {
        StudentNumber = studentNumber;
        Surname = surname;
        FirstName = firstName;
        Occupation = occupation;
        Gender = gender;
        CountryCode = countryCode;
        AreaCode = areaCode;
        PhoneNumber = phoneNumber;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(
            $"{Surname}, {FirstName}, with student number {StudentNumber}, " +
            $"is a {Occupation.ToLower()}. " +
            $"His/Her phone number is {CountryCode}-{AreaCode}-{PhoneNumber}");
    }
}

class AseanPhonebook
{
    private List<Student> students = new List<Student>();

    public void StoreStudent()
    {
        Console.WriteLine("\n--- STORE STUDENT ---");

        Console.Write("Enter student number: ");
        string studentNumber = Console.ReadLine();

        Console.Write("Enter surname: ");
        string surname = Console.ReadLine();

        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter occupation: ");
        string occupation = Console.ReadLine();

        Console.Write("Enter gender (M/F): ");
        string gender = Console.ReadLine().ToUpper();

        Console.Write("Enter country code: ");
        int countryCode = int.Parse(Console.ReadLine());

        Console.Write("Enter area code: ");
        string areaCode = Console.ReadLine();

        Console.Write("Enter number: ");
        string phoneNumber = Console.ReadLine();

        Student newStudent = new Student(
            studentNumber,
            surname,
            firstName,
            occupation,
            gender,
            countryCode,
            areaCode,
            phoneNumber
        );

        students.Add(newStudent);

        Console.WriteLine("\nStudent added successfully!");
    }
}

class Program
{
    static void Main()
    {
        AseanPhonebook phonebook = new AseanPhonebook();

        phonebook.StoreStudent();
    }
}