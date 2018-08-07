using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Model
{
    public class gcvalue
    {
        //gc=getcustomer value      
        public int Crd_Cod { get; set; }
        public long SRL_NUM { get; set; }
        public string UOM_ABR { get; set; }       
        public int ITM_COD { get; set; }
        public string ITM_DES { get; set; }
        public int QTD_RTE { get; set; }
        public int QTY_PRC { get; set; }
        public int QTN_NUM { get; set; }
        public string PUR_NOM { get; set; }       
        public int PMT_FLG { get; set; }  

    }
    public class crptable
    {       
        public string PUR_NOM { get; set; }
    }

    public class getCustomerDetail
    {
        
        public string UOM_ABR { get; set; }
        public int ITM_COD { get; set; }
        public string ITM_DES { get; set; }
        public int CRD_COD { get; set; }
        public int QTD_RTE { get; set; }
        public int QTY_PRC { get; set; }
        public long QTN_NUM { get; set; }
        public int PMT_FLG { get; set; } 
      
     }
}
