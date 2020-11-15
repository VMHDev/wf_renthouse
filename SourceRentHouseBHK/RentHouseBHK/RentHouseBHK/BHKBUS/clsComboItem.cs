using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouseBHK.BHKBUS
{
    class clsComboItem
    {
        public object Value { get; set; }
        public string Display { get; set; }

        public clsComboItem()
        {

        }

        public clsComboItem(object _Value, string _Display)
        {
            this.Value = _Value;
            this.Display = _Display;
        }

        public override string ToString()
        {
            return Display;
        }

        public static clsComboItem GetItemCombo(object _Value, ComboBox _Combobox)
        {
            foreach (var item in _Combobox.Items)
            {
                clsComboItem itemCombo = item as clsComboItem;
                if(_Value.Equals(itemCombo.Value))
                {
                    return itemCombo;
                }
            }
            return null;
        }
    }
}
