

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Template.Models;
using Template.Templates;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace Template.Controllers
{
    public class MessageController : Controller
    {
      

        [HttpGet]
        public async Task<IActionResult> Get([FromBody]MessageModel md)
		{
			try
			{
					SqlParameter[] param = { 
                        new SqlParameter("@TokenNo", md.TokenNo)
                    };
					//string Response = await ApiCall.ApiCallWithObject("Message/Get", TokenNo, "Get");
					return StatusCode(StatusCodes.Status200OK, Response);
				
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}

        [HttpGet]
        public async Task<IActionResult> GetByID([FromBody]MessageModel md)
		{
			try
			{
					SqlParameter[] param = { 
                        new SqlParameter("@TokenNo", md.TokenNo),
						new SqlParameter("@GUID", md.GUID)
                    };
					//string Response = await ApiCall.ApiCallWithObject("Message/GetByID?id=" + id, TokenNo, "Get");
					return StatusCode(StatusCodes.Status200OK, Response);
				
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}

		


        [HttpPost]
        public async Task<IActionResult> InsertUpdate([FromBody]MessageModel md )
        {
            try{
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                
                     SqlParameter[] parm2 = { 
					     						 new SqlParameter("@MessageId", md.MessageId),
												 new SqlParameter("@Sender", md.Sender),
												 new SqlParameter("@Receiver", md.Receiver),
												 new SqlParameter("@Message", md.Message),
												 new SqlParameter("@GUID", md.GUID),
						                       
                    };
                    //string Response = await ApiCall.ApiCallWithObject("Message/Create", md, "Post");
                    return StatusCode(StatusCodes.Status200OK,Response);
                
            }
             catch (Exception ex)
            {
                string Exception = ex.ToString();
                return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
            }
		}

        [HttpDelete]
		public async Task<IActionResult> Delete([FromBody]MessageModel md)
		{
			try
			{
					SqlParameter[] param = { 
                        new SqlParameter("@TokenNo", md.TokenNo),
						new SqlParameter("@GUID", md.GUID)
                    };
					//string Response = await ApiCall.ApiCallWithObject("Message/Delete?id=" + id, TokenNo, "Delete");
					return StatusCode(StatusCodes.Status200OK, Response);
				
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}
		
    }
}