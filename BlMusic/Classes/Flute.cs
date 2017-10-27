using BlMusic.Enum;
using BlMusic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlMusic.Classes
{
    [Serializable]
    public enum Materials
    {

        STEEL,
        SILVER,
        GOLD,
        PLATINUM,
        ALLOY
        
    }
    [Serializable]
    public enum FluteTypes
    {
        CLASSIC,
        BAROQUE,
        PICCOLO
        
    }
    [Serializable]
    public enum FluteBrands
    {
        JUPITER,
        YAMAHA,
        PEARL,
        MURAMATSU,
        SANKYO,
        POWELL,
        HAYNES,
        BRANNEN
        
    }

    [Serializable]
    public class Flute:IInstrument, IComparable<IInstrument>
    {
        public int CompareTo(IInstrument other)
        {            
            if (other == null) return 1;
            Flute otherFlute = (Flute)other;
            return InstrumentName.CompareTo(otherFlute.InstrumentName) +
             InstrumentGroup.CompareTo(otherFlute.InstrumentGroup) +
             InstrumentValue.CompareTo(otherFlute.InstrumentValue) +
             IsAntiquity.CompareTo(otherFlute.IsAntiquity) +
             FluteBrand.CompareTo(otherFlute.FluteBrand) +
             Material.CompareTo(otherFlute.Material) +
             FluteType.CompareTo(otherFlute.FluteType);         

        }

        public FluteBrands FluteBrand { get; set; }
        public Materials Material { get; set; }
        public FluteTypes FluteType { get; set; }
        public string InstrumentName { get ; set; }
        public bool IsAntiquity { get; set; }
        public InstrumentGroups InstrumentGroup { get ; set ; }
        public decimal InstrumentValue { get; set; }
    }
}
