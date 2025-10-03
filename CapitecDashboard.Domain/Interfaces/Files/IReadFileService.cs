using CapitecDashboard.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Files
{
    public interface IReadFileService
    {
        Task<string> SaveFileAsync(IFormFile formFile);
        FileInfo SaveFile(IFormFile formFile);
        List<BackDateDataModel> ReadFile(FileInfo fileInfo);
        Task<List<BackDateDataModel>> ReadFileAsync(FileInfo fileInfo);
    }
}
