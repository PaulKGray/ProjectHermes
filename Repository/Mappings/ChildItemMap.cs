using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Domain;
using FluentNHibernate.Mapping;

namespace ProjectHermes.Repository.Mappings
{
    class ChildItemMap : ClassMap<ChildItem>
    {
        public ChildItemMap()
        {
                Table("ChildItem");
                Id(x => x.ChildItemId);
                Map(x => x.Name);
                References(x=>x.Parent);
        }
    }
}
