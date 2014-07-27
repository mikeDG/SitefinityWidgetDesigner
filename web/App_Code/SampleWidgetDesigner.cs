using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.GenericContent.Model;


namespace Sample
{

    public class SampleWidgetDesigner : ControlDesignerBase
    {

        #region "Private members & constants"

        // 1. set the path for template control and client script
        public static readonly string _layoutTemplatePath = "~/UserControls/SampleWidgetDesigner.ascx";
        public const string _scriptReference = "~/UserControls/SampleWidgetDesigner.js";

        #endregion

        // 2. define properties for each control (matching the widget properties names of "Sample User Control")
        #region "Control references"

        protected virtual Control Heading
        {
            get { return Container.GetControl<Control>("Heading", true); }
        }

        protected virtual Control Intro
        {
            get { return Container.GetControl<Control>("Intro", true); }
        }

        protected virtual CheckBoxList GroupIDs
        {
            get { return Container.GetControl<CheckBoxList>("GroupIDs", true); }
        }

        protected virtual Control ColumnConfig
        {
            get { return Container.GetControl<Control>("ColumnConfig", true); }
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// 3. Initialize your controls here, ex: drop down list items from DB
        /// </summary>
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            GroupIDs.Items.Clear();
            GroupIDs.Items.Add (new ListItem(" Customers", "1"));
            GroupIDs.Items.Add (new ListItem(" Members", "2"));
            GroupIDs.Items.Add(new ListItem(" Staff", "3"));
        }
        #endregion

        #region "IScriptControl implementation"
        /// <summary>
        /// 4. return a collection of script descriptors that represent client components.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddElementProperty("Heading", Heading.ClientID);
            descriptor.AddElementProperty("GroupIDs", GroupIDs.ClientID);
            // use AddComponentProperty AJAX components!
            descriptor.AddComponentProperty("ColumnConfig", ColumnConfig.ClientID);
            descriptor.AddComponentProperty("Intro", Intro.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(_scriptReference));
            return scripts;
        }
        #endregion


        #region "Properties"
        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                {
                    return _layoutTemplatePath;
                }
                return base.LayoutTemplatePath;
            }
            set { base.LayoutTemplatePath = value; }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }
        #endregion

        
    }
}

 