using AutoMapper;
using CsvHelper;
using FileSystemWatcherWorkerService.DtoModels;
using FileSystemWatcherWorkerService.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcherWorkerService.Services
{
    public class FolderWatcherService
    {
        private readonly IMapper _mapper;
        private readonly ConfigurationManagerService _configurationManagerService;
        private FileSystemWatcher _folderWatcher;
        private string _inputFolder;
        public FolderWatcherService(IMapper mapper,
            ConfigurationManagerService configurationManagerService)
        {
            _mapper = mapper;
            _configurationManagerService = configurationManagerService;
            _inputFolder = _configurationManagerService.GetFilePath();
        }
        public Task StartWatch()
        {
            if (!Directory.Exists(_inputFolder))
            {
                throw new Exception($"Please make sure the folder {_inputFolder} exists.");
            }

            _folderWatcher = new FileSystemWatcher(_inputFolder, "*")
            {
                NotifyFilter = NotifyFilters.CreationTime
                    | NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName
            };
            _folderWatcher.Changed += OnChanged;

            _folderWatcher.EnableRaisingEvents = true;
            return Task.CompletedTask;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var fullPath = Path.Combine(_inputFolder, e.Name);
            var orders = Parse(fullPath);
            Save(orders);
        }

        private void Save(List<Order> orders)
        {
        }

        private List<Order> Parse(string fullPath)
        {
            var list = new List<Order>();
            var cultureInfo = new CultureInfo("nb-NO", false);


            using (FileStream fsSource = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fsSource, encoding: Encoding.UTF8))
            using (var csv = new CsvReader(reader, cultureInfo))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<OrderCsvMap>();

                while (csv.Read())
                {
                    var dto = csv.GetRecord<OrderDto>();
                    list.Add(_mapper.Map<Order>(dto));
                }
            }
            return list;
        }
    }
}