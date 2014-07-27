Type.registerNamespace("Sample");

Sample.SampleWidgetDesigner = function (element) {
    this._Heading = null;
    this._GroupIDs = null;
    this._Intro = null;
    this._ColumnConfig = null;

    /* Calls the base constructor */
    Sample.SampleWidgetDesigner.initializeBase(this, [element]);
}

Sample.SampleWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        Sample.SampleWidgetDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        Sample.SampleWidgetDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        this._refreshMode = true;

        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */
        
        // using jQuery .val() for simple inputs 
        jQuery(this.get_Heading()).val(controlData.Heading);
        // using custom function for more complex inputs
        this._setCheckboxValues(this.get_GroupIDs(), controlData.GroupIDs);
        // using set_value for AJAX components 
        this.get_Intro().set_value(controlData.Intro);
        this.get_ColumnConfig().set_value(controlData.ColumnConfig);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        // using jQuery .val() for simple inputs 
        controlData.Heading = jQuery(this.get_Heading()).val();
        // using custom function for more complex inputs
        controlData.GroupIDs = this._getCheckboxValues(this.get_GroupIDs());
        // using get_value for AJAX components 
        controlData.Intro = this.get_Intro().get_value();
        controlData.ColumnConfig = this.get_ColumnConfig().get_value();
    },

    /* --------------------------------- event handlers ---------------------------------- */
    /* --------------------------------- private methods --------------------------------- */

    // return Checkboxs values as comma-delimited string
    _getCheckboxValues: function (elm) {
        var checkedboxs = jQuery(':checkbox:checked', elm);
        return checkedboxs.map(function () { return jQuery(this).val() }).get().join(',');
    },

    // Set checked checkboxs from comma-delimited string
    _setCheckboxValues: function (elm, values) {
        var valuesComma = ',' + values + ',';

        var boxs = jQuery(':checkbox', elm);
        boxs.each(function () {
            var box = jQuery(this);
            var checked = valuesComma.indexOf(',' + box.val() + ',') > -1;
            box.prop('checked', checked);
        });
    },

    /* --------------------------------- properties -------------------------------------- */
    get_Heading: function () { return this._Heading; },
    set_Heading: function (value) { this._Heading = value; },

    get_Intro: function () { return this._Intro; },
    set_Intro: function (value) { this._Intro = value; },

    get_GroupIDs: function () { return this._GroupIDs; },
    set_GroupIDs: function (value) { this._GroupIDs = value; },

    get_ColumnConfig: function () { return this._ColumnConfig; },
    set_ColumnConfig: function (value) { this._ColumnConfig = value; }
    // watch out from the trailing comma!
}

Sample.SampleWidgetDesigner.registerClass('Sample.SampleWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);


