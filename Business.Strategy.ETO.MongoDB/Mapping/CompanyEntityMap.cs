using Business.Strategy.ETO.Domain.Company;
using Business.Strategy.ETO.Domain.Financial;
using Business.Strategy.ETO.Domain.IndustryData;
using Business.Strategy.ETO.Domain.StrategicDirection;
using Business.Strategy.ETO.Domain.StrategicScope;
using MongoDB.Bson.Serialization;

namespace Business.Strategy.ETO.MongoDB.Mapping
{
    public static class CompanyEntityMap
    {

        public static void Configure()
        {
            MapCompanyEntity();
            MapIndustryDataEntity();
            MapFinancialEntity();
            MapStrategicScopeEntity();

        }

        private static void MapCompanyEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(CompanyEntity)))
                BsonClassMap.TryRegisterClassMap<CompanyEntity>(map =>
                {
                    map.AutoMap();

                });
        
        }

        private static void MapIndustryDataEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(IndustryDataEntity)))
                BsonClassMap.TryRegisterClassMap<IndustryDataEntity>(map =>
                {
                    map.AutoMap();

                });

        }

        private static void MapFinancialEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(FinancialEntity)))
                BsonClassMap.TryRegisterClassMap<FinancialEntity>(map =>
                {
                    map.AutoMap();

                });

        }

        private static void MapStrategicScopeEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(StrategicScopeEntity)))
                BsonClassMap.TryRegisterClassMap<StrategicScopeEntity>(map =>
                {
                    map.AutoMap();

                });

        }

        private static void MapStrategicDirectionEntity()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(StrategicDirectionEntity)))
                BsonClassMap.TryRegisterClassMap<StrategicDirectionEntity>(map =>
                {
                    map.AutoMap();

                });

        }
    }
}
