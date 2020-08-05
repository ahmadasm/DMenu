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
        }
    });
});