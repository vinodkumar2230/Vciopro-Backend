using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public enum OrganizationHeader
    {
        Name ,
        ShortName, 
        Description, 

    }


    public enum AssetImportHeader
    {
        ComputerID,
        ClientName,
        AgentName,
        AgentType,
        AgentManufacturer,
        AgentMainboard,
        AgentSerialNumber,
        AgentAssetTag,
        AgentLastContactDate,
        AgentOperatingSystem,
        AgentUptime,
        AgentUser,
        AgentAssetDate,
        AgentStatus,
        Hidden_ComputerID,
        Hidden_LocationID,
        Hidden_ClientID
    }
    public enum ContactCSVHeader
    {   id,
        organization,
        important,
        first_name,
        last_name,
        contact_type,
        title,
        location,
        primary_email,
        primary_phone,
        notes,
        additional_contact_items

    }
    /// <summary>
    /// id	organization	Manufacturer	Name	Version	Licence Type	Service Tag or Serial Number
/// 	Hardware Make & Model
/// 	Seats	Authorization Number	Licensing Number	Tracking ID,
/// 	License/Product Key(s),	Purchase Date,	Renewal Date,	Renewal Cost,	Additional Notes

    /// </summary>
    public enum LicensingCSVHeader
    {
        id,
        organization,
        Manufacturer,
        Name,
        Version,
        Licence_Type,
        Service_Tag_or_Serial_Number,
        Hardware_Make___Model,
        Seats,
        Authorization_Number,
        Licensing_Number,
        Tracking_ID,
        License_Product_Keys,
        Purchase_Date,
        Renewal_Date,
        Renewal_Cost,
        Additional_Notes

    }
    /// <summary>
    ///														

    /// </summary>
    public enum ConfigurationCSVHeader
    {
        id,
        organization,
        name,
        configuration_type,
        configuration_status,
        hostname,
        primary_ip,
        default_gateway,
        mac_address,
        serial_number,
        asset_tag,
        manufacturer,
        model,
        operating_system,
        operating_system_notes,
        position,
        notes,
        installed_at,
        installed_by,
        purchased_at,
        purchased_by,
        warranty_expires_at,
        contact,
        location,
        configuration_interfaces
    }
    public enum VendorImportHeader
    {
        id,
        organization,
        VendorName,
        PrimaryContact,
        AccountNumber,
        PhoneNumber,
        EmailAddress,
        Notes
    }
    public enum DataSourceType
    {
        CSV ,
        ConnectWise,
        LabTech,
        AutoTask

    }

    public enum RecordType
    {
        domain,
        nameserver,
        registrar
    };

    public enum UserType
    { 
        Admin=1,
        Client=2,
        Owner=3,
        Manager=4,
        Approver=5,
        Reviewer=6,
        SuperAdmin=10
    
    };

    public enum VcioReportStatus
    {
        Newreport=0,
        Changed=1,
        Locked=2,        
        ClientAccepted=10

    }

    public enum ActivityType
    { 
        Create = 1,
        Update = 2,
        Delete = 3,
        BulkImport =4, 
        Sent = 5,
        Print = 6,
        Feeedback = 7,
        Approval = 8,
        StatusUpdate = 9,

    }
  

}
