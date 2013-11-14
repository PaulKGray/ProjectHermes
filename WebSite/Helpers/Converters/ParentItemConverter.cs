using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHermes.Domain;
using ProjectHermes.Models;

namespace ProjectHermes.Helpers.Converters
{
    public class OrganisationConverter
    {
        /// <summary>
        /// Convert a list of parent items to parent item models
        /// </summary>
        /// <param name="Organisations">the list of parent items to convert</param>
        /// <returns>The list of parent item models</returns>
        public IList<OrganisationModel> convertOrganisationDomainObject(IList<Organisation> Organisations) {
            var OrganisationModels = new List<OrganisationModel>();

            foreach (var Organisation in Organisations)
            {
                OrganisationModels.Add(convertOrganisationDomainObject(Organisation));
            }

            return OrganisationModels;
        }

        /// <summary>
        /// Convert a parent item to a patent item model
        /// </summary>
        /// <param name="Organisation">The parent item to convert</param>
        /// <returns>The parent item model</returns>
        public OrganisationModel convertOrganisationDomainObject(Organisation Organisation)
        {

            var OrganisationModel = new OrganisationModel();
            OrganisationModel.Organisationid = Organisation.Organisationid;
            OrganisationModel.Name = Organisation.Name;
            OrganisationModel.Description = Organisation.Description;

            foreach (var childItem in Organisation.ChildItems)
            {

                var newChildItem = new ChildItemModel();
                newChildItem.ChildItemId = childItem.ChildItemId;
                newChildItem.Name = childItem.Name;

                OrganisationModel.ChildItems.Add(newChildItem);

            }

            return OrganisationModel;

        }
    }
}