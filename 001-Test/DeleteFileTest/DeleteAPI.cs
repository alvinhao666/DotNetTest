using System;
using System.Runtime.InteropServices;

namespace DeleteFile
{
    public class DeleteAPI
    {
        [DllImport("shell32.dll")]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        /// <summary>
        /// 执行删除。成功返回空，否则返回错误信息。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Delete(string path)
        {
            SHFILEOPSTRUCT lpFileOp = new SHFILEOPSTRUCT();
            lpFileOp.wFunc = wFunc.FO_DELETE;
            lpFileOp.pFrom = path + "\0";
            lpFileOp.fFlags = FILEOP_FLAGS.FOF_NOCONFIRMATION | FILEOP_FLAGS.FOF_NOERRORUI | FILEOP_FLAGS.FOF_SILENT;
            lpFileOp.fFlags &= ~FILEOP_FLAGS.FOF_ALLOWUNDO;
            lpFileOp.fAnyOperationsAborted = false;

            int n = SHFileOperation(ref lpFileOp);
            if (n == 0) return string.Empty;

            string tmp = GetErrorString(n);

            //.av 文件正常删除了但也提示 402 错误，不知道为什么。屏蔽之。
            if ((path.ToLower().EndsWith(".av") && n.ToString("X") == "402")) return string.Empty;

            return string.Format("{0}({1})", tmp, path);
        }

        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public wFunc wFunc;
            public string pFrom;
            public string pTo;
            public FILEOP_FLAGS fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        private enum wFunc
        {
            FO_MOVE = 0x0001,
            FO_COPY = 0x0002,
            FO_DELETE = 0x0003,
            FO_RENAME = 0x0004
        }

        private enum FILEOP_FLAGS
        {
            FOF_MULTIDESTFILES = 0x0001, //pTo 指定了多个目标文件，而不是单个目录
            FOF_CONFIRMMOUSE = 0x0002,
            FOF_SILENT = 0x0044, // 不显示一个进度对话框
            FOF_RENAMEONCOLLISION = 0x0008, // 碰到有抵触的名字时，自动分配前缀
            FOF_NOCONFIRMATION = 0x10, // 不对用户显示提示
            FOF_WANTMAPPINGHANDLE = 0x0020, // 填充 hNameMappings 字段，必须使用 SHFreeNameMappings 释放
            FOF_ALLOWUNDO = 0x40, // 允许撤销
            FOF_FILESONLY = 0x0080, // 使用 *.* 时, 只对文件操作
            FOF_SIMPLEPROGRESS = 0x0100, // 简单进度条，意味者不显示文件名。
            FOF_NOCONFIRMMKDIR = 0x0200, // 建新目录时不需要用户确定
            FOF_NOERRORUI = 0x0400, // 不显示出错用户界面
            FOF_NOCOPYSECURITYATTRIBS = 0x0800, // 不复制 NT 文件的安全属性
            FOF_NORECURSION = 0x1000 // 不递归目录
        }

        //更多错误代码见：ms-help://MS.MSDNQTR.v90.chs/shellcc/platform/shell/reference/functions/shfileoperation.htm
        private static string GetErrorString(int n)
        {
            if (n == 0) return string.Empty;

            string code = n.ToString("X").ToUpper();
            switch (code)
            {
                case "74":
                    return "The source is a root directory, which cannot be moved or renamed.";
                case "76":
                    return "Security settings denied access to the source.";
                case "7C":
                    return "The path in the source or destination or both was invalid.";
                case "10000":
                    return "An unspecified error occurred on the destination.";
                case "402":
                    return "An unknown error occurred. This is typically due to an invalid path in the source or destination. This error does not occur on Windows Vista and later.";
                default:
                    return code;
            }
        }
    }
}
