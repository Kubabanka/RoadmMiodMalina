using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Messages
{
    public class ROADMMessage
    {
        private float[] waveLength;
        public float[] WaveLength
        {
            get
            {
                return waveLength;
            }
            set
            {
                waveLength = value;
            }
        }

        private string[] data;
        public string[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}
