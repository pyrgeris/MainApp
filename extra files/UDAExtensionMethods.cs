using alphadetector;
using MathWorks.MATLAB.NET.Arrays;
using Microsoft.ComplexEventProcessing.Extensibility;
using Microsoft.ComplexEventProcessing.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARMOROnlineDetectors
{
    public static class UDAExtensionMethods
    {
        [CepUserDefinedAggregate(typeof(AlphaAggregate))]
        public static double alphaAgg<InputT>(this CepWindow<InputT> window, Expression<Func<InputT, double>> map)
        {
            throw CepUtility.DoNotCall();
        }

        [CepUserDefinedAggregate(typeof(BraidAggregate))]
        public static double BraidAgg<InputT>(this CepWindow<InputT> window, Expression<Func<InputT, double>> map)
        {
            throw CepUtility.DoNotCall();
        }

        [CepUserDefinedAggregate(typeof(EdgeAggregate))]
        public static bool edgeAgg<InputT>(this CepWindow<InputT> window, Expression<Func<InputT, bool>> map)
        {
            throw CepUtility.DoNotCall();
        }
    }
}
