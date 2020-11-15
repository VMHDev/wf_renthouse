using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDTO
{
    class EmployeeDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public long IDBranchOffice { get; set; }
        public bool IsActive { get; set; }
    }
}
