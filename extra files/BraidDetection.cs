using System;
using MathWorks.MATLAB.NET.Arrays;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ComplexEventProcessing.Linq;
using Microsoft.ComplexEventProcessing.Extensibility;
using System.Linq.Expressions;

namespace ARMOROnlineDetectors
{
    // A static class with the set of parameters and methods for performing the online
    // alpha rhythm detection.
    public static class BraidDetection
    {
        private static CepStream<double> detect(CepStream<double> inputStream)
        {
            return from win in inputStream.TumblingWindow<double>(TimeSpan.FromMinutes(6))
                   select win.BraidAgg<double>(e => e);
        }

              
        // Creates a binary stream of which windows exceed the threshold and
        // returns true on the first timestamp of every Alpha epoch and false on every other occasion. 
        public static CepStream<double> detectBraid(CepStream<CsvReading2> inputStream)
        {
            // It contains the values from the PSD calculation.
            var tmpStream = from e in inputStream
                            select e.Value1;

            var tmpStream2 = detect(tmpStream);

            //var tmpFlagString = from k in tmpStream2
            //                   select FlagConversion(k);

            return tmpStream2;
        }
        public static string FlagConversion(double val)
        {
            return val.ToString();
        }
    }
}
