using System;
using System.Collections.Generic;

public class QueryBuilder
{
    public static Dictionary<string, string> GenerateQueries()
    {
        return new Dictionary<string, string>
        {
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLMICompute],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLManagedInstance]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.MeterName]} eq '{AppSettings.MeterNameDescriptions[AppSettings.MeterName.vCore]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLMILicense],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLManagedInstance]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.MeterName]} eq '{AppSettings.MeterNameDescriptions[AppSettings.MeterName.vCore]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.Global]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLDBCompute],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLDatabase]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.MeterName]} eq '{AppSettings.MeterNameDescriptions[AppSettings.MeterName.vCore]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLDBLicense],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLDatabase]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.MeterName]} eq '{AppSettings.MeterNameDescriptions[AppSettings.MeterName.vCore]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.Global]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLVMCompute],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceFamily]} eq '{AppSettings.ServiceFamilyDescriptions[AppSettings.ServiceFamily.Compute]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLVMStorage],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceFamily]} eq '{AppSettings.ServiceFamilyDescriptions[AppSettings.ServiceFamily.Storage]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLMIStorage],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLManagedInstance]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.UnitOfMeasure]} eq '{AppSettings.UnitOfMeasureDescriptions[AppSettings.UnitOfMeasure.OneGBMonth]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.SQLDBStorage],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.SQLDatabase]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.WestUS]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.UnitOfMeasure]} eq '{AppSettings.UnitOfMeasureDescriptions[AppSettings.UnitOfMeasure.OneGBMonth]}'"
            },
            {
                AppSettings.UploadFileNames[AppSettings.UploadFiles.AzureHybridBenefit],
                $"$filter={AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ServiceName]} eq '{AppSettings.ServiceNameDescriptions[AppSettings.ServiceName.VirtualMachinesLicenses]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ArmRegionName]} eq '{AppSettings.LocationDescriptions[AppSettings.Location.Global]}' " +
                $"and {AppSettings.QueryKeyDescriptions[AppSettings.QueryKey.ProductName]} eq '{AppSettings.ProductNameDescriptions[AppSettings.ProductName.AzureHybridBenefit]}'"
            }
        };
    }
}
