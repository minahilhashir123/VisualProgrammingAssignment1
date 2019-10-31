using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgrammingAssignment1
{
    class Student
    {
        List<Student> listie;
        int semester;
        decimal dCGPA;
        float cgpa;
        string name, department, university, studentId, attendance;
        public Student()
        {
            listie = new List<Student>();
            semester = 0;
            cgpa = 0;
            dCGPA = 0;
            attendance = studentId = name = department = university = " ";
        }
        
        public void ReadFile()
        {
            string line = " ";
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\HO\Desktop\StudentInfo.txt");
            while ((line = file.ReadLine()) != null)
            {
                studentId = line;
                name = file.ReadLine();
                attendance = file.ReadLine();
                dCGPA = Convert.ToDecimal(file.ReadLine());
                cgpa = (float)dCGPA;
                semester = Convert.ToInt32(file.ReadLine());
                department = file.ReadLine();
                university = file.ReadLine();
                listie.Add(new Student() { studentId = this.studentId, name = this.name, semester = this.semester, cgpa = this.cgpa, department = this.department, university = this.university, attendance = this.attendance });
            }
            file.Close();
            
        }
        
        public void CreateNewStudent(string sId, string n, int s, float c, string d, string u, string a)
        {
            listie.Add(new Student(){ studentId = sId, name = n, semester = s, cgpa = c, department = d, university = u, attendance = a});

            using (StreamWriter write = new StreamWriter(@"C:\Users\HO\Desktop\StudentInfo.txt",true))
            {
                write.WriteLine("\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", sId, n, a, c, s, d, u);
            }
            Console.WriteLine("1st Name: {0}\n2nd Name: {1}\n3rd Name: {2}", listie[0].name,listie[1].name,listie[2].name);
        }
    }
}
