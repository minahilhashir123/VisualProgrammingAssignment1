using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgrammingAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            int mainMenuOption = 0, semester = 0;
            float cgpa;
            decimal dCGPA = 0;
            string name = " ", department = " ", university = " ", studentId = " ", attendance = " ";
            Console.Write("\tMain Menu\n\nSelect any of the following:\n\t1. Create Student profile\n\t2. Search Student\n\t3. Delete Student Record\n\t4. List top 3 Students\n\t5. Mark Student Attendance\n\t6. View Attendance\n\n\tOption: ");
            mainMenuOption = Convert.ToInt32(Console.ReadLine());
            s.ReadFile();
            Console.Clear();
            switch (mainMenuOption)
            {
                case 1:
                    {
                        Console.WriteLine("\tCreate Student Profile\n");
                        Console.Write("Enter the fololwing data for a new student:\n\tStudent ID: ");
                        studentId = Console.ReadLine();
                        Console.Write("\tStudent Name: ");
                        name = Console.ReadLine();
                        Console.Write("\tAttendance (P/A): ");
                        attendance = Console.ReadLine();
                        Console.Write("\tCGPA: ");
                        dCGPA = Convert.ToDecimal(Console.ReadLine());
                        cgpa = (float)dCGPA;
                        Console.Write("\tSemester: ");
                        semester = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\tDepartment: ");
                        department = Console.ReadLine();
                        Console.Write("\tUniversity: ");
                        university = Console.ReadLine(); 
                        s.CreateNewStudent(studentId, name, semester, cgpa, department, university, attendance);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\tSearch Student\n");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\tDelete Student\n");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("\tList top 3 Students\n");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("\tMark Student Attendance\n");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("\tView Attendance\n");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
