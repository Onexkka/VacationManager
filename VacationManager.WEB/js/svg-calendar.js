﻿var calendarBase = $('.calendar-base'),
    nextBtn = $('#next'),
    prevBtn = $('#prev');
var index = null;
var size = 20;
var sizeWithMargin = 22;

function drawCalendar(svg) {
    svg.configure({ width: "420", height: "180" }, true);

    var currentDate = new Date;
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth());
    currentDate.setMonth(new Date().getMonth() + index);

    for (var m = 0; m != 3; m++) {
        var offset = moment(currentDate).day();
        if (offset == 0)
            offset = 7;
        offset--;
        var daysInMonth = moment(currentDate).daysInMonth();

        var monthGroup = svg.group({ transform: 'translate(' + m * sizeWithMargin * 6 + ' 0)' });
        svg.text(monthGroup, sizeWithMargin * 3, 15, moment(currentDate).format('MMM YY'));

        for (var i = 0; i != 6; i++) {
            var weekGroup = svg.group(monthGroup, { transform: 'translate(' + i * sizeWithMargin + ' 20)' });
            for (var j = 0; j != 7; j++) {
                var x = size, y = (j * sizeWithMargin), textOffset = 20;
                if (i == 0 && j < offset || i > 3 && (i * 7 + (j + 1)) > daysInMonth + offset) {
                    svg.rect(weekGroup, x, y, size, size, { style: "display: none;" });
                }
                else {
                    svg.rect(weekGroup, x, y, size, size, { class: "day" , data: moment(currentDate).format('L')});
                    svg.text(weekGroup, x, y + textOffset, '' + currentDate.getDate(), { class: "small" });
                    currentDate.setDate(currentDate.getDate() + 1);
                }
            }
        }

        currentDate = new Date;
        currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth());
        currentDate.setMonth(new Date().getMonth() + index + m + 1);
    }

    $.getJSON("/Home/List", null, function(json){
        var text = $('.day');
        text.each(function (index, value) { 
            var dd = new Date($(this).attr('data'));
            var count = 0;
            json.forEach(function(element) {
                if(dd >= parseInt(element.DateStart.substr(6, 13)) && dd <= parseInt(element.DateEnd.substr(6, 13))) {
                    count++;
                    console.log(count);
                }
            });
            $(this).attr("class", "day lvl-" + count);
        });
        // console.log(Object.keys(json));
        // jQuery('#testList').html('');
        // jQuery('#testList').append('Id: '   + json[0] + '<br/>')
        //                     .append('DateStart: ' + parseInt((json[0]).DateStart.substr(6, 13)) + '<br/>')
        //                     .append('DateStart end: '    + new Date(parseInt(json[0].DateEnd.substr(6, 13))).toISOString() + '<br/>');
    });       
    // console.log(Object.keys(text[0]));
    //console.log(text[0].getAttribute("data"));
    //console.log(new Date(text[0].getAttribute("data")));
}

nextBtn.click(function (e) {
    index++;
    //console.log(index);
    calendarBase.svg('destroy');
    calendarBase.svg(drawCalendar);
});

prevBtn.click(function (e) {
    index--;
    //console.log(index);
    calendarBase.svg('destroy');
    calendarBase.svg(drawCalendar);
});