

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Template.Models;
using Template.Templates;
using System;
using System.Collections.Generic;


namespace Template.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
		{
			try
			{
				string TokenNo = HttpContext.Session.GetString("TokenNo");
				if (TokenNo == null)
				{
					return StatusCode(StatusCodes.Status504GatewayTimeout);
				}
				else
				{
					//string Response = await ApiCall.ApiCallWithObject("Users/Get", TokenNo, "Get");
					return StatusCode(StatusCodes.Status200OK, Response);
				}
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}

        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
		{
			try
			{
				string TokenNo = HttpContext.Session.GetString("TokenNo");
				if (TokenNo == null)
				{
					return StatusCode(StatusCodes.Status504GatewayTimeout);
				}
				else
				{
					//string Response = await ApiCall.ApiCallWithObject("Users/GetByID?id=" + id, TokenNo, "Get");
					return StatusCode(StatusCodes.Status200OK, Response);
				}
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody]UsersModel md)
		{
			try{
			   string TokenNo = HttpContext.Session.GetString("TokenNo");
			   if (TokenNo == null)
			   {
			       return StatusCode(StatusCodes.Status504GatewayTimeout);
				}
				else
				{
				    md.TokenNo = TokenNo;
					//string Response = await ApiCall.ApiCallWithObject("Users/Update", md, "Put");
					return StatusCode(StatusCodes.Status200OK, Response);
				}
			}
			catch (Exception ex)
			{
			    string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}



        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UsersModel md )
        {
            try{
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return StatusCode(StatusCodes.Status504GatewayTimeout);
                }
                else
                {
                    md.TokenNo = TokenNo;
                    //string Response = await ApiCall.ApiCallWithObject("Users/Create", md, "Post");
                    return StatusCode(StatusCodes.Status200OK,Response);
                }
            }
             catch (Exception ex)
            {
                string Exception = ex.ToString();
                return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
            }
		}

        [HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				string TokenNo = HttpContext.Session.GetString("TokenNo");
				if (TokenNo == null)
				{
					return StatusCode(StatusCodes.Status504GatewayTimeout);
				}
				else
				{
					//string Response = await ApiCall.ApiCallWithObject("Users/Delete?id=" + id, TokenNo, "Delete");
					return StatusCode(StatusCodes.Status200OK, Response);
				}
			}
			catch (Exception ex)
			{
				string Exception = ex.ToString();
				return StatusCode(StatusCodes.Status417ExpectationFailed,Exception);
			}
		}
		
    }
}