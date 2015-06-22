using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HB8.CSMS.BLL.Abstract;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using HB8.CSMS.MVC.Models.Staff;

namespace HB8.CSMS.MVC.Controllers
{
    public class LogInController : Controller
    {
        #region Khai bao
        private IStaffManagerService staffService;
        public LogInController(IStaffManagerService staffService)
        {
            this.staffService = staffService;
        }
        #endregion
        #region Giai ma MD5
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
        #region Log In
        public ActionResult LogIn()
        {
            return View();
        }
        //Kiem tra tai khoan dang nhap
        public JsonResult CheckAccount(string id, string password)
        {
            var data = new StaffModel();
            var account = from c in staffService.GetListStaff() where c.StaffID.CompareTo(id.ToLower()) >= 0 select c;
            if (account != null)
            {
                string passMD5 = account.FirstOrDefault().Password;
                string passDecrypt = Decrypt(passMD5, true);
                if (passDecrypt.Equals(password))
                {
                    data.UserId = account.FirstOrDefault().UserId;
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    data.UserId = "0";
                    return Json(data, JsonRequestBehavior.AllowGet);                  
                }
            }
            else
            {
                data.UserId = null;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion


    }
}
