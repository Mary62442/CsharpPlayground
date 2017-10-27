using BlMusic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BlMusic.Enum;

namespace BlMusic.Classes
{

    [Serializable]
    public enum GuitarBrands
    {
        YAMAHA,
        RAMIREZ,
        GIBSON,
        FENDER,
        MARTIN,
        ALVAREZ,
        LUNA,
        ALAHAMBRA,
        CORDOBA,
        PEPEROMERO
        
    }
    [Serializable]
    public enum GuitarTypes
    {
        CLASSIC,
        ACOUSTIC,
        ELECTRIC,
        TWELVESTRING,
        BASS,
        STEEL
        
    }


    [Serializable]
    public class Guitar:IInstrument, IComparable<IInstrument>
    {

        public int CompareTo(IInstrument other)
        {
            if (other == null) return 1;
            Guitar otherFlute = (Guitar)other;
            return InstrumentName.CompareTo(otherFlute.InstrumentName) +
             InstrumentGroup.CompareTo(otherFlute.InstrumentGroup) +
             InstrumentValue.CompareTo(otherFlute.InstrumentValue) +
             IsAntiquity.CompareTo(otherFlute.IsAntiquity) +
             GuitarBrand.CompareTo(otherFlute.GuitarBrand) +
             GuitarType.CompareTo(otherFlute.GuitarType);
        }


        public GuitarBrands GuitarBrand { get; set; }        
        public GuitarTypes GuitarType { get; set; }
        public string InstrumentName { get ; set ; }
        public InstrumentGroups InstrumentGroup { get; set ; }
        public bool IsAntiquity { get; set; }
        public decimal InstrumentValue { get; set; }
    }
}
