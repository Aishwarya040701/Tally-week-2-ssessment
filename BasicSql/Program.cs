using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using System.Linq.Expressions;
using System.Security.Principal;

namespace consoleAppSqlBasic
{
    class Student:Subject
    {
        //Student Class Variable declaration
        public int studentID;
        public String studentName;
        public String studentAddress;
        public int studentClass;
        public String Maths;
        public String Science;
        public String Social;
        public String English;
        public String Hindi;


        //Creating constructor of StudentClass

        public Student()
        {

        }

        public Student(List<string> ListOfSubject)
        {
            this.Maths = ((string)ListOfSubject[0]);
            this.Science = ((string)ListOfSubject[1]);
            this.Social = ((string)ListOfSubject[2]);
            this.English = ((string)ListOfSubject[3]);
            this.Hindi = ((string)ListOfSubject[4]);
        }
        public Student(int studentID, String studentName, String studentAddress, int studentClass, List<string> ListOfSubject, int subjectID1, String subjectName1, int subjectMaxMarks1, int subjectMarksObtained1, int subjectID2, String subjectName2, int subjectMaxMarks2, int subjectMarksObtained2, int subjectID3, String subjectName3, int subjectMaxMarks3, int subjectMarksObtained3, int subjectID4, String subjectName4, int subjectMaxMarks4, int subjectMarksObtained4, int subjectID5, String subjectName5, int subjectMaxMarks5, int subjectMarksObtained5)
        {

            this.studentID = studentID;
            this.studentName = studentName;
            this.studentAddress = studentAddress;
            this.studentClass = studentClass;
            base.subjectID1 = subjectID1;
            base.subjectName1 = subjectName1;
            base.subjectMaxMarks1 = subjectMaxMarks1;
            base.subjectMarksObtained1 = subjectMarksObtained1;
            base.subjectID2 = subjectID2;
            base.subjectName2 = subjectName2;
            base.subjectMaxMarks2 = subjectMaxMarks2;
            base.subjectMarksObtained2 = subjectMarksObtained2;
            base.subjectID3 = subjectID3;
            base.subjectName3 = subjectName3;
            base.subjectMaxMarks3 = subjectMaxMarks3;
            base.subjectMarksObtained3 = subjectMarksObtained3;
            base.subjectID4 = subjectID4;
            base.subjectName4 = subjectName4;
            base.subjectMaxMarks4 = subjectMaxMarks4;
            base.subjectMarksObtained4 = subjectMarksObtained4;
            base.subjectID5 = subjectID5;
            base.subjectName5 = subjectName5;
            base.subjectMaxMarks5 = subjectMaxMarks5;
            base.subjectMarksObtained5 = subjectMarksObtained5;




            this.Maths = ((string)ListOfSubject[0]);
            this.Science = ((string)ListOfSubject[1]);
            this.Social = ((string)ListOfSubject[2]);
            this.English = ((string)ListOfSubject[3]);
            this.Hindi = ((string)ListOfSubject[4]);


        }



    }

    class Subject
    {

        //Maths
        public int subjectID1;
        public String subjectName1;
        public int subjectMaxMarks1;
        public int subjectMarksObtained1;

        //Science
        public int subjectID2;
        public String subjectName2;
        public int subjectMaxMarks2;
        public int subjectMarksObtained2;

        //Social
        public int subjectID3;
        public String subjectName3;
        public int subjectMaxMarks3;
        public int subjectMarksObtained3;

        //English
        public int subjectID4;
        public String subjectName4;
        public int subjectMaxMarks4;
        public int subjectMarksObtained4;


        //Hindi
        public int subjectID5;
        public String subjectName5;
        public int subjectMaxMarks5;
        public int subjectMarksObtained5;

    }



    class management
    {



        public static List<string> ListOfsubjects = new List<string> { "Maths", "Science", "Social", "English", "Hindi" };




