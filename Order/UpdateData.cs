using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Order.DataAccessClasses
{
    class UpdateData
    {
        public static void UpdatePrinterIPAddress(string IPID, string IPAddress)
        {
            DataClasses1DataContext DC = new DataClasses1DataContext();

            var IPAddressUpdate = (from c in DC.GetTable<tblPrinterIP>()
                                   where c.IPID == IPID
                                   select c).SingleOrDefault();

            try
            {
                IPAddressUpdate.IPID = IPID;
                IPAddressUpdate.IP_Address = IPAddress;
                DC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
