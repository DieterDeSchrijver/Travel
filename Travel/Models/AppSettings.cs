using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Models
{
        public class AppSettings : IAppSettings
        {
            public string key { get; set; }
        }

        public interface IAppSettings
        {
            string key { get; set; }
        }

}
