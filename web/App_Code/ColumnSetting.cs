namespace Sample
{
    /// <summary>
    /// Simple Class for Holding Column Settings to be used in serialize/deserialize JSON strings
    /// </summary>
    public class ColumnSetting
    {
        public ColumnSetting()
        {

        }
        public ColumnSetting(string xID )
        {
            ID = xID;
        }

        public string ID
        {
            get;
            set;
        }

        public string Heading
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }
    }
}