using System;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.Models
{
    public class Tourist : IBaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public uint Tokens { get; set; }
        public uint Timeout { get; set; }

        public Tourist() { }
    }
}