        public static void Main(string[] args)
        {

            Student s1 = new Student(1, "Aishu", "Hassan", 9, ListOfsubjects, 001, "Maths", 100, 93, 002, "Science", 100, 91, 003,
                                "Social", 100, 88, 004, "English", 100, 85, 005, "Hindi", 100, 89);
            Student s2 = new Student(2, "Arya", "Mandya", 9, ListOfsubjects, 001, "Maths", 100, 85, 002, "Science", 100, 93, 003,
                    "Social", 100, 97, 004, "English", 100, 90, 005, "Hindi", 100, 75);
            Student s3 = new Student(3, "John", "Bangalore", 9, ListOfsubjects, 001, "Maths", 100, 80, 002, "Science", 100, 94, 003,
                    "Social", 100, 70, 004, "English", 100, 92, 005, "Hindi", 100, 80);
            Student s4 = new Student(4, "Geetha", "Mangalore", 9, ListOfsubjects, 001, "Maths", 100, 75, 002, "Science", 100, 66, 003,
                    "Social", 100, 69, 004, "English", 100, 79, 005, "Hindi", 100, 90);
            Student s5 = new Student(ListOfsubjects);
            Student s6 = new Student();

            List<Student> list0 = new List<Student>() { s1, s2, s3, s4 };

            string cs = "Data Source=BLR1-LHP-N80937;Initial Catalog=StudentDetails;Integrated Security=True";
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();
                    string query = null;
                    SqlCommand cmd;
                    while (true)
                    {
                        Console.WriteLine("enter the Choice\n 1. StoredProcedureForAdd 2.insert 3. RetriveAllData 4. Retrive 5.delete 6.updation");
                        int choice = int.Parse(Console.ReadLine());


                        switch (choice)
                        {

                            case 1:


                                for (int i = 0; i < list0.Count; i++)
                                {
                                   
                                   
                                    cmd = new SqlCommand();
                                    cmd.Connection = con;

                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "SPAddingStudentdata";
                                    Student s = (Student)list0[i];
                                    cmd.Parameters.AddWithValue("@id", s.studentID);

                                    cmd.Parameters.AddWithValue("@name", s.studentName);

                                    cmd.Parameters.AddWithValue("@address", s.studentAddress);
                                    cmd.Parameters.AddWithValue("@class", s.studentClass);
                                    cmd.Parameters.AddWithValue("@sub1", ListOfsubjects[0]);
                                    cmd.Parameters.AddWithValue("@sub2", ListOfsubjects[1]);
                                    cmd.Parameters.AddWithValue("@sub3", ListOfsubjects[2]);
                                    cmd.Parameters.AddWithValue("@sub4", ListOfsubjects[3]);
                                    cmd.Parameters.AddWithValue("@sub5", ListOfsubjects[4]);

                                    


                                    cmd.Parameters.AddWithValue("@subid1", s.subjectID1);
                                    cmd.Parameters.AddWithValue("@subname1", s.subjectName1);
                                    cmd.Parameters.AddWithValue("@submaxmarks1", s.subjectMaxMarks1);
                                    cmd.Parameters.AddWithValue("@submarksobtained1", s.subjectMarksObtained1);

                                    cmd.Parameters.AddWithValue("@subid2", s.subjectID2);
                                    cmd.Parameters.AddWithValue("@subname2", s.subjectName2);
                                    cmd.Parameters.AddWithValue("@submaxmarks2", s.subjectMaxMarks2);
                                    cmd.Parameters.AddWithValue("@submarksobtained2", s.subjectMarksObtained2);

                                    cmd.Parameters.AddWithValue("@subid3", s.subjectID3);
                                    cmd.Parameters.AddWithValue("@subname3", s.subjectName3);
                                    cmd.Parameters.AddWithValue("@submaxmarks3", s.subjectMaxMarks3);
                                    cmd.Parameters.AddWithValue("@submarksobtained3", s.subjectMarksObtained3);

                                    cmd.Parameters.AddWithValue("@subid4", s.subjectID4);
                                    cmd.Parameters.AddWithValue("@subname4", s.subjectName4);
                                    cmd.Parameters.AddWithValue("@submaxmarks4", s.subjectMaxMarks4);
                                    cmd.Parameters.AddWithValue("@submarksobtained4", s.subjectMarksObtained4);

                                    cmd.Parameters.AddWithValue("@subid5", s.subjectID5);
                                    cmd.Parameters.AddWithValue("@subname5", s.subjectName5);
                                    cmd.Parameters.AddWithValue("@submaxmarks5", s.subjectMaxMarks5);
                                    cmd.Parameters.AddWithValue("@submarksobtained5", s.subjectMarksObtained5);


                                    int a = cmd.ExecuteNonQuery();

                                    if (a > 0)
                                    {
                                        Console.WriteLine("Insert successful!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insertion Failed");
                                    }


                                }


                                break;

                            case 2:
                                


                                cmd = new SqlCommand();
                                cmd.Connection = con;

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "SPAddingStudentdata";



                                Console.WriteLine("Enter studentId:");
                                s6.studentID = int.Parse(Console.ReadLine());



                                Console.WriteLine("Enter studentName:");
                                s6.studentName = Console.ReadLine();
                                while (!s6.studentName.All(Char.IsLetter))
                                {
                                    Console.WriteLine("StudentName should contain letters  ,Number are not allowed");
                                    s6.studentName = Console.ReadLine();
                                }
                                Console.WriteLine("Enter studentAddress:");
                                s6.studentAddress = Console.ReadLine();
                                while (!s6.studentAddress.All(Char.IsLetter))
                                {
                                    Console.WriteLine("StudentAddress should contain letters  ,Number are not allowed");
                                    s6.studentAddress = Console.ReadLine();
                                }

                                Console.WriteLine("Enter studentClass:");
                                s6.studentClass = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter SubjectId1:");
                                s6.subjectID1 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectName1:");
                                s6.subjectName1 = Console.ReadLine();
                                while (!s6.subjectName1.All(Char.IsLetter))
                                {
                                    Console.WriteLine("SubjectName should contain letters  ,Number are not allowed");
                                    s6.subjectName1 = Console.ReadLine();
                                }
                                Console.WriteLine("Enter SubjectMaxMarks1:");
                                s6.subjectMaxMarks1 = int.Parse(Console.ReadLine());
                                while (s6.subjectMaxMarks1 != 100)
                                {
                                    Console.WriteLine("Max Marks should be 100");
                                    s6.subjectMaxMarks1 = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter SubjectmarksObtained1:");
                                s6.subjectMarksObtained1 = int.Parse(Console.ReadLine());
                                while (s6.subjectMarksObtained1 > 100)
                                {
                                    Console.WriteLine("Marks entered should be less than 100");
                                    s6.subjectMarksObtained1 = int.Parse(Console.ReadLine());
                                }


                                Console.WriteLine("Enter SubjectId2:");
                                s6.subjectID2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectName2:");
                                s6.subjectName2 = Console.ReadLine();

                                while (!s1.subjectName2.All(Char.IsLetter))
                                {
                                    Console.WriteLine("SubjectName should contain letters  ,Number are not allowed");
                                    s1.subjectName2 = Console.ReadLine();
                                }
                                Console.WriteLine("Enter SubjectMaxMarks2:");
                                s6.subjectMaxMarks2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectmarksObtained2:");
                                while (s6.subjectMaxMarks2 != 100)
                                {
                                    Console.WriteLine("Max Marks should be 100");
                                    s6.subjectMaxMarks2 = int.Parse(Console.ReadLine());
                                }
                                s1.subjectMarksObtained2 = int.Parse(Console.ReadLine());
                                while (s6.subjectMarksObtained2 > 100)
                                {
                                    Console.WriteLine("Marks entered should be less than 100");
                                    s6.subjectMarksObtained2 = int.Parse(Console.ReadLine());
                                }


                                Console.WriteLine("Enter SubjectId3:");
                                s6.subjectID3 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectName3:");
                                s6.subjectName3 = Console.ReadLine();
                                while (!s6.subjectName3.All(Char.IsLetter))
                                {
                                    Console.WriteLine("SubjectName should contain letters  ,Number are not allowed");
                                    s6.subjectName3 = Console.ReadLine();
                                }
                                Console.WriteLine("Enter SubjectMaxMarks3:");
                                s6.subjectMaxMarks3 = int.Parse(Console.ReadLine());
                                while (s6.subjectMaxMarks3 != 100)
                                {
                                    Console.WriteLine("Max Marks should be 100");
                                    s6.subjectMaxMarks3 = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter SubjectmarksObtained3:");
                                s6.subjectMarksObtained3 = int.Parse(Console.ReadLine());
                                while (s6.subjectMarksObtained3 > 100)
                                {
                                    Console.WriteLine("Marks entered should be less than 100");
                                    s6.subjectMarksObtained3 = int.Parse(Console.ReadLine());
                                }


                                Console.WriteLine("Enter SubjectId4:");
                                s6.subjectID4 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectName4:");
                                s6.subjectName4 = Console.ReadLine();
                                while (!s6.subjectName4.All(Char.IsLetter))
                                {
                                    Console.WriteLine("SubjectName should contain letters ,Number are not allowed");
                                    s6.subjectName4 = Console.ReadLine();
                                }

                                Console.WriteLine("Enter SubjectMaxMarks4:");
                                s6.subjectMaxMarks4 = int.Parse(Console.ReadLine());
                                while (s6.subjectMaxMarks4 != 100)
                                {
                                    Console.WriteLine("Max Marks should be 100");
                                    s6.subjectMaxMarks4 = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Enter SubjectmarksObtained4:");
                                s1.subjectMarksObtained4 = int.Parse(Console.ReadLine());
                                while (s6.subjectMarksObtained4 > 100)
                                {
                                    Console.WriteLine("Marks entered should be less than 100");
                                    s6.subjectMarksObtained4 = int.Parse(Console.ReadLine());
                                }


                                Console.WriteLine("Enter SubjectId5:");
                                s6.subjectID5 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter SubjectName5:");
                                s6.subjectName5 = Console.ReadLine();
                                while (!s6.subjectName5.All(Char.IsLetter))
                                {
                                    Console.WriteLine("SubjectName should contain letters ,Number are not allowed");
                                    s6.subjectName5 = Console.ReadLine();
                                }
                                Console.WriteLine("Enter SubjectMaxMarks5:");
                                s6.subjectMaxMarks5 = int.Parse(Console.ReadLine());
                                while (s6.subjectMaxMarks5 != 100)
                                {
                                    Console.WriteLine("Max Marks should be 100");
                                    s6.subjectMaxMarks5 = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Enter SubjectmarksObtained5:");
                                s6.subjectMarksObtained5 = int.Parse(Console.ReadLine());
                                while (s6.subjectMarksObtained5 > 100)
                                {
                                    Console.WriteLine("Marks entered should be less than 100");
                                    s6.subjectMarksObtained5 = int.Parse(Console.ReadLine());
                                }



                                
                                    cmd.Parameters.AddWithValue("@id", s6.studentID);

                                    cmd.Parameters.AddWithValue("@name", s6.studentName);

                                    cmd.Parameters.AddWithValue("@address", s6.studentAddress);
                                    cmd.Parameters.AddWithValue("@class", s6.studentClass);
                                    cmd.Parameters.AddWithValue("@sub1", ListOfsubjects[0]);
                                    cmd.Parameters.AddWithValue("@sub2", ListOfsubjects[1]);
                                    cmd.Parameters.AddWithValue("@sub3", ListOfsubjects[2]);
                                    cmd.Parameters.AddWithValue("@sub4", ListOfsubjects[3]);
                                    cmd.Parameters.AddWithValue("@sub5", ListOfsubjects[4]);
                                    

                                    cmd.Parameters.AddWithValue("@subid1", s6.subjectID1);
                                    cmd.Parameters.AddWithValue("@subname1", s6.subjectName1);
                                    cmd.Parameters.AddWithValue("@submaxmarks1", s6.subjectMaxMarks1);
                                    cmd.Parameters.AddWithValue("@submarksobtained1", s6.subjectMarksObtained1);

                                    cmd.Parameters.AddWithValue("@subid2", s6.subjectID2);
                                    cmd.Parameters.AddWithValue("@subname2", s6.subjectName2);
                                    cmd.Parameters.AddWithValue("@submaxmarks2", s6.subjectMaxMarks2);
                                    cmd.Parameters.AddWithValue("@submarksobtained2", s6.subjectMarksObtained2);

                                    cmd.Parameters.AddWithValue("@subid3", s6.subjectID3);
                                    cmd.Parameters.AddWithValue("@subname3", s6.subjectName3);
                                    cmd.Parameters.AddWithValue("@submaxmarks3", s6.subjectMaxMarks3);
                                    cmd.Parameters.AddWithValue("@submarksobtained3", s6.subjectMarksObtained3);

                                    cmd.Parameters.AddWithValue("@subid4", s6.subjectID4);
                                    cmd.Parameters.AddWithValue("@subname4", s6.subjectName4);
                                    cmd.Parameters.AddWithValue("@submaxmarks4", s6.subjectMaxMarks4);
                                    cmd.Parameters.AddWithValue("@submarksobtained4", s6.subjectMarksObtained4);

                                    cmd.Parameters.AddWithValue("@subid5", s6.subjectID5);
                                    cmd.Parameters.AddWithValue("@subname5", s6.subjectName5);
                                    cmd.Parameters.AddWithValue("@submaxmarks5", s6.subjectMaxMarks5);
                                    cmd.Parameters.AddWithValue("@submarksobtained5", s6.subjectMarksObtained5);
                                    int e = cmd.ExecuteNonQuery();

                                    if (e > 0)
                                    {
                                        Console.WriteLine("Insert successful!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insertion Failed");
                                    }


                               


                                break;

                            case 3:


                              

                                query = "Select * from viewStudentDetails";




                                cmd = new SqlCommand(query, con);
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {

                                   

                                    while (dr.Read())
                                    {

                                       
                                        for (int i = 0; i < 29; i++)
                                        {
                                            Console.Write(dr[i] + " ");
                                        }
                                        Console.WriteLine();
                                    }
                                }
                                break;
                            case 4:
                      
                                
                                query= "select * from FunctionRetrive(3)";


                                cmd = new SqlCommand(query, con);
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {

                                    
                                    
                                    while (dr.Read())
                                    {

                                       
                                     
                                        for (int i = 0; i < dr.FieldCount; i++)
                                        {
                                            Console.Write(dr[i] + "  ");
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            case 5:
                                query = " delete from Student  ";
                                cmd = new SqlCommand(query, con);
                                int b = cmd.ExecuteNonQuery();

                                if (b > 0)
                                {
                                    Console.WriteLine("Delete successful!!");
                                }
                                else
                                {
                                    Console.WriteLine("delete Failed");
                                }

                                break;


                            case 6:
                                query = "update viewStudentDetails set StudentName='Chinni',StudentAddress='Kuvempunagar' where StudentId=1;";
                                cmd = new SqlCommand(query, con);

                              

                                int c = cmd.ExecuteNonQuery();

                                if (c > 0)
                                {
                                    Console.WriteLine("updation successful!!");
                                }
                                else
                                {
                                    Console.WriteLine("updation  Failed");
                                }
                                break;
                        }


                        
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }


    }

}
