using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest.xLocate
{
   
        public class XlocateModelRequest
        {
            public Addr addr { get; set; }
            public Option[] options { get; set; }
            public object[] sorting { get; set; }
            public object[] additionalFields { get; set; }
            public Callercontext callerContext { get; set; }
        }

        public class Addr
        {
            public string country { get; set; }
            public string state { get; set; }
            public string postCode { get; set; }
            public string city { get; set; }
            public string city2 { get; set; }
            public string street { get; set; }
            public string houseNumber { get; set; }
        }

        public class Callercontext
        {
            public Property1[] properties { get; set; }
        }

        public class Property1
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class Option
        {
            [JsonProperty(PropertyName = "$type")]
        public string type { get; set; }
            public string param { get; set; }
            public string value { get; set; }
        }

    

}
