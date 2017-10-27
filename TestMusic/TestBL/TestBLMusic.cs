using BlMusic.Classes;
using BlMusic.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;
namespace TestMusic
{
    public class TestBl
    {
        private Musician MusicianToTest;
        public TestBl() { MusicianToTest = new Musician(); }

        [Fact(DisplayName = "Check type flute in Instrument")]
        public void CheckFluteType()
        {
            MusicianToTest.Instruments = new List<IInstrument>();
            MusicianToTest.Instruments.Add(new Flute());
            Type fluteType = typeof(Flute);
            Assert.Same(fluteType, MusicianToTest.Instruments[0].GetType());
        }

        [Fact(DisplayName = "Check if instrument guitar implements IInstrument")]
        public void FirstUnitOfTDD()
        {
            Guitar fender = new Guitar();
            Assert.True(fender is IInstrument);           
        }

    }


}
