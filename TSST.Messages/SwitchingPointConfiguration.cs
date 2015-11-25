using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Messages
{
    public class SwitchingPointConfiguration
    {
        private int inPort;
        public int InPort
        {
            get
            {
                return inPort;
            }
            set
            {
                inPort = value;
            }
        }

        private int outPort;
        public int OutPort
        {
            get
            {
                return outPort;
            }
            set
            {
                outPort = value;
            }
        }

        private float waveLength;
        public float WaveLength
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
    }
}
