using Microsoft.ComplexEventProcessing.Extensibility;
using Microsoft.ComplexEventProcessing.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;

namespace ARMOROnlineDetectors
{
    class BraidAggregate : CepAggregate<double, double>
    {
        public override double GenerateOutput(IEnumerable<double> samples,IEnumerable<double> samples2)
        {

            var array1 = samples.ToArray();
            Console.WriteLine("My array: {0}",string.Join(", ", array1.Select(v => v.ToString())));
            Console.ReadLine();
            return 1;
        }
    }  

    
}
