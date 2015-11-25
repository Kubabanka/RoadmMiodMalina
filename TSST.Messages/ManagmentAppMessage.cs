using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Messages
{
    public class ManagmentAppMessage
    {
        private List<SwitchingPointConfiguration> matrixConfiguration;
        public List<SwitchingPointConfiguration> MatrixConfiguration
        {
            get
            {
                return matrixConfiguration;
            }
            set
            {
                matrixConfiguration = value;
            }
        }
    }
}
