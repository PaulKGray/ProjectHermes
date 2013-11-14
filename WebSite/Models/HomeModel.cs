using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHermes.Models
{
    public class HomeModel
    {

        public IList<ParentItemModel> ParentItems { get; set; }


        public HomeModel()
        {
			ParentItems = new List<ParentItemModel>();
        }
    }
}