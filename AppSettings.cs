public static class AppSettings
{
    public const string ApiBaseUrl = "https://prices.azure.com/api/retail/prices";        
    public const string ContainerName = "pricing"; // The Blob Container Name
    public static readonly List<(string Name, string Query)> Skus = new()
    {
        ("SQL_Managed_Instance_Compute", "$filter=serviceName eq 'SQL Managed Instance' and meterName eq 'vCore' and armRegionName eq 'westus'"),
        ("SQL_Managed_Instance_License", "$filter=serviceName eq 'SQL Managed Instance' and meterName eq 'vCore' and armRegionName eq 'Global'"),
        ("Azure_SQL_DB_Compute", "$filter=serviceName eq 'SQL Database' and meterName eq 'vCore' and armRegionName eq 'westus'"),
        ("Azure_SQL_DB_License", "$filter=serviceName eq 'SQL Database' and meterName eq 'vCore' and armRegionName eq 'Global'"),
        ("SQL_VM_Compute", "$filter=serviceFamily eq 'Compute' and armRegionName eq 'westus'"),
        ("SQL_VM_Storage", "$filter=serviceFamily eq 'Storage' and armRegionName eq 'westus'"),
        ("SQL_MI_Storage", "$filter=serviceName eq 'SQL Managed Instance' and armRegionName eq 'westus' and unitOfMeasure eq '1 GB/Month'"),
        ("SQL_DB_Storage", "$filter=serviceName eq 'SQL Database' and armRegionName eq 'westus' and unitOfMeasure eq '1 GB/Month'"),
        ("Azure_Hybrid_Benefit", "$filter=serviceName eq 'Virtual Machines Licenses' and armRegionName eq 'Global' and productName eq 'Azure Hybrid Benefit for SQL Server'")
    };
}
