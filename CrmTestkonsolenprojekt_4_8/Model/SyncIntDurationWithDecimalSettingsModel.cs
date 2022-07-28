using System.Collections.Generic;

namespace CrmTestkonsolenprojekt_4_8.Model
{
    /// <summary>
    ///     Provides the model for json-setting SyncIntDurationWithDecimal
    /// </summary>
    public class SyncIntDurationWithDecimalSettingsModel
    {
        /// <summary>
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// </summary>
        public List<SyncField> SyncFields { get; set; }
    }


    /// <summary>
    /// </summary>
    public class SyncField
    {
        /// <summary>
        /// </summary>
        public string IntFieldName { get; set; }

        /// <summary>
        /// </summary>
        public string DecimalFieldName { get; set; }
    }
}