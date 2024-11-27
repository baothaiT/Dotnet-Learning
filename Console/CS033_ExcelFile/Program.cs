
using CS033_ExcelFile.Enums;
using CS033_ExcelFile.Services;

namespace CS033_ExcelFile;

class Program
{
    static void Main(string[] args)
    {
        ExcelService excelService = new ExcelService();
        var targetDirectory = excelService.GetFilePath();
        var excelData = excelService.Read(targetDirectory);
        // excelService.Write(excelData, targetDirectory);
        // excelService.Write(excelData.Where(x => x.Symbol_Prefix == SymbolCoinEnums.TON).ToList(), targetDirectory);
        excelService.Write(excelData.Where(x => x.Symbol_Prefix == SymbolCoinEnums.DOGE).ToList(), targetDirectory);

        TradingService tradingService = new TradingService();
        var profit = tradingService.CaculatorProfit(
            excelData.Where(x => x.Side == TypeSideEnum.BUY && x.Symbol_Prefix == SymbolCoinEnums.DOGE).ToList(),
            excelData.Where(x => x.Side == TypeSideEnum.SELL && x.Symbol_Prefix == SymbolCoinEnums.DOGE).ToList()
        );

        Console.WriteLine($"Profit = {profit} USDT");
    }
}