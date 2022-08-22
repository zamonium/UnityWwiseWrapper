namespace STB.Client.Audio
{
    public class BankData
    {
        public BankData(string sName, eBankType eType)
        {
            BankName = sName;
            BankType = eType;
        }

        #region Properties

        public string BankName { get; private set; }
        public eBankType BankType { get; private set; }

        #endregion
    }
}
