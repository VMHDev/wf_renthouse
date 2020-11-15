using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDTO
{
    class PreviewDTO
    {
        public long MyProperty { get; set; }
        public long IDCustomer { get; set; }
        public long IDHouse { get; set; }
        public DateTime PreviewDate { get; set; }
        public string Comment { get; set; }
    }
}
