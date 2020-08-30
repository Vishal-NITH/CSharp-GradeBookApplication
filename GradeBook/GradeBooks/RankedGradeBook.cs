using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Students.Sort(CompareStudentByGrade);
            Type = GradeBookType.Ranked;
        }

        private static int CompareStudentByGrade(Student s1, Student s2)
        {
            return s2.AverageGrade.CompareTo(s1.AverageGrade);
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            if (averageGrade > Students[Students.Count / 5].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade > Students[2 * Students.Count / 5].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade > Students[3 * Students.Count / 5].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade > Students[4 * Students.Count / 5].AverageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students != null && Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in" +
                    " order to properly calculate a student's overall grade.");
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students != null && Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in " +
                    "order to properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
