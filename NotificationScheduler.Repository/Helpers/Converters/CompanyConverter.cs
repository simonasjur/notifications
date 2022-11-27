using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Dto;

namespace NotificationScheduler.Repository.Helpers.Converters;

public static class CompanyConverter
{
    public static Company ToModel(CreateCompanyDto createCompanyDto)
    {
        return new Company
        {
            Name = createCompanyDto.CompanyName,
            Number = createCompanyDto.CompanyNumber,
            Type = createCompanyDto.CompanyType
        };
    }
}