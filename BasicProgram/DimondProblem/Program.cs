using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimondProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Vehicle
    {

    }

    class Country:Vehicle
    {

    }

    class Type:Vehicle
    {

    }
    class VehicleDetails : Country ,Type //Dimond Problem , We can not inherit more than one class
    {
        
    }

    interface A
    {

    }
    interface B
    {

    }

    class Test:A,B  //using interface resolve Dimond Problem
    {

    }
}
