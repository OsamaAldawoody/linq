using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linq
{
    
    class Program
    {
        static void Main(string[] args)
        {

            ITIEntities iti = new ITIEntities();

            //var students = from st in iti.Students select st;

            //var stu = from st in iti.Students group st by st.Dept_Id;

            var stu = from st in iti.Students
                      join ins in iti.Instructors
                      on st.St_super equals ins.Ins_Id
                      where st.St_super ==1
                      select st;

            var q = from st in stu
                    where st.St_super == 1
                    select st;

            var joinmethod = iti.Students.Where(st=>st.St_super==1)
                .Join(iti.Instructors,st => st.St_super,ins => ins.Ins_Id,(st, ins) => st);

            var students = iti.Students.Select(s=>s.St_Fname);
            var instructors = iti.Instructors.Select(i => i.Ins_Name);
            var concatGroup = students.Single();
            Console.WriteLine(concatGroup);
            //foreach (var item in concatGroup)
            //{
            //    Console.WriteLine(item);
            //    //Console.WriteLine("name : {0}\nid = {1}\n department = {2}\ninstructor = {3}",item.St_Fname,item.St_Id,item.Dept_Id,item.St_super);
            //    Console.WriteLine("____________________________");
            //}
           
            
            Console.ReadKey();
        }
    }
}
