Type.registerNamespace("Sample");

Sample.ColumnSettingsField = function (element) {
    Sample.ColumnSettingsField.initializeBase(this, [element]);
    this._element = element;
    this._labelElement = null;

    this._appLoadedDelegate = null;
    this._appLoaded = false;

    // hidden field
    this._ValueField = null;
}

Sample.ColumnSettingsField.prototype = {
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        Sample.ColumnSettingsField.callBaseMethod(this, "initialize");

        if (this._appLoadedDelegate === null) {
            this._appLoadedDelegate = Function.createDelegate(this, this._applicationLoaded);
        };

        Sys.Application.add_load(this._appLoadedDelegate);
    },
    dispose: function () {
        /*  this is the place to unbind/dispose the event handlers created in the initialize method */
        Sample.ColumnSettingsField.callBaseMethod(this, "dispose");

        if (this._appLoadedDelegate) {
            Sys.Application.remove_load(this._appLoadedDelegate);
            delete this._appLoadedDelegate;
        }
    },

    /* --------------------------------- public methods ---------------------------------- */
    get_value: function () {
        this._readUI();

        return jQuery(this._ValueField).val();
    },

    set_value: function (value) {
        if (!value) return;

        jQuery(this._ValueField).val(value);

        if (this._appLoaded)  this._updateUI();

        this.raisePropertyChanged("value");
    },
    /* --------------------------------- event handlers ---------------------------------- */
    /* --------------------------------- private methods --------------------------------- */
    _applicationLoaded: function (sender, agrs) {
        this._appLoaded = true;
        this._updateUI();
    },

    _updateUI: function () {
        // get JSON value from hidden field
        var json = jQuery(this._ValueField).val();
        // parse JSON to array 
        var items = this._strToItems(json);
        if (!items || !items.length) return;

        // field container 
        var panel = jQuery(this._element);

        var _this = this;
        // loop tr 
        jQuery('tr', panel).each(function () {
            var tr = jQuery(this);
            // Id from data attribute
            var id = tr.data('id');
            if (!id) return;

            var item = _this._GetItem(items, id);
            if (item) {
                // set visible checkbox and heading input values
                jQuery('._Visible', tr).prop('checked', item.Visible);
                jQuery('._Heading', tr).val(item.Heading);
            };
        });
    },

    _readUI: function () {
        var items = [];

        // field container 
        var panel = jQuery(this._element);

        var _this = this;
        // loop tr
        jQuery('tr', panel).each(function () {
            var tr = jQuery(this);
            // Id from data-id attribute
            var id = tr.data('id');
            if (!id) return;

            // get values from visible checkbox and heading input and into new object
            var item = { ID: id
                         , Visible: jQuery('._Visible', tr).prop('checked')
                         , Heading: jQuery('._Heading', tr).val()
            };
            // add object to arrays
            items[items.length] = item;
        });
        // set hidden field value from JSON
        jQuery(this._ValueField).val(Sys.Serialization.JavaScriptSerializer.serialize(items));        
    },

    // parse JSON string to array of objects
    _strToItems: function (json) {
        try {
            return Sys.Serialization.JavaScriptSerializer.deserialize(json);
        } catch (e) {
            return null;
        }
    },

    _escape: function (s) {
        return s.replace(/'/g, "&#39;").replace(/"/g, "&#34;").replace(/\n/g, " ").replace(/\\/g, "&#92;");
    },

    _GetItem: function (ops, id) {
        if (ops == null) return null;

        for (var i = 0; i < ops.length; i++) {
            if (ops[i].ID == id) return ops[i]
        };

        return null;
    },
    /* --------------------------------- properties -------------------------------------- */

    get_ValueField: function () { return this._ValueField },
    set_ValueField: function (value) { this._ValueField = value }
};

Sample.ColumnSettingsField.registerClass("Sample.ColumnSettingsField", Telerik.Sitefinity.Web.UI.Fields.FieldControl);