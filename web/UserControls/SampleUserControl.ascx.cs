using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace Sample
{
    // setup the designer for this widget
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Sample.SampleWidgetDesigner))]
    public partial class SampleUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // just display values of properties set from Sitefinity
                HeadingLabel.Text = Heading;
                IntroLabel.Text = Intro;
                GroupsLabel.Text = GroupIDs;

                ColRepeater.DataSource = parseColumnConfig();
                ColRepeater.DataBind();
            }

        }

        // parse JSON string
        private List<ColumnSetting> parseColumnConfig()
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            try
            {
                return JSS.Deserialize<List<ColumnSetting>>(ColumnConfig);
            }
            catch (Exception ex)
            {
                return null;
                //ignore deserialize errors
            }
        }

        // Simple string property for heading
        public string Heading
        {
            get;
            set;
        }

        // HTML String for intro
        public string Intro
        {
            get;
            set;
        }

        // Comma-delimited values
        public string GroupIDs
        {
            get;
            set;
        }

        // JSON String of List<ColumnSetting>
        public string ColumnConfig
        {
            get;
            set;
        }

    }
}