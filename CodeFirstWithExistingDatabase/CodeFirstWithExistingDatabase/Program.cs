using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstWithExistingDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context=new PlutoContext();

            // Linq Syntax
            var query = from c in context.Courses
                        where c.Name.Contains("C#")
                        orderby c.Name
                        select c;
                      

            foreach(var c in query)
            {
                Console.WriteLine(c.Name+"  "+c.Description);
            }

            //Console.WriteLine(query.ToString());

            //LINQ Extensions Method
            //using lambda expression
            var course = context.Courses
                .Where(c => c.Name.Contains("C#"))
                .OrderBy(c => c.Name);

            foreach (var c in course)
            {
                Console.WriteLine(c.Name + "  " + c.Description);
            }

            //Inner Join 
            Console.WriteLine("Inner Join....");
            var res = context.Courses.Join(context.Authors,
                c => c.Author_Id,
                a => a.Id,
                (cours, author) =>
                new
                {
                     CourseName=cours.Name,
                     AuthorName=author.Name
                });

            foreach(var c in res)
            {
                Console.WriteLine(c.CourseName+"  "+c.AuthorName
                    );
            }


            //Group Join 
            Console.WriteLine("Group Join....");
            var r = context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.Author_Id, (cour, author) => new
            {
                Author = author.Count(),
                Courses = cour.Name
            });

            foreach(var c in r)
            {
                Console.WriteLine(c.Courses+"  "+c.Author);
            }

            //Cross Join
            Console.WriteLine("Cross Join....");

            var n= context.Authors.SelectMany(a => context.Courses, (author, cours) => new
            {
                AuthorName = author.Name,
                CourseName = cours.Name
            });

            foreach(var c in n)
            {
                Console.WriteLine(c.CourseName);
            }


            // Lazy Loading..............
            // delaring the property virtual we enable this property for lazy lazy loading....
            //
            var lazy = context.Courses.Single(c => c.Id == 2);

            foreach(var tag in lazy.Tags) //in foreach block we send another query to data base is called Lazy Loading...
            {
                Console.WriteLine("lazy Loading : "+tag.Name);
            }

            //N+1 Problem....

            var n1p= context.Courses.ToList();

            foreach(var tag in n1p) //for N courses N extra queries in this for loop is called N+1 problem 
            {
                Console.WriteLine("{0} by {1}", tag.Name, tag.Author.Name);
            }

            //Eager Loading....
            //var eager = context.Courses.Include("Author").ToList(); insted of string we use Lambda Expression because if rename the property name it not reflect in string.
            var eager = context.Courses.Include(a => a.Author).ToList();  //Include Method Avoid N+1 Problem 
                                                                          // Include Method Create a inner join and Select Author and Courses Together insted of send extra query to database for each course in foreach block.
            foreach (var tag in eager)
            {
                Console.WriteLine("{0} by {1}", tag.Name, tag.Author.Name);
            }


            //Eager Loading for Single Properties

            /* var single= context.Courses.Include(c => c.Author.Address).ToList(); //In Author Entity Navigation Property Not Available
              foreach (var tag in single)                                           //If use Scaler Property it gives runtime error
              {
                  Console.WriteLine(tag.Name);
              }*/

            //Eager Loading for Collection Properties

            /*  var collection=context.Courses.Include(c=>c.Tags.Select(a=>a.Details));  //In Tag Entity Navigation Property Not Available
              foreach(var tag in collection)
              { Console.WriteLine(tag.Name); }
            */

            //-----------------------CHANGING DATA------------------------------------

            //Adding new Objects...

             var aut=context.Authors.Single(a=>a.Id == 3);

          /*   var addcourse= new Course
             {
                 Name = "Java",
                 Description = "OOPS",
                 FullPrice = 250,
                 Level = 1,
                 Author = aut,
             };

             context.Courses.Add(addcourse);
             context.SaveChanges();
          */
            //Update Object...

        /*    var updatecourse = context.Courses.Find(3);  //Single(a=>a.Id == 2);
            updatecourse.Name = "EntityFramework";
            updatecourse.Author_Id = 1;
            context.SaveChanges();
         */
            //Remove Object.... 

          /*  var removecourse = context.Authors.Include(c => c.Courses).Single(a => a.Id == 2);
            context.Courses.RemoveRange(removecourse.Courses);
            context.Authors.Remove(removecourse);
            context.SaveChanges();
         */
            Console.ReadLine();
        }
    }
}
