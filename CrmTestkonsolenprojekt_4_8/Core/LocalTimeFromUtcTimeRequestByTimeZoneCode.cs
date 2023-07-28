using System;
using CRM.Core;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace CrmTestkonsolenprojekt_4_8.Core
{
    /// <summary>
    ///     Class to setup a <see cref="LocalTimeFromUtcTimeRequest" /> by <see cref="IDateTime" /> and
    ///     <see cref="ITimeZoneCode" />
    /// </summary>
    public class LocalTimeFromUtcTimeRequestByTimeZoneCode : IOrganizationRequest
    {
        private readonly ITimeZoneCode _timeZoneCode;
        private readonly IDateTime _utcTime;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="timeZoneCode"></param>
        /// <param name="utcTime"></param>
        public LocalTimeFromUtcTimeRequestByTimeZoneCode(ITimeZoneCode timeZoneCode, IDateTime utcTime)
        {
            _timeZoneCode = timeZoneCode ?? throw new ArgumentNullException(nameof(timeZoneCode));
            _utcTime = utcTime ?? throw new ArgumentNullException(nameof(utcTime));
        }

        /// <inheritdoc />
        public OrganizationRequest Value =>
            new LocalTimeFromUtcTimeRequest
            {
                UtcTime = _utcTime.Value,
                TimeZoneCode = _timeZoneCode.Value
            };
    }
}