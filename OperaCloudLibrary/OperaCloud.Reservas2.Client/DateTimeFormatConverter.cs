using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaCloud.Reservas2
{
    internal class DateTimeFormatConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateTimeFormatConverter()
        {
            DateTimeFormat = "MM'-'dd'-'yyyy'T'HH':'mm':'ss.FFFFFFFK";
        }
    }
}
