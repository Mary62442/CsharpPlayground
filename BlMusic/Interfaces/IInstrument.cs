using BlMusic.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlMusic.Interfaces
{
    
    public interface IInstrument: IComparable<IInstrument>
    {
        string InstrumentName { get; set; }        
        InstrumentGroups InstrumentGroup { get; set; }
        bool IsAntiquity { get; set; }
        decimal InstrumentValue { get; set; }
    }
}
