using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Model
{
   public  class OrderInfo
    {
        public int ITM_COD { get; set; }
        public int SRL_NUM { get; set; }
        public int CRD_COD { get; set; }    
        public string UOM_ABR { get; set; }
        public int QTD_RTE { get; set; }
        public int QTY_PRC { get; set; }
        public int QTN_NUM { get; set; }
        public int PMT_FLG { get; set; }



    }

    public class getemail
    {
        public int email { get; set; }
    }

  

}
