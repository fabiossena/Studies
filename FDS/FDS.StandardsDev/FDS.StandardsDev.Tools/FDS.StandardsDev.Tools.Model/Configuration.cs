using System;

namespace FDS.StandardsDev.Tools.Model
{
    public class Configuration
    {
        public int ConfigurationId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Setting { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}