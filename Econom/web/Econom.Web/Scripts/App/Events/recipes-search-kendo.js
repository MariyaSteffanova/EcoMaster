(function () {
    var selectedIds = {};

    // Kendo
    function onSelect(e) {

        var dataItem = this.dataSource.view()[e.item.index()];

        if (selectedIds[dataItem.ID] == undefined) {
            selectedIds[dataItem.ID] = 0;
        }
        selectedIds[dataItem.ID] = +selectedIds[dataItem.ID] + 1;
    }
}());