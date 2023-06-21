using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain
{
    public class Birth
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Species Species { get; set; }
        public Guid SpeciesId { get; set; }
    }
}
