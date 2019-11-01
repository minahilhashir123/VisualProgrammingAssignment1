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
        public int CheckStudentID(string id)
        {
            int check = 0, index = 0;
            for (int i = 0; i < listie.Count(); i++)
            {
                if (listie[i].studentId == id)
                {
                    index = i;
                    check++;
                }
            }
            if (check > 0)
                return index;
            else
                return -1;

        }
        public void CreateNewStudent(string sId, string n, int s, float c, string d, string u, string a)
        {
            int check = CheckStudentID(sId);
            if (check == -1)
            {
                listie.Add(new Student() { studentId = sId, name = n, semester = s, cgpa = c, department = d, university = u, attendance = a });
                using (StreamWriter write = new StreamWriter(@"C:\Users\HO\Desktop\StudentInfo.txt", true))
                {
                    write.WriteLine("\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", sId, n, a, c, s, d, u);
                }
                //Console.WriteLine("1st Name: {0}\n2nd Name: {1}\n3rd Name: {2}", listie[0].name,listie[1].name,listie[2].name);
                Console.WriteLine("\nStudent Successfully Added.");
            }
            else
            {
                int option = 0;
                Console.WriteLine("A student with this Student ID already exists.\nPress\n\t1. Delete previously entered student data\n\t2. Delete this student data\n\n\tOption: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            DeleteStudent(sId);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Data Successfully Deleted");
                            break;
                        }
                }
            }

        }
        public void SearchStudentByID(string id)
        {
            int index = CheckStudentID(id);
            if (index == -1)
                Console.WriteLine("Student Not Found.");
            else
                Console.WriteLine("Student Data\n\nID: {0}\nName: {1}\nAttendance: {2}\nCGPA: {3}\nSemester: {4}\nDepartment: {5}\nUniversity: {6}\n", listie[index].studentId, listie[index].name, listie[index].attendance, listie[index].cgpa, listie[index].semester, listie[index].department, listie[index].university);
        }
        public void SearchStudentByName(string name)
        {
            int check = 0, index = 0;
            for (int i = 0; i < listie.Count(); i++)
            {
                string listieName = listie[i].name.Substring(0, name.Length);
                if (name == listieName)
                {
                    check++;
                    index = i;
                }
            }
            if (check > 0)
                Console.WriteLine("\nStudent Data\n\nID: {0}\nName: {1}\nAttendance: {2}\nCGPA: {3}\nSemester: {4}\nDepartment: {5}\nUniversity: {6}", listie[index].studentId, listie[index].name, listie[index].attendance, listie[index].cgpa, listie[index].semester, listie[index].department, listie[index].university);
            else
                Console.WriteLine("Student Not Found.");
        }
        public void DeleteStudent(string id)
        {
            int index = 0, fileIndex = -1;
            index = CheckStudentID(id);
            if (index != -1)
            {
                listie.RemoveAt(index);
                string[] lines = File.ReadAllLines(@"C:\Users\HO\Desktop\StudentInfo.txt");
                List<string> deleteList = new List<string>(lines);
                File.Delete(@"C:\Users\HO\Desktop\StudentInfo.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == id)
                    {
                        fileIndex = i;
                        break;
                    }
                }
                deleteList.RemoveRange(fileIndex, 7);

                using (StreamWriter write = File.AppendText(@"C:\Users\HO\Desktop\StudentInfo.txt"))
                {
                    foreach (string el in deleteList)
                    {
                        write.WriteLine(el);
                    }
                }
            }
            else
                Console.WriteLine("Student Not Found");
        }
        public void MarkAttendance()
        {
            int index = 2;
            string[] attArray = File.ReadAllLines(@"C:\Users\HO\Desktop\StudentInfo.txt");
            for (int i = 0; i < listie.Count; i++)
            {
                char att = ' ';
                Console.Write("{0}\t{1}\t\tAttendance: ", listie[i].studentId, listie[i].name);
                att = Convert.ToChar(Console.ReadLine());
                
                if (att == 'P' || att == 'p')
                {
                    listie[i].attendance = "Present";
                    attArray[index] = "P";

                }
                else if (att == 'A' || att == 'a')
                {
                    listie[i].attendance = "Absent";
                    attArray[index] = "A";

                }
                else
                    Console.WriteLine("Invalid Input");
                index += 7;
            }
            File.WriteAllLines(@"C:\Users\HO\Desktop\StudentInfo.txt", attArray);
        }
        public void ViewAttendance()
        {
            for (int i = 0; i < listie.Count; i++)
            {
                Console.WriteLine("{0}\t{1}\t\tAttendance ", listie[i].studentId, listie[i].name, listie[i].attendance);
            }
        }
        public void Display()
        {
            Console.WriteLine("Id\tName\tAttendance\tCgpa\tSemester\tDepartment\tUniversity");
            for(int i = 0; i<listie.Count; i++)
            {
                Console.WriteLine(listie[i].studentId + "\t" + listie[i].name + "\t\t" + listie[i].attendance + "\t" + listie[i].cgpa + "\t\t" + listie[i].semester + "\t" + listie[i].department + "\t\t" + listie[i].university);
            }
        }
        public void TopThree()
        {
            listie.Sort((x, y) => y.cgpa.CompareTo(x.cgpa));
            Console.WriteLine("Id\tName\tAttendance\tCgpa\tSemester\tDepartment\tUniversity");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(listie[i].studentId + "\t" + listie[i].name + "\t\t" + listie[i].attendance + "\t" + listie[i].cgpa + "\t\t" + listie[i].semester + "\t" + listie[i].department + "\t\t" + listie[i].university);
            }
        }
    }
}
