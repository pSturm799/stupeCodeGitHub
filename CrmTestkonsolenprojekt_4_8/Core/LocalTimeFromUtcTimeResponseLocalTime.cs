using System;
using Microsoft.Crm.Sdk.Messages;

namespace CrmTestkonsolenprojekt_4_8.Core
{
    /// <summary>
    ///     Class to return UtcTime from <see cref="LocalTimeFromUtcTimeResponse" />
    /// </summary>
    public class LocalTimeFromUtcTimeResponseLocalTime : ILocalTimeFromUtcTimeResponseLocalTime
    {
        private readonly IExecuteOrganizationRequestExtended _localTimeFromUtcTimeResponse;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="localTimeFromUtcTimeResponse"></param>
        public LocalTimeFromUtcTimeResponseLocalTime(IExecuteOrganizationRequestExtended localTimeFromUtcTimeResponse)
        {
            _localTimeFromUtcTimeResponse = localTimeFromUtcTimeResponse ?? throw new ArgumentNullException(nameof(localTimeFromUtcTimeResponse));
        }

        /// <inheritdoc />
        public DateTime Value => ((LocalTimeFromUtcTimeResponse)_localTimeFromUtcTimeResponse.Value).LocalTime;
    }
}