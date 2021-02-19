using DAL;
using System;
using System.Data;

namespace BAL
{
    public class EmployeeBAL
    {
        public DataSet ReadEmployees()
        {
            DataSet set= new DataSet();
            EmployeeDAL dal = new EmployeeDAL();
            var empdata=dal.GetEmployees();
            set.Tables.Add(empdata);
            return set;
            
        }
    }
}
