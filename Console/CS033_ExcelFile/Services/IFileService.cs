using CS033_ExcelFile.Models;

namespace CS033_ExcelFile.Services;

public interface IFileService
{
    public string GetFilePath();
    public List<ExcelModel> Read(string filePath);
    public void Write(List<ExcelModel> orders, string filePath);
}