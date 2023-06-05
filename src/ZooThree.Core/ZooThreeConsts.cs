using ZooThree.Debugging;

namespace ZooThree
{
    public class ZooThreeConsts
    {
        public const string LocalizationSourceName = "ZooThree";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "becf279159ac4225828c02a1f738c7d4";
    }
}
