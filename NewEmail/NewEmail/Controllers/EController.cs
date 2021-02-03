using Microsoft.AspNetCore.Mvc;
using NewEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace NewEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EController : ControllerBase
    {
        [HttpGet]
        public string Get(string name,int?id)
        {
            List<Emails> emails = SQLcmdEmail.SQLcmdData(name,id);
            String hingeString = Newtonsoft.Json.JsonConvert.SerializeObject(emails);
            return hingeString;
        }
        [HttpPost("Insertpost")]
        public int Insertpost()
        {
            string Name = Request.Form["EmailName"].ToString();
            string CreateTime = DateTime.Now.ToString();
            int EDelete = 1;
            string UpdateTime = "No modification";
            return SQLcmdEmail.SQLinsertData(Name,CreateTime,EDelete, UpdateTime);
        }
        [HttpPost("Updatepost")]
        public int Updatepost()
        {
            int Id = int.Parse(Request.Form["EID"]);
            string Name = Request.Form["EmailName"].ToString();
            string UpdateTime = DateTime.Now.ToString();
            return SQLcmdEmail.SQLUpdateData(Name, Id, UpdateTime);
        }
        [HttpPost("Deletepost")]
        public int Deletepost()
        {
            int ID = int.Parse(Request.Form["EID"]);
            return SQLcmdEmail.SQLDeleteData(ID);
        }
    }

}
