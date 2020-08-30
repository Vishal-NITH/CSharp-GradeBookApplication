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
            Students.Sort(CompareStudentByGrade);

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
    }
}
