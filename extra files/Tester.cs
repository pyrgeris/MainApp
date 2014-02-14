using System;
using Microsoft.ComplexEventProcessing.Linq;
using System.Threading;
using ARMOROnlineDetectors;
using StreamInsight.Samples.Adapters.SimpleTextFileReader; // Microsoft Input Adapter from CSV 
using System.Collections.ObjectModel;
using Microsoft.ComplexEventProcessing;   // used by the input adapter

namespace ArmorInsightTools
{
    class Tester
    {
        static void Main(string[] args)
        {
 
            // =============== DSMS stand alone initialization=================
            Server server = Server.Create("Instance2");
            Application myApp = server.CreateApplication("TrafficJoinSample");; //
            var valueStream = StandAloneInput2.ReadFile(myApp);
  
            var detectionStream = BraidDetection.detectBraid(valueStream);
            //StandAloneOutput.ConsoleOutput(detectionStream, myApp);
                     
            //Console.WriteLine(detectionStream);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

}
