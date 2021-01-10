using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared
{
    public class ActivateViewModel
    {
        [Required]
        public string MACAddress { get; set; }

        [Required]
        public string MachineIdentifier { get; set; }

        [Required]
        public string SerialNumber { get; set; }
    }
}
