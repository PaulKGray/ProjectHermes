using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Repository.Interfaces;
using ProjectHermes.Domain;

namespace ProjectHermes.Services
{
    public class ParentItemService : IParentItemService
    {

        private IRepository<ParentItem> _ParentRepository;


        public ParentItemService(IRepository<ParentItem> repository)
        {
            _ParentRepository = repository;
        }

        public ParentItem CreateParent(ParentItem parent)
        {
            _ParentRepository.Add(parent);

            return parent;
        }

        public ParentItem GetParentItem(int parentItemId)
        {
            var parentItem = _ParentRepository.FindBy(parentItemId);
            return parentItem;
        }

        public void SaveParentItem(ParentItem parentitem)
        {
            _ParentRepository.Update(parentitem);
        }

 				public IList<ParentItem> GetAllParentItem()
				{
					return _ParentRepository.FindAll();
				}


				public void DeleteParentItem(int id)
				{
					var parentItem = _ParentRepository.FindBy(id);
					_ParentRepository.Delete(parentItem);
				}
		}
}