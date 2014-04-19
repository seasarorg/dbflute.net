using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntimeTransplant.Util
{
    /// <summary>
    /// DOSコマンド実行ユーティリティクラス
    /// </summary>
    public sealed class DOSUtils
    {
        /// <summary>
        /// DOSコマンドを実行する（処理終了まで待機）
        /// </summary>
        /// <param name="command">実行するDOSコマンド</param>
        public static string executeCommand(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = command;
            p.Start();

            string result = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return result;
        }
    }
}
