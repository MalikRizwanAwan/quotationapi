using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IManager;
using BAL.Manager;
using MODELS.Model;

namespace BAL.IManager
{
    public interface ICustomerOrder
    {
        string GetCustomerOrder(List<OrderInfo> orderInfo);
       string UpdateCustomereRecord(List<OrderInfo> orderInfo);
        string GetEmployeeProfile(int abc);
 
    }



}
