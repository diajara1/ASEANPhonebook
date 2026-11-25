using System;
using System.Collections.Generic;
using System.Linq;

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

    private Dictionary<int, string> countries = new Dictionary<int, string>()
    {
        { 60, "Malaysia" },
        { 62, "Indonesia" },
        { 63, "Philippines" },
        { 65, "Singapore" },
        { 66, "Thailand" }
    };

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

        Console.WriteLine("\nCountry codes:");
        Console.WriteLine("60 - Malaysia");
        Console.WriteLine("62 - Indonesia");
        Console.WriteLine("63 - Philippines");
        Console.WriteLine("65 - Singapore");
        Console.WriteLine("66 - Thailand");

        Console.Write("Enter country code: ");
        int countryCode = int.Parse(Console.ReadLine());

        Console.Write("Enter area code: ");
        string areaCode = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Student newStudent = new Student(
            studentNumber, surname, firstName, occupation,
            gender, countryCode, areaCode, phoneNumber
        );

        students.Add(newStudent);

        Console.WriteLine("\nStudent added successfully!");
    }

    public void EditStudent()
    {
        Console.WriteLine("\n--- EDIT STUDENT ---");

        Console.Write("Enter student number to search: ");
        string searchNumber = Console.ReadLine();

        Student foundStudent = null;

        foreach (Student student in students)
        {
            if (student.StudentNumber == searchNumber)
            {
                foundStudent = student;
                break;
            }
        }

        if (foundStudent == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("\nStudent found!");
        foundStudent.DisplayInfo();

        int choice;

        do
        {
            Console.WriteLine("\n--- EDIT MENU ---");
            Console.WriteLine("[1] Student number");
            Console.WriteLine("[2] Surname");
            Console.WriteLine("[3] Gender");
            Console.WriteLine("[4] Occupation");
            Console.WriteLine("[5] Country code");
            Console.WriteLine("[6] Area code");
            Console.WriteLine("[7] Phone number");
            Console.WriteLine("[8] Back");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new student number: ");
                    foundStudent.StudentNumber = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Enter new surname: ");
                    foundStudent.Surname = Console.ReadLine();
                    break;

                case 3:
                    Console.Write("Enter new gender (M/F): ");
                    foundStudent.Gender = Console.ReadLine().ToUpper();
                    break;

                case 4:
                    Console.Write("Enter new occupation: ");
                    foundStudent.Occupation = Console.ReadLine();
                    break;

                case 5:
                    Console.Write("Enter new country code: ");
                    foundStudent.CountryCode = int.Parse(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("Enter new area code: ");
                    foundStudent.AreaCode = Console.ReadLine();
                    break;

                case 7:
                    Console.Write("Enter new phone number: ");
                    foundStudent.PhoneNumber = Console.ReadLine();
                    break;

                case 8:
                    Console.WriteLine("Returning...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (choice >= 1 && choice <= 7)
            {
                Console.WriteLine("Student information updated!");
            }

        } while (choice != 8);
    }

    public void SearchByCountry()
    {
        List<int> selectedCodes = new List<int>();
        int choice;

        do
        {
            Console.WriteLine("\n--- SEARCH BY COUNTRY ---");
            Console.WriteLine("[1] Malaysia");
            Console.WriteLine("[2] Indonesia");
            Console.WriteLine("[3] Philippines");
            Console.WriteLine("[4] Singapore");
            Console.WriteLine("[5] Thailand");
            Console.WriteLine("[6] ALL");
            Console.WriteLine("[0] No More");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    selectedCodes.Add(60);
                    break;

                case 2:
                    selectedCodes.Add(62);
                    break;

                case 3:
                    selectedCodes.Add(63);
                    break;

                case 4:
                    selectedCodes.Add(65);
                    break;

                case 5:
                    selectedCodes.Add(66);
                    break;

                case 6:
                    selectedCodes.Clear();
                    selectedCodes.AddRange(countries.Keys);
                    choice = 0;
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);

        List<Student> results = students
            .Where(s => selectedCodes.Contains(s.CountryCode))
            .OrderBy(s => s.Surname)
            .ToList();

        Console.WriteLine("\n--- SEARCH RESULTS ---");

        if (results.Count == 0)
        {
            Console.WriteLine("No students found.");
        }
        else
        {
            foreach (Student student in results)
            {
                student.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        AseanPhonebook phonebook = new AseanPhonebook();
        int choice;

        do
        {
            Console.WriteLine("\n=== ASEAN PHONEBOOK ===");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    phonebook.StoreStudent();
                    break;

                case 2:
                    phonebook.EditStudent();
                    break;

                case 3:
                    phonebook.SearchByCountry();
                    break;

                case 4:
                    Console.WriteLine("Exiting phonebook...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}