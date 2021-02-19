using System;
using System.Data;
using DAL;

namespace BAL
{
    public class BankBAL
    {
       
            public DataSet ReadDetails()
            {
                DataSet set = new DataSet();
               BankDAL bankDAL = new BankDAL();
                var data = bankDAL.GetListOfBanks();
                set.Tables.Add(data);
                return set;

            }
        }
    }

