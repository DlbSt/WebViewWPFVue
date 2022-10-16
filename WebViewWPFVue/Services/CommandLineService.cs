using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebViewWPFVue.Helpers;

namespace WebViewWPFVue.Services
{
    public class CommandLineService : ICommandLineService
    {
        public ComputerInfoMessage GetComputerInfo()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.ErrorDialog = false;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C systeminfo";
            p.Start();
            p.WaitForExit();
            string[] output = p.StandardOutput.ReadToEnd().Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            var osName = Regex.Replace(output[2], @"\s+", "").Remove(0, 7);
            var osVersion = Regex.Replace(output[3], @"\s+", "").Remove(0, 10);
            var systemManufacturer = Regex.Replace(output[12], @"\s+", "").Remove(0, 19);
            var systemModel = Regex.Replace(output[13], @"\s+", "").Remove(0, 12);
            var totalMemory = Regex.Replace(output[24], @"\s+", "").Remove(0, 20);

            return new ComputerInfoMessage
            {
                OsName = osName,
                OsVersion = osVersion,
                SystemManufacturer = systemManufacturer,
                SystemModel = systemModel,
                TotalMemory = totalMemory
            };           
        }
    }

    #region Interface
    public interface ICommandLineService
    {
        #region Methods
        ComputerInfoMessage GetComputerInfo();
        #endregion
    } 
    #endregion
}
