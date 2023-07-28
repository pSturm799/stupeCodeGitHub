using Cosmo.Core;
using Microsoft.Xrm.Sdk;

namespace CrmTestkonsolenprojekt_4_8.Core
{
    /// <summary>
    ///     Interface for classes that execute an OrganizationRequest
    /// </summary>
    public interface IExecuteOrganizationRequestExtended : IRun, IValue<OrganizationResponse>
    {
    }
}