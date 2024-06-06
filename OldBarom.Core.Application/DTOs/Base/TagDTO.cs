using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.DTOs.Base
{
    public class TagDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
