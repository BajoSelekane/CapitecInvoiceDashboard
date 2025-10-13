using CapitecDashboard.Domain.Interfaces.Files;
using CapitecDashboard.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Infrastructure.Files
{
    public class ReadFileService : IReadFileService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ReadFileService> logger;

        public ReadFileService(IConfiguration configuration, ILogger<ReadFileService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public List<BackDateDataModel> ReadFile(FileInfo fileInfo)
        {
            var rawData = new List<BackDateDataModel>();
            var rowNumberToStart = 2;

            int? definedRowNum = configuration.GetValue<int>("BulkUploadStartingRow");

            if (definedRowNum != null)
            {
                rowNumberToStart = definedRowNum.Value;
            }

            using (var package = new ExcelPackage(fileInfo))
            {
                var workBook = package.Workbook;

                var workSheet = workBook.Worksheets.First();

                int totalRows = workSheet.Dimension.End.Row;

                for (var i = 1; i <= totalRows; i++)
                {
                    if (i < rowNumberToStart)
                        continue;

                    int columnNumber = 1;


                    var rowData = new BackDateDataModel
                    {
                        RowNumber = i,
                        Number = workSheet.Cells[i, 1].Text.ToString().Trim(),
                        DateCaptured = workSheet.Cells[i, 2].Text.ToString().Trim(),
                        Name = workSheet.Cells[i, 3].Text.ToString().Trim(),
                        SurnameAtBirth = workSheet.Cells[i, 4].Text.ToString().Trim(),
                        Sex = workSheet.Cells[i, 5].Text.ToString().Trim(),
                        Ethnicity = workSheet.Cells[i, 6].Text.ToString().Trim(),
                        DateOfBirth = workSheet.Cells[i, 7].Text.ToString().Trim(),
                        IdNumber = workSheet.Cells[i, 8].Text.ToString().Trim(),
                        Operation = workSheet.Cells[i, 9].Text.ToString().Trim(),
                        BusinessUnit = workSheet.Cells[i, 10].Text.ToString().Trim(),
                        ImplementingPartner = workSheet.Cells[i, 11].Text.ToString().Trim(),
                        PackageOfService = workSheet.Cells[i, 12].Text.ToString().Trim(),
                        ServiceRendered = workSheet.Cells[i, 13].Text.ToString().Trim(),
                        Province = workSheet.Cells[i, 14].Text.ToString().Trim(),
                        District = workSheet.Cells[i, 15].Text.ToString().Trim(),
                        SubDistrict = workSheet.Cells[i, 16].Text.ToString().Trim(),
                        Facility = workSheet.Cells[i, 17].Text.ToString().Trim(),
                        ProvinceOfBirth = workSheet.Cells[i, 18].Text.ToString().Trim(),
                        AdditionalNeeds = workSheet.Cells[i, 19].Text.ToString().Trim(),
                        ReferredOnwards = workSheet.Cells[i, 20].Text.ToString().Trim(),

                    };
                    rawData.Add(rowData);
                }
            }

            return rawData;
        }

        public Task<List<BackDateDataModel>> ReadFileAsync(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public FileInfo SaveFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileAsync(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
