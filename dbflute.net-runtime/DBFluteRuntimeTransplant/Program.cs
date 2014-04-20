using DBFluteRuntimeTransplant.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DBFluteRuntimeTransplant
{
    /// <summary>
    /// 本家dbflute-runtimeから.NET版への移植バッチ
    /// </summary>
    class Program
    {
        private const int ARG_ORG_PATH = 0;
        private const int ARG_DEST_PATH = 1;
        private const int MAX_ARG_COUNT = 2;

        static void Main(string[] args)
        {
            AssertArgs(args);
            string orgPath = args[ARG_ORG_PATH];
            string destPath = args[ARG_DEST_PATH];

            // 既存フォルダの削除
            // ログ出力
            if (Directory.Exists(destPath))
            {
                Directory.Delete(destPath, true);
            }

            // ログ出力（dbflute-runtimeを丸ごとコピー）
            string copyCommand = string.Format("/c xcopy {0} {1} /I /E", orgPath.Remove(orgPath.Length - 1), destPath);
            DOSUtils.executeCommand(copyCommand);
            
            // ログ出力（ディレクトリ配下のフルパス一覧取得）
            string dirAllCommand = string.Format("/c dir {0} /b/a-d/s", destPath);
            string results = DOSUtils.executeCommand(dirAllCommand);
            if (string.IsNullOrEmpty(results))
            {
                // TODO:移植対象がないことを出力して終了
                return;
            }
            List<string> paths = results.Split(Environment.NewLine.ToCharArray()).Where(path => path.Length > 0).ToList();
            paths.ForEach(ExchangeSource);
            
            // 処理終了を出力
        }

        /// <summary>
        /// C#ファイルに変換
        /// </summary>
        /// <param name="javaFilePath"></param>
        private static void ExchangeSource(string javaFilePath)
        {
            if (!javaFilePath.EndsWith(".java"))
            {
                // javaファイル以外は削除
                File.Delete(javaFilePath);
                return;
            }
            // javaファイルの拡張子を.csに変換
            // 各予約語の変換

            // 拡張子をC#ファイルに変換
            string csFilePath = javaFilePath.Remove(javaFilePath.Length - 5) + ".cs";
            File.Move(javaFilePath, csFilePath);
        }


        /// <summary>
        /// 引数チェック
        /// </summary>
        /// <param name="args">プログラム引数</param>
        /// <exception cref="ArgumentException">誤った引数</exception>
        private static void AssertArgs(string[] args)
        {
            if (args.Length < MAX_ARG_COUNT)
            {
                throw new ArgumentException("This program needs two arguments. USAGE:[0]This program [1]Original source path [2]Destination solution path");
            }

            if (!Directory.Exists(args[ARG_ORG_PATH]))
            {
                throw new ArgumentException(string.Format("Original path is not exists. (%1)", args[ARG_ORG_PATH]));
            }

            if (string.IsNullOrEmpty(args[ARG_DEST_PATH]))
            {
                throw new ArgumentException("Destination path is empty.");
            }
        }
    }
}
