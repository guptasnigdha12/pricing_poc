using System;
using System.Collections.Generic;

public static class AppSettings
{
    public const string ApiBaseUrl = "https://prices.azure.com/api/retail/prices?";
    public const string ApiVersion = "api-version=2023-01-01-preview";
    public const string ContainerName = "pricing";

    public static readonly Dictionary<ServiceFamily, string> ServiceFamilyDescriptions = new()
    {
        { ServiceFamily.Compute, "Compute" },
        { ServiceFamily.Storage, "Storage" }
    };

    public static readonly Dictionary<ServiceName, string> ServiceNameDescriptions = new()
    {
        { ServiceName.SQLManagedInstance, "SQL Managed Instance" },
        { ServiceName.SQLDatabase, "SQL Database" },
        { ServiceName.VirtualMachinesLicenses, "Virtual Machines Licenses" }
    };

    public static readonly Dictionary<Location, string> LocationDescriptions = new()
    {
        { Location.WestUS, "westus" },
        { Location.Global, "Global" }
    };

    public static readonly Dictionary<UploadFiles, string> UploadFileNames = new()
    {
        { UploadFiles.SQLMICompute, "SQL_MI_Compute.json" },
        { UploadFiles.SQLMILicense, "SQL_MI_License.json" },
        { UploadFiles.SQLDBCompute, "SQL_DB_Compute.json" },
        { UploadFiles.SQLDBLicense, "SQL_DB_License.json" },
        { UploadFiles.SQLVMCompute, "SQL_VM_Compute.json" },
        { UploadFiles.SQLVMStorage, "SQL_VM_Storage.json" },
        { UploadFiles.SQLMIStorage, "SQL_MI_Storage.json" },
        { UploadFiles.SQLDBStorage, "SQL_DB_Storage.json" },
        { UploadFiles.AzureHybridBenefit, "Azure_Hybrid_Benefit.json" }
    };

    public static readonly Dictionary<QueryKey, string> QueryKeyDescriptions = new()
    {
        { QueryKey.ServiceName, "serviceName" },
        { QueryKey.ServiceFamily, "serviceFamily" },
        { QueryKey.MeterName, "meterName" },
        { QueryKey.ArmRegionName, "armRegionName" },
        { QueryKey.UnitOfMeasure, "unitOfMeasure" },
        { QueryKey.ProductName, "productName" }
    };

    public static readonly Dictionary<UnitOfMeasure, string> UnitOfMeasureDescriptions = new()
    {
        { UnitOfMeasure.OneGBMonth, "1 GB/Month" }
    };

    public static readonly Dictionary<MeterName, string> MeterNameDescriptions = new()
    {
        { MeterName.vCore, "vCore" }
    };

    public static readonly Dictionary<ProductName, string> ProductNameDescriptions = new()
    {
        { ProductName.AzureHybridBenefit, "Azure Hybrid Benefit for SQL Server" }
    };

    public enum ServiceFamily { Compute, Storage }
    public enum ServiceName { SQLManagedInstance, SQLDatabase, VirtualMachinesLicenses }
    public enum Location { WestUS, Global }
    public enum UploadFiles { SQLMICompute, SQLMILicense, SQLDBCompute, SQLDBLicense, SQLVMCompute, SQLVMStorage, SQLMIStorage, SQLDBStorage, AzureHybridBenefit }
    public enum QueryKey { ServiceName, ServiceFamily, MeterName, ArmRegionName, UnitOfMeasure, ProductName }
    public enum UnitOfMeasure { OneGBMonth }
    public enum MeterName { vCore }
    public enum ProductName { AzureHybridBenefit }
}
