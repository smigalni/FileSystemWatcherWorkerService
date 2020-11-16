using CsvHelper.Configuration;
using FileSystemWatcherWorkerService.DtoModels;

namespace FileSystemWatcherWorkerService.Services
{
    public sealed class OrderCsvMap : ClassMap<OrderDto>
    {
        public OrderCsvMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Description).Index(1);
            Map(m => m.OrderDate).Index(2);
        }
    }
}