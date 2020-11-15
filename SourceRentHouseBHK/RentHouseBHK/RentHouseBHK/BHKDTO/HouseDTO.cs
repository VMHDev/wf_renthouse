using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDTO
{
    class HouseDTO
    {
        public long ID { get; set; }
        public int RoomNumber { get; set; }
        public long FeeMonth { get; set; }
        public long IDHouseholder { get; set; }
        public long IDEmployee { get; set; }
        public long IDHouseType { get; set; }
        public long IDLocation { get; set; }
        public bool IsActive { get; set; }
    }
}
