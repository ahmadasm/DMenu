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
            ReorderMenuItems();    
        }
    });
    $('.menu-item-name').on('input propertychange paste',function(){
        var menuItem = $(this).closest('.webo-menu-item');
        var itemTitleList = $(menuItem).find('.panel-title a');
        var itemTitle = itemTitleList.first();
        itemTitle.html($(this).val());
    });
    function ReorderMenuItems()
    {
        var menuItems = $('li.webo-menu-item');
        for(var i = 0; i < menuItems.length;i++)
        {
            SetId(menuItems[i],i);
            SetName(menuItems[i],i);
            SetLink(menuItems[i],i);
            SetCss(menuItems[i],i);
            SetNewTab(menuItems[i],i);
            //alert(i + " : " + menuItems[i]);
        }
    }
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
    function SetNewTab(menuItem,index)
    {
        var nameInput = $(menuItem).find('.menu-item-tab');
        var newName = 'OpenInNewTab[' + index + ']';
        nameInput.attr('name',newName);
    }
    
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
    function AddNewMenuItem(text,link,header)
    {
        var newItem = '<li class="webo-menu-item mjs-nestedSortable-leaf mjs-nestedSortable-branch mjs-nestedSortable-expanded" id="menuItem_2">'+
        '<div class="menuDiv panel panel-default"><div class="panel-heading" role="tab" id="headingOne">'+
        '<h4 class="panel-title"><a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne3" aria-expanded="false" aria-controls="collapseOne3">'+
        text +
        '</a></h4></div><div id="collapseOne3" class="panel-collapse collapse " role="tabpanel" aria-labelledby="headingOne">'+
        '<div class="panel-body"><div class="form-group"><label>متن</label>'+
        '<input  class="menu-item-name form-control" value="'+
        text + '"></div><div class="form-group"><label>نشانی اینترنتی</label><input class="menu-item-link form-control" value="'+
        link + '"></div><div class="form-group"><label>کلاس CSS</label><inputclass="menu-item-css form-control">'+
        '</div><div class="form-group"><input type="checkbox" class="menu-item-tab"><label>باز شدن در تب جدید</label>'+
        '</div></div><div class="panel-footer text-left"><button type="button" class="btn-remove-menu-item btn btn-danger" >حذف</button>'+
        '</div></div></div></li>';
        $('.sortable').append(newItem);
    }
    $("#btnSaveEditedMenu").click(function(e){
        e.preventDefault();
        AddParentIds();
        $('#menuEditorForm').submit();
    });
    $('.btn-remove-menu-item').click(function(){
        var menuItem = $(this).closest('.webo-menu-item');
        $(menuItem).remove();
        ReorderMenuItems();
    });
    $(".btn-add-menu-item").click(function(){
        var itemsWrapperId = $(this).data("items-wrapper-id");
        var itemWrapper = $(itemsWrapperId);
        var items = $(itemWrapper).find('.webo-menu-item-checkbox');
        for(var i=0;i < items.length;i++)
        {
            var itemText = $(items[i]).data('text');
            var itemLink = $(items[i]).data('link');
            var itemHeader = $(items[i]).data('header');
            AddNewMenuItem(itemText,itemLink,itemHeader);
        }
        ReorderMenuItems();
    });
});