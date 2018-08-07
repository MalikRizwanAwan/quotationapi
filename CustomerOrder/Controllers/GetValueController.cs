using MODELS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CustomerOrder.Controllers
{
    public class GetValueController :Controller
    {
        database_access_layer.CustomerGet dblayer = new database_access_layer.CustomerGet();      
        public JsonResult getcustomerrecord(int customerCod)
         {         
            DataSet ds = dblayer.gcustomerrecord(customerCod);
            //this is for getordert tart
            List<gcvalue> lstrng = new List<gcvalue>(10000);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstrng.Add(new gcvalue
                {                 
                    PUR_NOM = Convert.ToString(dr["PUR_NOM"]),
                    Crd_Cod = Convert.ToInt32(dr["CRD_COD"]),                    
                    ITM_COD = Convert.ToInt32(dr["ITM_COD"]),
                    SRL_NUM = Convert.ToInt64(dr["SRL_NUM"]),
                    UOM_ABR = Convert.ToString(dr["UOM_ABR"]),                    
                    ITM_DES = Convert.ToString(dr["ITM_DES"]),
                    QTD_RTE = Convert.ToInt32(dr["QTD_RTE"]),
                    QTY_PRC = Convert.ToInt32(dr["QTY_PRC"]),
                    QTN_NUM = Convert.ToInt32(dr["QTN_NUM"]),                 
                    PMT_FLG = Convert.ToInt32(dr["PMT_FLG"]),                   
                });
            }        
            JsonResult json = Json(lstrng, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;        
        }

        public JsonResult getpopup(int user)
        {
            DataSet ds = dblayer.GetPopUpRecord(user);
            //this is for getordert tart
            List<getCustomerDetail> lstrng = new List<getCustomerDetail>(10000);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstrng.Add(new getCustomerDetail
                { 
                    UOM_ABR = Convert.ToString(dr["UOM_ABR"]),
                    ITM_COD =Convert.ToInt32(dr["ITM_COD"]),
                    ITM_DES = Convert.ToString(dr["ITM_DES"]),
                    CRD_COD=Convert.ToInt32(dr["CRD_COD"]),
                    QTD_RTE = Convert.ToInt32(dr["QTD_RTE"]),
                    QTY_PRC = Convert.ToInt32(dr["QTY_PRC"]),
                    QTN_NUM = Convert.ToInt32(dr["QTN_NUM"]),                  
                    PMT_FLG = Convert.ToInt32(dr["PMT_FLG"]),                
                });

            }
            JsonResult json = Json(lstrng, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;       
       }
    }
}
