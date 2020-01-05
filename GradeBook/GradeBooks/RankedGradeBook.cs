using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            List<double> ListOfGrades = new List<double>();
            int Threshold = (int)(Math.Ceiling(Students.Count * 0.2));
            if(Students.Count < 5)
            throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            foreach(var student in Students)
            {
                ListOfGrades.Add(student.AverageGrade);
                
            }
            ListOfGrades.Sort();
            ListOfGrades.Reverse();
            if(ListOfGrades[Threshold - 1] <= averageGrade)
                return 'A';
            else if(ListOfGrades[Threshold * 2 - 1] <= averageGrade)
                return 'B';
            else if (ListOfGrades[Threshold * 3 - 1] <= averageGrade)
                return 'C';
            else if (ListOfGrades[Threshold * 4 - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else

                base.CalculateStatistics();
        }

    }

}
