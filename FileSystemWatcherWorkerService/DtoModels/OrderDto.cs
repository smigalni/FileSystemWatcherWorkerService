using System;

namespace FileSystemWatcherWorkerService.DtoModels
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}