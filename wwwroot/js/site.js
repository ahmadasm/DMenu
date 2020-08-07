$(document).ready(function(){
    var ns = $('ol.sortable').nestedSortable({
        forcePlaceholderSize: true,
        handle: 'div',
        helper:	'clone',
        items: 'li',
        opacity: .6,
        placeholder: 'placeholder',
        revert: 250,
        tabSize: 25,
        tolerance: 'pointer',
        toleranceElement: '> div',
        maxLevels: 4,
        isTree: true,
        expandOnHover: 700,
        startCollapsed: false,
        rtl: true,
        change: function(){
            console.log('Relocated item');
        },
        start: function(e, ui) {
            // creates a temporary attribute on the element with the old index
            $(this).attr('data-previndex', ui.item.index());
        },
        update: function(e, ui) {
        },
        stop: function(event, ui) {
            var menuItems = $('li.webo-menu-item');
            for(var i = 0; i < menuItems.length;i++)
            {
                SetId(menuItems[i],i);
                SetName(menuItems[i],i);
                //alert(i + " : " + menuItems[i]);
            }
            
        }
    });
    function SetId(menuItem,index)
    {   
        var newId = 'menuItem_' + index;
        $(menuItem).attr('id',newId);
    }
    function SetName(menuItem,index)
    {
        var title = $(menuItem).find('.panel-title a');
        title.text(index);
        var nameInput = $(menuItem).find('.menu-item-name');
        var newName = 'Names[' + index + ']';
        nameInput.attr('name',newName);
        //nameInput.val(index);
    }
    $('#toArray').click(function(){
        serialized = $('ol.sortable').nestedSortable('serialize');
        alert(JSON.stringify(serialized));
    })
});