namespace GenericLogger.DataStructures
{
    public class LogData
    {
        public bool Encryption { get; set; }
        public string SerializeInfo { get; set; }

        public LogData()
        {
            Encryption = false;
            SerializeInfo = null;
        }

        public LogData(bool encryption, string serializeInfo)
        {
            Encryption = encryption;
            SerializeInfo = serializeInfo;
        }
    }
}