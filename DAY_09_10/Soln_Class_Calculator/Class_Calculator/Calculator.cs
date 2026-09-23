using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Calculator
{
    
     // Calculator.cs (Guided - optional TDD stub)
	// Implement each method after writing failing tests.

	

	public class Calculator
    {
        // TODO: Implement (return a + b)
        public int Add(int a, int b)
        {
            return a + b;
            //throw new NotImplementedException();
        }

        // TODO: Implement (return a - b)
        public int Subtract(int a, int b)
        {
            return (a - b);
            //throw new NotImplementedException();
        }

        // TODO: Implement (return a * b)
        public int Multiply(int a, int b)
        {
            // throw new NotImplementedException();
            return a * b;
        }

        // TODO: Implement:
        // - throw DivideByZeroException if b == 0
        // - otherwise return (double)a / b
        public double Divide(int a, int b)
        {
            // throw new NotImplementedException();
            return a / b;

        }
    }


}

