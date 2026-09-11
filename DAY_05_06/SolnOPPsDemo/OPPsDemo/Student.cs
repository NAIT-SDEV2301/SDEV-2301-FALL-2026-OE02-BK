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
                _age = value;
            }
            // Methods - define the behaviour
        }


        // constructor

        public Student( string name, int age )
        {
            Name = name;
            Age = age;
        }


    }




}

