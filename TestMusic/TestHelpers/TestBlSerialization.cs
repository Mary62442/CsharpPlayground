using BlMusic.Classes;
using BlMusic.Enum;
using BlMusic.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

using System.Runtime.Serialization.Json;
using System.Text;
using Xunit;
using System;

namespace TestMusic.TestBlSerialization
{
    public class TestBlSerialization
    {

        private Musician Diego;

        public TestBlSerialization() {
            
            Diego = new Musician()
            {
                Name = "Diego",
                Surname = "Burlando",
                Email = "diego@dmm888.com",
                Location = "Genoa",
                Age = 55,
                Nationality = "Italian",
                Gender = Genders.MALE,
                Instruments = new List<IInstrument> {
                    new Guitar()
                    {
                        GuitarBrand = GuitarBrands.RAMIREZ,
                        GuitarType = GuitarTypes.CLASSIC,
                        InstrumentGroup = InstrumentGroups.STRINGS,
                        InstrumentName = "Guitar",
                        InstrumentValue = 15230.55M,
                        IsAntiquity = false
                    },
                    new Flute()
                    {
                        FluteBrand = FluteBrands.MURAMATSU,
                        FluteType = FluteTypes.CLASSIC,
                        InstrumentGroup = InstrumentGroups.STRINGS,
                        InstrumentName = "Flute",
                        InstrumentValue = 23450M,
                        IsAntiquity = false
                    },
                    new Piano()
                    {
                        PianoBrand = PianoBrands.BOSENDORFEN,
                        PianoType = PianoTypes.GRAND,
                        InstrumentGroup = InstrumentGroups.STRINGS,
                        InstrumentName = "Piano",
                        InstrumentValue = 103324M,
                        IsAntiquity = true
                    }
                },
                Proficiency = "Advanced",
                YearsOfStudy = 27,
                MusicStyle = MusicStyles.CLASSIC

            };

        }

        [Fact(DisplayName = "Test Binary serialization on Musician")]
        public void TestBinarySerialization() {
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Diego.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Diego);
            stream.Close();
        }
        
        
        [Fact(DisplayName = "Test Binary Deserialization on Musician")]
        public void TestBinaryDeSerialization() {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Diego.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Musician DiegoFromBinaryStore = (Musician)formatter.Deserialize(stream);
            stream.Close();
            int counter = 0;          
            foreach (IInstrument ies in Diego.Instruments)
            {
                Assert.Equal<int>(ies.CompareTo(DiegoFromBinaryStore.Instruments[counter]), 0);
                counter++;
            }


            Assert.Equal(Diego.Age, DiegoFromBinaryStore.Age);
            Assert.Equal(Diego.Email, DiegoFromBinaryStore.Email);
            Assert.Equal(Diego.Gender, DiegoFromBinaryStore.Gender);
        }



        [Fact(DisplayName = "Test XML serialization on Flute Type")]
        public void XmlSerialization()
        {
            var flute = new Flute() { InstrumentName = "The flute of the golden king", InstrumentValue = 2000 };
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (XmlTextWriter xml = new XmlTextWriter(stream, new UTF8Encoding(false)))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Flute));
                        xs.Serialize(xml, flute);
                        string xmlData = Encoding.UTF8.GetString(((MemoryStream)xml.BaseStream).ToArray());
                        Assert.True(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.False(true);
            }

        }


        [Fact(DisplayName = "Test XML Deserialization on Flute Type")]
        public void XmlDeSerialization()
        {
            string xmlFluteData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Flute xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><FluteBrand>JUPITER</FluteBrand><Material>STEEL</Material><FluteType>CLASSIC</FluteType><InstrumentName>The flute of the golden king</InstrumentName><IsAntiquity>false</IsAntiquity><InstrumentGroup>WOODWINDS</InstrumentGroup><InstrumentValue>2000</InstrumentValue></Flute>";
            using (MemoryStream stream = new MemoryStream(new UTF8Encoding().GetBytes(xmlFluteData)))
            {
                using (new XmlTextWriter(stream, new UTF8Encoding(false)))
                {
                    Flute fl = (Flute)new XmlSerializer(typeof(Flute)).Deserialize(stream);
                    Assert.Equal<int>(fl.CompareTo(new Flute() { InstrumentName = "The flute of the golden king", InstrumentValue = 2000 }), 0);
                }
            }
        }



        //[Fact(DisplayName = "Test JSON Serialization using DataContractJsonSerializer on Musician")]
        //public void JsonSerialization()
        //{
        //    var serializer = new DataContractJsonSerializer(Diego.GetType(),new List<System.Type>() {typeof(Piano),typeof(Guitar),typeof(Flute)});
        //    using (var ms = new MemoryStream())
        //    {
        //        serializer.WriteObject(ms, Diego);
        //        string JSON = Encoding.Default.GetString(ms.ToArray());


        //        using (var ms1 = new MemoryStream(Encoding.Unicode.GetBytes(JSON)))
        //        {
        //            var deserializer = new DataContractJsonSerializer(Diego.GetType(), new List<System.Type>() { typeof(Piano), typeof(Guitar), typeof(Flute) });
        //            Musician diego1 = (Musician)deserializer.ReadObject(ms);
        //        }


        //    }
        //}


        //[Fact(DisplayName = "Test the conversion to json")]
        //public void ConvertToJsonProperly()
        //{
        //    Musician diego = new Musician()
        //    {
        //        Name = "Diego",
        //        Surname = "Burlando",
        //        Email = "diego@dmm888.com",
        //        Location = "Genoa",
        //        Age = 55,
        //        Nationality = "Italian",
        //        Gender = Genders.MALE,
        //        Instruments = new List<IInstrument> {
        //            new Guitar()
        //            {
        //                GuitarBrand = GuitarBrands.RAMIREZ,
        //                GuitarType = GuitarTypes.CLASSIC,
        //                InstrumentGroup = InstrumentGroups.STRINGS,
        //                InstrumentName = "Guitar",
        //                InstrumentValue = 15230.55M,
        //                IsAntiquity = false
        //            },
        //            new Flute()
        //            {
        //                FluteBrand = FluteBrands.MURAMATSU,
        //                FluteType = FluteTypes.CLASSIC,
        //                InstrumentGroup = InstrumentGroups.STRINGS,
        //                InstrumentName = "Flute",
        //                InstrumentValue = 23450M,
        //                IsAntiquity = false
        //            },
        //            new Piano()
        //            {
        //                PianoBrand = PianoBrands.BOSENDORFEN,
        //                PianoType = PianoTypes.GRAND,
        //                InstrumentGroup = InstrumentGroups.STRINGS,
        //                InstrumentName = "Piano",
        //                InstrumentValue = 103324M,
        //                IsAntiquity = true
        //            }
        //        },
        //        Proficiency = "Advanced",
        //        YearsOfStudy = 27,
        //        MusicStyle = MusicStyles.CLASSIC

        //    };

        //    string diegoJson = JsonHelper.ConvertToJson(diego);
        //    Musician diegoFromJson = (Musician)JsonHelper.ConvertToObjectFromJson(diegoJson);   


        //}





    }
}
