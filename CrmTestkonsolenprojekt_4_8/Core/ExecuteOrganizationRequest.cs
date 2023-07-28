using System;
using CRM.Core;
using Microsoft.Xrm.Sdk;

namespace CrmTestkonsolenprojekt_4_8.Core
{
    /// <summary>
    ///     Class that executes an OrganizationRequest
    /// </summary>
    public class ExecuteOrganizationRequestExtended : IExecuteOrganizationRequestExtended
    {
        private readonly IOrganizationRequest _organizationRequest;
        private readonly IOrganizationService _organizationService;


        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="organizationRequest"></param>
        /// <param name="organizationService"></param>
        public ExecuteOrganizationRequestExtended(IOrganizationRequest organizationRequest, IOrganizationService organizationService)
        {
            _organizationRequest = organizationRequest ?? throw new ArgumentNullException(nameof(organizationRequest));
            _organizationService = organizationService ?? throw new ArgumentNullException(nameof(organizationService));
        }

        /// <inheritdoc />
        public void Run()
        {
            var request = _organizationRequest.Value;
            if (request != null)
            {
                _organizationService.Execute(request);
            }
        }

        /// <inheritdoc />
        public OrganizationResponse Value
        {
            get
            {
                var request = _organizationRequest.Value;
                return request != null ? _organizationService.Execute(request) : null;
            }
        }
    }
}