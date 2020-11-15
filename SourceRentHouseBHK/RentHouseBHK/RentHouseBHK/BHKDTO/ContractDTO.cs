using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDTO
{
    class ContractDTO
    {
        public long IDCustomer { get; set; }
        public long IDHouse { get; set; }
        public long IDEmployee { get; set; }
        public DateTime ContractDate { get; set; }
        public string Status { get; set; }
    }
}
