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
                SetLink(menuItems[i],i);
                SetCss(menuItems[i],i);
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
        //var title = $(menuItem).find('.panel-title a');
        //title.text(index);
        var nameInput = $(menuItem).find('.menu-item-name');
        var newName = 'Text[' + index + ']';
        nameInput.attr('name',newName);
    }
    function SetLink(menuItem,index)
    {
        //var title = $(menuItem).find('.panel-title a');
        //title.text(index);
        var nameInput = $(menuItem).find('.menu-item-link');
        var newName = 'Links[' + index + ']';
        nameInput.attr('name',newName);
    }
    function SetCss(menuItem,index)
    {
        var nameInput = $(menuItem).find('.menu-item-css');
        var newName = 'CssClasses[' + index + ']';
        nameInput.attr('name',newName);
    }
    $("#btnSaveEditedMenu").click(function(e){
        e.preventDefault();
        AddParentIds();
        $('#menuEditorForm').submit();
    });
    function AddParentIds()
    {
        serialized = $('ol.sortable').nestedSortable('serialize');
        var data = serialized.split("&");
        for(var key in data)
        {
            var itemIndex = (data[key].split("=")[0]).replace("menuItem[","").replace("]","");
            var hiddenInputName = "Parents[" + itemIndex + "]"; 
            var hiddenValue = data[key].split("=")[1] 
            $("<input>").attr({ 
                name: hiddenInputName,  
                type: "hidden", 
                value: hiddenValue 
            }).appendTo("#menuEditorForm"); 
        }
    }
});