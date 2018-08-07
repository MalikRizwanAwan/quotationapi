using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.Model;
namespace BAL.ICustomerOrder
{
    public interface ICustomerOrder
    {
        int CustomerOrder(OrderInfo orderInfo);
    }
}
