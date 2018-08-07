using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net;


using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;



using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

using System.Web.Mvc;
namespace CustomerOrder.database_access_layer
{
  
    public class CustomerGet
    {
        
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public DataSet gcustomerrecord(int customerCode)
        {         
            var sql = "Select Initcap(Pur_Nom)Pur_Nom,P13.Crd_Cod,P13.Itm_Cod,P13.srl_num,Itm_Des,Uom_Abr,Qtd_Rte,Qtn_Num,Qty_Prc,Pmt_Flg From Nml.Pgi_00_13 P13, Nml.Crp_00_27 C27 Where P13.Vld_Dte Is Not Null And C27.Pur_Cod = P13.Pur_Cod And P13.Crd_Cod ='" + customerCode + "' Order By P13.Crd_Cod,P13.Itm_Cod";
            Oracle.DataAccess.Client.OracleCommand com = new Oracle.DataAccess.Client.OracleCommand(sql, con);
            com.CommandType = CommandType.Text;
            var da = new Oracle.DataAccess.Client.OracleDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet GetPopUpRecord(int user)
        {   
            //var sql = "select NVL(PUR_COD,-1) PUR_COD,NVL(SRL_NUM,-1)SRL_NUM,NVL(SRL_NUM,-1)SPR_NUM,NVL(CRD_COD,-1)CRD_COD,NVL(BAS_COD,-1)BAS_COD,NVL(ITM_COD,-1)ITM_COD,NVL(QTD_RTE,-1)QTD_RTE,NVL(QTN_NUM,-1)QTN_NUM,NVL(QTY_PRC,-1) QTY_PRC,NVL(ITM_DES,' ')ITM_DES,NVL(PMT_FLG,-1)PMT_FLG from pgi_00_13" + " where PUR_COD= '" + user + "'";

            var sql = "select NVL(UOM_ABR,-1)UOM_ABR,ITM_COD,ITM_DES,CRD_COD,NVL(QTD_RTE,-1)QTD_RTE,NVL(QTN_NUM,-1)QTN_NUM,NVL(QTY_PRC,-1) QTY_PRC,NVL(PMT_FLG,-1)PMT_FLG from pgi_00_13" + " where ITM_COD= '" + user + "'";            
            Oracle.DataAccess.Client.OracleCommand com = new Oracle.DataAccess.Client.OracleCommand(sql, con);
            com.CommandType = CommandType.Text;
            var da = new Oracle.DataAccess.Client.OracleDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}

//var sql = "select NVL(PUR_COD,-1) PUR_COD,NVL(SRL_NUM,-1)SRL_NUM,NVL(SRL_NUM,-1)SPR_NUM,NVL(CRD_COD,-1)CRD_COD,NVL(BAS_COD,-1)BAS_COD,NVL(ITM_COD,-1)ITM_COD,NVL(QTD_RTE,-1)QTD_RTE,NVL(QTN_NUM,-1)QTN_NUM,NVL(QTY_PRC,-1) QTY_PRC,NVL(ITM_DES,' ')ITM_DES,NVL(PMT_FLG,-1)PMT_FLG from pgi_00_13" + " where PUR_COD= '" + user + "'";
//var sql = "select NVL(PUR_COD,-1) PUR_COD,NVL(ITM_COD,-1)ITM_COD,NVL(UOM_ABR,-1)UOM_ABR,NVL(QTD_RTE,-1)QTD_RTE,NVL(QTN_NUM,-1)QTN_NUM,NVL(QTY_PRC,-1) QTY_PRC,NVL(ITM_DES,' ')ITM_DES,NVL(PMT_FLG,-1)PMT_FLG from pgi_00_13" + " where PUR_COD= '" + user + "'";

//var sql = "select NVL(PUR_COD,-1)PUR_COD, NVL(ITM_COD,-1)ITM_COD, NVL(ITM_DES,' ')ITM_DES,NVL(UOM_ABR,-1)UOM_ABR,NVL(QTD_RTE,-1)QTD_RTE,NVL(QTN_NUM,-1)QTN_NUM,NVL(QTY_PRC,-1) QTY_PRC,NVL(PMT_FLG,-1)PMT_FLG from pgi_00_13";