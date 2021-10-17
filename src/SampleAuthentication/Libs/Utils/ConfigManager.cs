namespace Libs
{
    public interface IConfigManager
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        string ConnString
        {
            get;
        }
    }

    public class ConfigManager : IConfigManager
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnString
        {
            get;
            set;
        }
    }
}
