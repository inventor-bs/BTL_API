using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebBanQA.Class;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [EnableCors("*", "*", "*")]
    public class WomenController : ApiController
    {
        CHQADataContext db = new CHQADataContext();
        [HttpGet]
        public List<WomenList> GetWomanLists()
        {
            string women = "ST002";
            List<WomenList> womenLists = (from p in db.Products
                                     join c in db.catalogs.Where(n => n.CA_STID == women) on p.P_CAID equals c.CA_id
                                     select new WomenList
                                     {
                                         _P_id = p.P_id,
                                         _P_name = p.P_name,
                                         _P_discount = p.P_discount,
                                         _P_Price = p.P_Price,
                                         _P_image = p.P_image,
                                         _P_note = p.P_note,
                                         _P_amount = p.P_amount,
                                         _P_content = p.P_content,
                                         _P_CAID = p.P_CAID,
                                         _P_slug = p.P_slug
                                     }
                         ).ToList();
            return womenLists;
        }
    }
}
