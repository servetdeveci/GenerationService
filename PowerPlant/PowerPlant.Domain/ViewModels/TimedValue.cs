using System;

namespace PowerPlant.Domain.ViewModels
{
    public class TimedValue
    {
        public DateTime Timestamp { get; set; }
        public bool Good { get; set; }
        public object Value { get; set; }

    }
}
