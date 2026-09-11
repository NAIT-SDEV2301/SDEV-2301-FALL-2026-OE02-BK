using System;
using System.Collections.Generic;
using System.Text;

namespace OPPsDemo
{
    public class Student
    {
        // Fields - private data members
        private string _name;
        private int _age;

        // properties - help to read/write the private data member

        public string Name
        {                //auto implemented property

            get
            {                   // reading private data member
                return _name;

            }
            set
            {                    // writing private data member
                _name = value;
            }
            // Methods - define the behaviour
        }

        public int Age
        {                //auto implemented property

            get
            {                   // reading private data member
                return _age;

            }
            set
            {                    // writing private data member

                // validation checks 

                if (value < 1 || value >= 120)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age should be between 1 and 120");
                }
                else {
                    _age = value;
                }

            }

        }


        // constructor

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }


        // Methods - define the behaviour

        public void DisplayStudentRecord()
            {
            Console.WriteLine($"Student 1 name is: {Name}");
            Console.WriteLine($"Student 1 age is: {Age}");

        }

        // update student record

        public void UpdateStudentRecord()
        {
            Console.WriteLine($"Enter name to be updated");
            string vName = Console.ReadLine();

            Name = vName; 
            

        }
    }




}

