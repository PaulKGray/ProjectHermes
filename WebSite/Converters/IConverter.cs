using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHermes.Converters
{
    /// <summary>
    /// The basic stucture of a converter
    /// </summary>
    /// <typeparam name="D">The Domain Type</typeparam>
    /// <typeparam name="U">The Model Type</typeparam>
    interface IConverter<D,M>
    {
        D ConvertToDomain(M model);
        M ConvertFromDomain(D domain);

        IList<D> ConvertToDomains(IList<M> models);
        IList<M> ConvertFromDomains(IList<D> domains);

    }
}
