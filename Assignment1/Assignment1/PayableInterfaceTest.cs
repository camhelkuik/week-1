// Fig. 12.15: PayableInterfaceTest.cs
// Tests interface IPayable with disparate classes.
using System;
using System.Collections.Generic;

public class PayableInterfaceTest
{
    public static void Main(string[] args)
    {
        // create four-element IPayable array
        IPayable[] payableObjects = new IPayable[6];

        // populate array with objects that implement IPayable
        payableObjects[0] = new Invoice("01234", "seat", 2, 375M);
        payableObjects[1] = new Invoice("56789", "tire", 4, 79.95M);
        payableObjects[2] = new SalariedEmployee("John", "Smith", "111-11-1111", 800M);
        payableObjects[3] = new HourlyEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
        payableObjects[4] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, 0.06M);
        payableObjects[5] = new BasePlusCommissionEmployee("Bob", "Lewis", "444-44-4444", 5000M, 0.04M, 300M);

        Console.WriteLine("Invoices and Employees processed polymorphically:\n");

        // generically process each element in array payableObjects
        foreach (var currentPayable in payableObjects)
        {
            if (currentPayable is BasePlusCommissionEmployee)
            {
                Console.WriteLine($"{currentPayable}");

                var current = (BasePlusCommissionEmployee)currentPayable;

                current.BaseSalary *= 1.10M;
                Console.WriteLine("new base salary with 10% increase is: {0:C}\npayment due: {1:C}\n", current.BaseSalary, current.GetPaymentAmount());
            }
            else
            {
                // output currentPayable and its appropriate payment amount
                Console.WriteLine("{0}\npayment due: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
            }
            
        } // end foreach
        Console.ReadLine();
    } // end Main
} // end class PayableInterfaceTest


/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 
 *************************************************************************/
