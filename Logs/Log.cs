using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingToWorkApp.Logs
{
    /// <summary>
    /// ログ出力用クラス
    /// </summary>
    public class Log
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void Debug()
        {
            logger.Debug("開発中のデバッグ／トレースに使用する");
        }

        public void Info()
        {
            logger.Info("情報（操作履歴等）");
        }

        public void Warn()
        {
            logger.Warn("注意／警告（障害の一歩手前）");
        }

        public void Error()
        {
            logger.Error("システムが停止するまではいかない障害が発生");
        }

        public void Fatal()
        {
            logger.Fatal("システムが停止する致命的な障害が発生");
        }

    }
}
