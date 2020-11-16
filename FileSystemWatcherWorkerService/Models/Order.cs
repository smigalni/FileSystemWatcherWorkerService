using System;

namespace FileSystemWatcherWorkerService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}