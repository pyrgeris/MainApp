using Microsoft.ComplexEventProcessing;
using Microsoft.ComplexEventProcessing.Linq;
using StreamInsight.Samples.Adapters.SimpleTextFileReader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMOROnlineDetectors
{
    public class StandAloneInput2
    {

        public static CepStream<CsvReading2> ReadFile(Application myApp)
        {
            // =============== Read data from CSV file ========================
            var sensorInputConf = new TextFileReaderConfig
            {
                InputFileName = @"..\..\..\dataset.csv",// Location of the file where the data exist 
                Delimiter = ',',
                CtiFrequency = 99, // CTI frequency depending on the Sampling Rate.
                CultureName = "el-GR",
                InputFieldOrders = new Collection<string>() { "SensorID", "SampleRate", "Value", "Type", "initTime", "count" }
            };


            // Parameters for creating the  Input Stream from the file.
            var atgs = new AdvanceTimeGenerationSettings(99, TimeSpan.FromSeconds(0), true);
            var ats = new AdvanceTimeSettings(atgs, null, AdvanceTimePolicy.Adjust);

            // I need an application ID to attach the input stream
            var myStream = CepStream<CsvReading>.Create(
                myApp,
                "input stream",
                typeof(TextFileReaderFactory),
                sensorInputConf,
                EventShape.Point,
                ats);
            
            // Get the channel. CAUTION: SensorID???
            var valueStream1 = from e in myStream
                               where e.SensorID=="EEG1"
                              select e;
            var valueStream2 = from e in myStream
                              where e.SensorID == "EEG2"
                              select e;
            // =============== End of reading data from CSV file ========================
            var stream = from e1 in valueStream1
                             from e2 in valueStream2
                              select
                                  new CsvReading2
                                  {
                                      SensorID = e1.SensorID,
                                      Value1 = e1.Value,
                                      Value2 =e2.Value,
                                      initTime = e1.initTime
                                  };
            return stream;
            // Or this one
            //var alphaStream = from e in valueStream.HoppingWindow<double>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
            //                  select e.alphaAgg<double>(a => a);

            //var detectionStream = from e in alphaStream
            //                      where e > AlphaDetection.alphaThreshold
            //                      select e;


            // ===================== END of Alpha Rhythm Detection =====================

            
        }

    }
 
}
