using Shared.Domain.Base;
using System;
using System.Collections.Generic;

namespace PowerPlant.Domain.Entities
{
    public class PowerPlantDef : EntityBase
    {
        public string WebId { get; set; }
        public ICollection<PowerPlantHourlyDatum> PowerPlantHourlyData { get; set; }
    }
}
