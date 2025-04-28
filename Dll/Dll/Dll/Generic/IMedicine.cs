using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;

namespace Dll.Generic
{
    public interface IMedicine
    {
        bool addMedicine(Medicine medicine);
        void delMedicine(Medicine medicine);
        void updateMedicine(Medicine medicine);
        Medicine searchMedicine(string name);
        List<Medicine> getExpireMedicine();
        List<Medicine> getMedicineList();
        void returnMedicine(Medicine medicine);
    }
}
