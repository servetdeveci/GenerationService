using Shared.Domain.Base;
using System;

namespace PowerPlant.Domain.Entities
{
    public class PowerPlantHourlyDatum : EntityBase
    {
        public string PowerPlantId { get; set; }
        public bool Good { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate {  get; set; }
        public PowerPlantDef PowerPlant { get; set; }

    }
}
