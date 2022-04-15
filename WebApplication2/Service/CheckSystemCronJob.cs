using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication2.Entity;

namespace WebApplication2.Service
{
    public class CheckSystemCronJob : CronJobService
    {
        private readonly string[] CATEGORY = {"Processor", "Memory", "Paging File", "PhysicalDisk", "Process"};

        private readonly string[] COUNTER =
        {
            "% Disk Time", "Available MBytes", "% Processor Time", "Processor Queue Length", "% Usage",
            "% Committed Bytes In Use"
        };

        private readonly string[] INSTANCE = {"_Total"};
        private readonly ILogger<CheckSystemCronJob> _logger;

        public CheckSystemCronJob(IScheduleConfig<CheckSystemCronJob> config, ILogger<CheckSystemCronJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            CheckSystem();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 is stopping.");
            return base.StopAsync(cancellationToken);
        }

        
        
        private void CheckSystem()
        {
            double diskTime = GetDiskTime();
            double ram = GetRamPercent();
            double disk = PerformanceService.GetFreeSpacePercent();

            if (disk > 80.00)
            {
                Message message = new Message("Hệ thống server quá tải",
                    "Hệ thống đang chạy với hiệu năng: " + diskTime + "%");
                var log = ApiService.callApiNotify(message);
                _logger.LogInformation(log);
            }

            if (ram > 90.00)
            {
                Message message = new Message("Hệ thống server quá tải",
                    "Hệ thống đang chạy với Ram: " + ram + "%");
                var log = ApiService.callApiNotify(message);
                _logger.LogInformation(log);
            }

            if (disk > 90.00)
            {
                Message message = new Message("Hệ thống server quá tải",
                    "Hệ thống đang sắp quá tải lưu trữ: " + disk + "%");
                var log = ApiService.callApiNotify(message);
                _logger.LogInformation(log);
            }
        }

        private double GetDiskTime()
        {
            Performance performance = new Performance(CATEGORY[3], COUNTER[0], INSTANCE[0]);
            var diskTime = Math.Round(PerformanceService.GetActiveDisk(performance), 2);
            return diskTime;
        }

        private double GetRamPercent()
        {
            Performance performance = new Performance(CATEGORY[1], COUNTER[5], null);
            var diskTime = Math.Round(PerformanceService.GetActiveDisk(performance)-8, 2);
            return diskTime;
        }

        
    }
}