using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
    public class ConfigurationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Typeid { get; set; }
        public Nullable<int> StatusId { get; set; }
        public int OrganizationId { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public string PurchasedBy { get; set; }
        public string SerialNo { get; set; }
        public string AssetTag { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public string Model { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<System.DateTime> InstallDate { get; set; }
        public string InstalledBy { get; set; }
        public string PhysicalPosition { get; set; }
        public string Hostname { get; set; }
        public string PrimaryIP { get; set; }
        public string MacAddress { get; set; }
        public string DefaultGateway { get; set; }
        public Nullable<int> PlatformId { get; set; }
        public Nullable<int> OperatingSystemId { get; set; }
        public string OperatingSystemNotes { get; set; }
        public string DataSourceType { get; set; }
    }
}
