using BlMusic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BlMusic.Enum;

namespace BlMusic.Classes
{


    [Serializable]
    public enum PianoBrands
    {
        BOSENDORFEN,
        YAMAHA,
        FAZIOLI,
        BECHSTEIN,
        STUART,
        BALDWIN
        
    }

    [Serializable]
    public enum PianoTypes
    {
        GRAND, 
        UPRIGHT,
        ELECTRIC
        
    }

    [Serializable]
    public class Piano:IInstrument,IComparable<IInstrument> 
    {

        public int CompareTo(IInstrument other)
        {

            if (other == null) return 1;
            Piano otherFlute = (Piano)other;
            return InstrumentName.CompareTo(otherFlute.InstrumentName) +
             InstrumentGroup.CompareTo(otherFlute.InstrumentGroup) +
             InstrumentValue.CompareTo(otherFlute.InstrumentValue) +
             IsAntiquity.CompareTo(otherFlute.IsAntiquity) +
             PianoBrand.CompareTo(otherFlute.PianoBrand) +
             PianoType.CompareTo(otherFlute.PianoType);

        }


        public PianoBrands PianoBrand { get; set; }
        public PianoTypes PianoType { get; set; }
        public string InstrumentName { get ; set; }
        public bool IsAntiquity { get; set; }
        public InstrumentGroups InstrumentGroup { get ; set ; }
        public decimal InstrumentValue { get; set; }
    }
}
