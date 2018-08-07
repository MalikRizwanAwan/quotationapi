using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IManager;
using log4net;
using System.Reflection;
using MODELS.Model;
using System.Data.SqlClient;
using System.Data;
using BAL.Common;
using DAL;
using Oracle.DataAccess.Client;

namespace BAL.Manager
{
    public class CustomerOrderManager:ICustomerOrder
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public string GetCustomerOrder(List<OrderInfo> user)
        {
            int result=0;

            try
            {            

                for (int i = 0; i < user.Count; i++)
                {

                    var sParameter = new List<OracleParameter>();
                    sParameter.Add(new OracleParameter { ParameterName = "@CRD_COD", Value = user[i].CRD_COD });
                    sParameter.Add(new OracleParameter { ParameterName = "@ITM_COD", Value = user[i].ITM_COD });
                    sParameter.Add(new OracleParameter { ParameterName = "@SRL_NUM", Value = user[i].SRL_NUM });
                    sParameter.Add(new OracleParameter { ParameterName = "@UOM_ABR", Value = user[i].UOM_ABR });
                    sParameter.Add(new OracleParameter { ParameterName = "@QTD_RTE", Value = user[i].QTD_RTE });
                    sParameter.Add(new OracleParameter { ParameterName = "@QTY_PRC", Value = user[i].QTY_PRC });
                    sParameter.Add(new OracleParameter { ParameterName = "@QTN_NUM", Value = user[i].QTN_NUM });
                    sParameter.Add(new OracleParameter { ParameterName = "@PMT_FLG", Value = user[i].PMT_FLG });
                    




                  result = Convert.ToInt32(ADOManager.Instance.ExecuteNonQuery("NML.AddProductProcedure", CommandType.StoredProcedure, sParameter));
                }
                return result > 0 ? DataValidation.success : DataValidation.dbError;




            }
            catch (Exception ex)
            {
                Log.Error("Method in context SaveCustomer(): " + ex.Message);
            }
            return null;

        }


        public string UpdateCustomereRecord(List<OrderInfo> orderInfo)
        {

            //for (int i = 0; i < orderInfo.Count; i++)
            //{
            //    string name = orderInfo[i].Equals;
            //    string email = person_list[i].Email;
            //    string daysLeft = person_list[i].DaysLeft;
            //}



            try
            {
                var XMLQutotaionUpdate = orderInfo.ToXML("ArrayOfAttachment");
                var sParameter = new List<OracleParameter>();
                //sParameter.Add(new OracleParameter { ParameterName = "@CRD_COD", Value = orderInfo.CRD_COD });
                //sParameter.Add(new OracleParameter { ParameterName = "@ITM_COD", Value = orderInfo.ITM_COD });
                //sParameter.Add(new OracleParameter { ParameterName = "@UOM_ABR", Value = orderInfo.UOM_ABR });
                //sParameter.Add(new OracleParameter { ParameterName = "@QTD_RTE", Value = user.QTD_RTE });
                //sParameter.Add(new OracleParameter { ParameterName = "@QTY_PRC", Value = user.QTY_PRC });
                //sParameter.Add(new OracleParameter { ParameterName = "@QTN_NUM", Value = user.QTN_NUM });
                //sParameter.Add(new OracleParameter { ParameterName = "@PMT_FLG", Value = user.PMT_FLG });
                sParameter.Add(new OracleParameter { ParameterName = "@XMLQuotation", Value = XMLQutotaionUpdate });
                var result = Convert.ToInt32(ADOManager.Instance.ExecuteNonQuery("NML.AddProductProcedure", CommandType.StoredProcedure, sParameter));
                return result > 0 ? DataValidation.success : DataValidation.dbError;
            }
            catch (Exception ex)
            {
                Log.Error("Method in context AddProductProcedure(): " + ex.Message);
                return null;
            }
        }

        public string GetEmployeeProfile(int user )
        {
            var Obj = new getCustomerDetail();

            try
            {
                var sParameter = new List<OracleParameter>();
                sParameter.Add(new OracleParameter { ParameterName = "@brakecylander", Value = user });
                sParameter.Add(new OracleParameter { ParameterName = "@pressureseal", Value =-1  });
                sParameter.Add(new OracleParameter { ParameterName = "@jackseal", Value = -1 });
                sParameter.Add(new OracleParameter { ParameterName = "@scaanerflatbed", Value = -1 });
                var result = Convert.ToInt32(ADOManager.Instance.DataSet("CUSTOMERORDER.CgetorderProcedure", CommandType.StoredProcedure, sParameter));
                return result > 0 ? DataValidation.success : DataValidation.dbError;

                            }
            catch (Exception ex)
            {
                Log.Error("Method in context GetEmployeeProfile(): " + ex.Message);
                return null;
            }
        }
    }
}
