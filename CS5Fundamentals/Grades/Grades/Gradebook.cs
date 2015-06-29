﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class Gradebook : GradeTracker
    {
        public Gradebook(string name = "There is no name")
        {
            Console.WriteLine("Gradebook ctor");
            Name = name;
            _grades = new List<float>();
        }

        public override void DoSomething()
        {

        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook Compute");
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0f;

            foreach(float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
                
            }

            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");

            int i = 0;
            do
            {
                textWriter.WriteLine(_grades[i]);
                i++;
            } while (i< _grades.Count);
            textWriter.WriteLine("*********");
        }    

        protected List<float> _grades;

    }
}