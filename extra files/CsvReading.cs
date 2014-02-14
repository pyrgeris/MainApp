using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMOROnlineDetectors
{
    // Class made as the Payload class in ArmorInsightTools
    // The Timestamp value is excluded from this class because
    // it is added from the input adapter from the csv file.
    // It's purposes is only for testing the DSMS.
    public class CsvReading
    {
        /// <summary>
        /// Gets or sets the Electrode ID.
        /// </summary>
        public string SensorID { get; set; }

        /// <summary>
        /// Gets or sets sampling ratio of the dataset.
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        /// Gets or sets the recorded value of the current time.
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Gets or sets the electrodes name (hypothesis).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets start time of events.
        /// </summary>
        public string initTime { get; set; }

        /// <summary>
        /// Gets or sets a count value.
        /// </summary>
        public int count { get; set; }
    }

    public class CsvReading2
    {
        public string SensorID { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string initTime { get; set; }
    }
}
