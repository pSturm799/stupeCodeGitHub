/*
 * GPM Rest services
 *
 * GPM Rest services
 *
 * OpenAPI spec version: 0.1
 * Contact: herndlbauer@lkw-walter.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class Firma : IEquatable<Firma>
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version")]
        public long? Version { get; set; }

        /// <summary>
        ///     Gets or Sets Uname1
        /// </summary>
        [DataMember(Name = "uname1")]
        public string Uname1 { get; set; }

        /// <summary>
        ///     Gets or Sets Uname1Freigabestatus
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum Uname1FreigabestatusEnum
        {
            /// <summary>
            ///     Enum NeuEnum for neu
            /// </summary>
            [EnumMember(Value = "neu")] NeuEnum = 0,

            /// <summary>
            ///     Enum FreigegebenEnum for freigegeben
            /// </summary>
            [EnumMember(Value = "freigegeben")] FreigegebenEnum = 1,

            /// <summary>
            ///     Enum GeaendertEnum for geaendert
            /// </summary>
            [EnumMember(Value = "geaendert")] GeaendertEnum = 2,

            /// <summary>
            ///     Enum GeloeschtEnum for geloescht
            /// </summary>
            [EnumMember(Value = "geloescht")] GeloeschtEnum = 3
        }

        /// <summary>
        ///     Gets or Sets Uname1Freigabestatus
        /// </summary>
        [DataMember(Name = "uname1Freigabestatus")]
        public Uname1FreigabestatusEnum? Uname1Freigabestatus { get; set; }

        /// <summary>
        ///     Gets or Sets Uname2
        /// </summary>
        [DataMember(Name = "uname2")]
        public string Uname2 { get; set; }

        /// <summary>
        ///     Gets or Sets Uname2Freigabestatus
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum Uname2FreigabestatusEnum
        {
            /// <summary>
            ///     Enum NeuEnum for neu
            /// </summary>
            [EnumMember(Value = "neu")] NeuEnum = 0,

            /// <summary>
            ///     Enum FreigegebenEnum for freigegeben
            /// </summary>
            [EnumMember(Value = "freigegeben")] FreigegebenEnum = 1,

            /// <summary>
            ///     Enum GeaendertEnum for geaendert
            /// </summary>
            [EnumMember(Value = "geaendert")] GeaendertEnum = 2,

            /// <summary>
            ///     Enum GeloeschtEnum for geloescht
            /// </summary>
            [EnumMember(Value = "geloescht")] GeloeschtEnum = 3
        }

        /// <summary>
        ///     Gets or Sets Uname2Freigabestatus
        /// </summary>
        [DataMember(Name = "uname2Freigabestatus")]
        public Uname2FreigabestatusEnum? Uname2Freigabestatus { get; set; }

        /// <summary>
        ///     siehe LKWGEN.SPR.ASSPRC
        /// </summary>
        /// <value>siehe LKWGEN.SPR.ASSPRC</value>
        [DataMember(Name = "sprache")]
        public string Sprache { get; set; }

        /// <summary>
        ///     siehe LKWGEN.WHG.BTWHRC
        /// </summary>
        /// <value>siehe LKWGEN.WHG.BTWHRC</value>
        [DataMember(Name = "waehrung")]
        public string Waehrung { get; set; }

        /// <summary>
        ///     Gets or Sets Unternehmensstatus
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum UnternehmensstatusEnum
        {
            /// <summary>
            ///     Enum InErstfreigabeEnum for inErstfreigabe
            /// </summary>
            [EnumMember(Value = "inErstfreigabe")] InErstfreigabeEnum = 0,

            /// <summary>
            ///     Enum FreigegebenEnum for freigegeben
            /// </summary>
            [EnumMember(Value = "freigegeben")] FreigegebenEnum = 1,

            /// <summary>
            ///     Enum InaktivEnum for inaktiv
            /// </summary>
            [EnumMember(Value = "inaktiv")] InaktivEnum = 2
        }

        /// <summary>
        ///     Gets or Sets Unternehmensstatus
        /// </summary>
        [DataMember(Name = "unternehmensstatus")]
        public UnternehmensstatusEnum? Unternehmensstatus { get; set; }

        /// <summary>
        ///     Gets or Sets Suchbegriff
        /// </summary>
        [DataMember(Name = "suchbegriff")]
        public string Suchbegriff { get; set; }


        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Firma {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Uname1: ").Append(Uname1).Append("\n");
            sb.Append("  Uname1Freigabestatus: ").Append(Uname1Freigabestatus).Append("\n");
            sb.Append("  Uname2: ").Append(Uname2).Append("\n");
            sb.Append("  Uname2Freigabestatus: ").Append(Uname2Freigabestatus).Append("\n");
            sb.Append("  Sprache: ").Append(Sprache).Append("\n");
            sb.Append("  Waehrung: ").Append(Waehrung).Append("\n");
            sb.Append("  Unternehmensstatus: ").Append(Unternehmensstatus).Append("\n");
            sb.Append("  Suchbegriff: ").Append(Suchbegriff).Append("\n");

            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Firma) obj);
        }

        /// <summary>
        ///     Returns true if Firma instances are equal
        /// </summary>
        /// <param name="other">Instance of Firma to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Firma other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Version == other.Version ||
                    Version != null &&
                    Version.Equals(other.Version)
                ) &&
                (
                    Uname1 == other.Uname1 ||
                    Uname1 != null &&
                    Uname1.Equals(other.Uname1)
                ) &&
                (
                    Uname1Freigabestatus == other.Uname1Freigabestatus ||
                    Uname1Freigabestatus != null &&
                    Uname1Freigabestatus.Equals(other.Uname1Freigabestatus)
                ) &&
                (
                    Uname2 == other.Uname2 ||
                    Uname2 != null &&
                    Uname2.Equals(other.Uname2)
                ) &&
                (
                    Uname2Freigabestatus == other.Uname2Freigabestatus ||
                    Uname2Freigabestatus != null &&
                    Uname2Freigabestatus.Equals(other.Uname2Freigabestatus)
                ) &&
                (
                    Sprache == other.Sprache ||
                    Sprache != null &&
                    Sprache.Equals(other.Sprache)
                ) &&
                (
                    Waehrung == other.Waehrung ||
                    Waehrung != null &&
                    Waehrung.Equals(other.Waehrung)
                ) &&
                (
                    Unternehmensstatus == other.Unternehmensstatus ||
                    Unternehmensstatus != null &&
                    Unternehmensstatus.Equals(other.Unternehmensstatus)
                ) &&
                (
                    Suchbegriff == other.Suchbegriff ||
                    Suchbegriff != null &&
                    Suchbegriff.Equals(other.Suchbegriff)
                );
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                {
                    hashCode = hashCode * 59 + Id.GetHashCode();
                }

                if (Version != null)
                {
                    hashCode = hashCode * 59 + Version.GetHashCode();
                }

                if (Uname1 != null)
                {
                    hashCode = hashCode * 59 + Uname1.GetHashCode();
                }

                if (Uname1Freigabestatus != null)
                {
                    hashCode = hashCode * 59 + Uname1Freigabestatus.GetHashCode();
                }

                if (Uname2 != null)
                {
                    hashCode = hashCode * 59 + Uname2.GetHashCode();
                }

                if (Uname2Freigabestatus != null)
                {
                    hashCode = hashCode * 59 + Uname2Freigabestatus.GetHashCode();
                }

                if (Sprache != null)
                {
                    hashCode = hashCode * 59 + Sprache.GetHashCode();
                }

                if (Waehrung != null)
                {
                    hashCode = hashCode * 59 + Waehrung.GetHashCode();
                }

                if (Unternehmensstatus != null)
                {
                    hashCode = hashCode * 59 + Unternehmensstatus.GetHashCode();
                }

                if (Suchbegriff != null)
                {
                    hashCode = hashCode * 59 + Suchbegriff.GetHashCode();
                }

                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(Firma left, Firma right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Firma left, Firma right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}