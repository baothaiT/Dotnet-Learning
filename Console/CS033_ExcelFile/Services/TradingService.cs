using System;
using System.Globalization;
using System.IO;
using CS033_ExcelFile.Models;
using OfficeOpenXml;

namespace CS033_ExcelFile.Services;


public class TradingService
{
    public TradingService()
    {

    }

    public double CaculatorProfit(List<ExcelModel> buyData, List<ExcelModel> sellData)
    {
        double profit = sellData.Sum(x => x.FilledAndOrderValue_Prefix) - buyData.Sum(x => x.FilledAndOrderValue_Prefix);
        return profit;
    }
}