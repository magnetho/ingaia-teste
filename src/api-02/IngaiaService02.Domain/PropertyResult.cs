using System;
using System.Collections.Generic;
using System.Text;

namespace IngaiaService02.Domain
{
    public class PropertyResult
    {
        /// <summary>
        /// quantidade do metros quadrado.
        /// </summary>
        public double Meter { get; }
        /// <summary>
        /// Valor do metros quadrado.
        /// </summary>
        public double MeterValue { get; }
        /// <summary>
        /// Valor do imóvel 
        /// </summary>
        public double PropertyValue { get; }


        public PropertyResult( double meter, double meterValue)
        {
            this.Meter = meter;
            this.MeterValue = meterValue;
            this.PropertyValue = meter * meterValue;

        }



    }
}
