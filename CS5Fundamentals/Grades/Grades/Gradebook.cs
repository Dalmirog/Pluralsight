﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class Gradebook
    {
        public Gradebook(string name = "There is no name")
        {
            Console.WriteLine("Gradebook ctor");
            Name = name;
            _grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public virtual GradeStatistics ComputeStatistics()
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

        public void WriteGrades(TextWriter textWriter)
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
         
        private string _name;

        public string Name
        {
            get 
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                    
                }
            }
        }

        public event NameChangedDelegate NameChanged;

        protected List<float> _grades;


    }
}