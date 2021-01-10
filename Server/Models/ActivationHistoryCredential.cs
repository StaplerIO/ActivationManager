using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ActivationHistoryCredential: ActivateViewModel
    {
        public long Id { get; set; }

        public DateTime ActivateTime { get; set; }

        public static ActivationHistoryCredential FromActivateViewModel(ActivateViewModel model)
        {
            return new ActivationHistoryCredential
            {
                ActivateTime = DateTime.Now,
                MACAddress = model.MACAddress,
                MachineIdentifier = model.MachineIdentifier,
                SerialNumber = model.SerialNumber
            };
        }
    }
}
