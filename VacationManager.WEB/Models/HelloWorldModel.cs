using DelegateDecompiler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace VacationManager.WEB.Models
{
    public class HelloWorldModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Computed]
        [ScriptIgnore]
        [JsonIgnore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}