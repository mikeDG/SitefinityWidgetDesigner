using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.GenericContent.Model;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Web.UI.Fields;
using System.ComponentModel;
using Telerik.Sitefinity.Utilities.TypeConverters;
using System.Web.UI.HtmlControls;

namespace Sample
{
    public class ColumnSettingsField : FieldControl
    {
        #region "Private members"
        // 1. set the path for template control and client script
        public static readonly string _layoutTemplatePath = "~/UserControls/ColumnSettingsField.ascx";
        public static readonly string _ScriptReference = "~/UserControls/ColumnSettingsField.js";
        #endregion

        public ColumnSettingsField()
        {
        }

        /// <summary>
        /// 2. Hidden field to hold JSON value of selection
        /// </summary>
        protected virtual HiddenField ValueField
        {
            get { return this.Container.GetControl<HiddenField>("ValueField", true); }
        }

        // Repeater to hold settings inputs
        protected virtual Repeater FieldRepeater
        {
            get { return this.Container.GetControl<Repeater>("FieldRepeater", true); }
        }

        #region "Initialize Controls"
        // 3. initialize ui
        protected override void InitializeControls(GenericContainer container)
        {
            this.TitleLabel.Text = this.Title;
            this.ExampleLabel.Text = this.Example;
            this.DescriptionLabel.Text = this.Description;

            // init repeater with 3 sample settings 
            var SettingList = new List<ColumnSetting>();
            SettingList.Add(new ColumnSetting("Email"));
            SettingList.Add(new ColumnSetting("Position"));
            SettingList.Add(new ColumnSetting("Company"));

            FieldRepeater.ItemDataBound += new RepeaterItemEventHandler(FieldRepeater_ItemDataBound);
            FieldRepeater.DataSource = SettingList;
            FieldRepeater.DataBind();
        }

        void FieldRepeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var setting = e.Item.DataItem as ColumnSetting;
            // set data-id attribute on each tr to hold the setting id for client script 
            var FieldTr = (HtmlTableRow)e.Item.FindControl("FieldTr");
            FieldTr.Attributes.Add("data-id", setting.ID);

            var IDLabel = (Label)e.Item.FindControl("IDLabel");
            IDLabel.Text = setting.ID;
        }
        #endregion

        // 4. return a collection of script descriptors that represent client components.
        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();

            var descriptor = base.GetScriptDescriptors().Last() as ScriptControlDescriptor;

            descriptor.AddElementProperty("ValueField", ValueField.ClientID);

            descriptors.Add(descriptor);

            return descriptors.ToArray();
        }

        [TypeConverter(typeof(ObjectStringConverter))]
        public override object Value
        {
            get { return ValueField.Value; }
            set { ValueField.Value = value.ToString() ; }
        }

        #region "Must override Methods"
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>(base.GetScriptReferences());

            scripts.Add(new ScriptReference(_ScriptReference));

            return scripts;
        }
        #endregion

        #region "Must override Properties"
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

        protected override WebControl TitleControl
        {
            get { return this.TitleLabel; }
        }

        protected override WebControl DescriptionControl
        {
            get { return this.DescriptionLabel; }
        }

        protected override WebControl ExampleControl
        {
            get { return this.ExampleLabel; }
        }

        /// <summary>
        /// Gets the reference to the label control that represents the title of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label TitleLabel
        {
            get { return this.Container.GetControl<Label>("titleLabel", true); }
        }

        /// <summary>
        /// Gets the reference to the label control that represents the description of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label DescriptionLabel
        {
            get { return Container.GetControl<Label>("descriptionLabel", true); }
        }

        /// <summary>
        /// Gets the reference to the label control that displays the example for this
        /// field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in the write mode.
        /// </remarks>
        protected internal virtual Label ExampleLabel
        {
            get { return this.Container.GetControl<Label>("exampleLabel", true); }
        }
        #endregion
    }
}

