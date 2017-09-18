//var $jq = jQuery.noConflict();
$(document).ready(function ($) {
    //For DateSelection
    var dateSelection = {
        // SelectionMode: 'Year',
        SelectionMode: 'Month',
        LeftNavControl: $('#datePrev'),
        RightNavControl: $('#dateNext'),
        LabelControl: $('#dateFilter'),
        StartDate: new Date(Date.now().getFullYear(), 0, 1),
        EndDate: new Date(Date.now().getFullYear(), 11, 31),
        SelectedYear: Date.now().getFullYear(),
        SelectedMonth: Date.now().getMonth(),
        SelectedQuarter: Math.floor(Date.now().getMonth() / 3),
        MonthNames: new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"),
        MonthAbbreviations: new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"),
        Quarters: new Array("Q1", "Q2", "Q3", "Q4"),
        LeftClick: function () {
            if (dateSelection.SelectionMode == 'Year') {
                dateSelection.SelectedYear -= 1;
            }
            if (dateSelection.SelectionMode == 'Month') {
                if (dateSelection.SelectedMonth == 0) {
                    dateSelection.SelectedMonth = 11;
                    dateSelection.SelectedYear -= 1;
                }
                else {
                    dateSelection.SelectedMonth -= 1;
                }
            }
            if (dateSelection.SelectionMode == 'Quarter') {
                if (dateSelection.SelectedQuarter == 0) {
                    dateSelection.SelectedQuarter = 3;
                    dateSelection.SelectedYear -= 1;
                }
                else {
                    dateSelection.SelectedQuarter -= 1;
                }
            }

            dateSelection.show();
            dateSelection.getjsonData();

        },
        RightClick: function () {
            if (dateSelection.SelectionMode == 'Year') {
                dateSelection.SelectedYear += 1;
            }
            if (dateSelection.SelectionMode == 'Month') {
                if (dateSelection.SelectedMonth == 11) {
                    dateSelection.SelectedMonth = 0;
                    dateSelection.SelectedYear += 1;
                }
                else {
                    dateSelection.SelectedMonth += 1;
                }
            }
            if (dateSelection.SelectionMode == 'Quarter') {
                if (dateSelection.SelectedQuarter == 3) {
                    dateSelection.SelectedQuarter = 0;
                    dateSelection.SelectedYear += 1;
                }
                else {
                    dateSelection.SelectedQuarter += 1;
                }
            }

            dateSelection.show();
            dateSelection.getjsonData();
        },
        init: function () {
            dateSelection.LeftNavControl.bind('click', dateSelection.LeftClick);
            dateSelection.RightNavControl.bind('click', dateSelection.RightClick);
        },

        show: function () {
            if (dateSelection.SelectionMode == 'Year') {
                dateSelection.LabelControl.val('Jan - Dec ' + dateSelection.SelectedYear);
            }
            if (dateSelection.SelectionMode == 'Month') {
                dateSelection.LabelControl.val(dateSelection.MonthNames[dateSelection.SelectedMonth] + ' ' + dateSelection.SelectedYear);
            }
            if (dateSelection.SelectionMode == 'Quarter') {
                dateSelection.LabelControl.val(dateSelection.Quarters[dateSelection.SelectedQuarter] + ' ' + dateSelection.SelectedYear);
            }
            //alert(dateSelection.getStartDate());
            //alert(dateSelection.getEndDate());
        },
        getStartDate: function () {
            if (dateSelection.SelectionMode == 'Year') {
                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.StartDate.setMonth(0, 1);
                dateSelection.StartDate.setDate(1);
            }
            if (dateSelection.SelectionMode == 'Month') {
                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.StartDate.setMonth(dateSelection.SelectedMonth, 1);
                dateSelection.StartDate.setDate(1);
            }
            if (dateSelection.SelectionMode == 'Quarter') {
                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.StartDate.setDate(1);
                dateSelection.StartDate.setMonth(dateSelection.SelectedQuarter * 3);
            }
            return dateSelection.StartDate;
        },
        getEndDate: function () {
            if (dateSelection.SelectionMode == 'Year') {
                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.EndDate.setMonth(11);
                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
            }
            if (dateSelection.SelectionMode == 'Month') {
                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.EndDate.setMonth(dateSelection.SelectedMonth, 1);
                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
            }
            if (dateSelection.SelectionMode == 'Quarter') {
                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
                dateSelection.EndDate.setMonth(dateSelection.SelectedQuarter * 3 + 2, 1);
                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
            }
            return dateSelection.EndDate;

        },
        getjsonData: function () {
            var sMode = dateSelection.SelectionMode;
            var sStartDate = dateSelection.getStartDate();
            var sEndDate = dateSelection.getEndDate();
            var jsonDataObj = {};
            var dateRangeData = []
            jsonDataObj.dateRangeData = dateRangeData;
            var temp = {
                "SelectionMode": sMode,
                "StartDate": sStartDate,
                "EndDate": sEndDate
            }
            jsonDataObj.dateRangeData.push(temp);
            var objMain = $("#reportDaterangeSelectionData");
            if (objMain != undefined) {
                $("#reportDaterangeSelectionData").val(JSON.stringify(jsonDataObj));
            }
        }
    };

    dateSelection.init();
    dateSelection.show();
    dateSelection.getjsonData();
    $('.classDateMode li a').click(function () {
        dateSelection.SelectionMode = $(this).text();
        dateSelection.show();
        dateSelection.getjsonData();
        $('.classDateMode li').removeClass('selectedDateMode');
        $(this).parent().addClass('selectedDateMode');

    });
    

});


//$(document).ready(function () {
//    //For DateSelection
//    var dateSelection = {
//        // SelectionMode: 'Year',
//        SelectionMode: 'Month',
//        LeftNavControl: $('#datePrev'),
//        RightNavControl: $('#dateNext'),
//        LabelControl: $('#dateFilter'),
//        StartDate: new Date(Date.now().getFullYear(), 0, 1),
//        EndDate: new Date(Date.now().getFullYear(), 11, 31),
//        SelectedYear: Date.now().getFullYear(),
//        SelectedMonth: Date.now().getMonth(),
//        SelectedQuarter: Math.floor(Date.now().getMonth() / 3),
//        MonthNames: new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"),
//        MonthAbbreviations: new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"),
//        Quarters: new Array("Q1", "Q2", "Q3", "Q4"),
//        LeftClick: function () {
//            if (dateSelection.SelectionMode == 'Year') {
//                dateSelection.SelectedYear -= 1;
//            }
//            if (dateSelection.SelectionMode == 'Month') {
//                if (dateSelection.SelectedMonth == 0) {
//                    dateSelection.SelectedMonth = 11;
//                    dateSelection.SelectedYear -= 1;
//                }
//                else {
//                    dateSelection.SelectedMonth -= 1;
//                }
//            }
//            if (dateSelection.SelectionMode == 'Quarter') {
//                if (dateSelection.SelectedQuarter == 0) {
//                    dateSelection.SelectedQuarter = 3;
//                    dateSelection.SelectedYear -= 1;
//                }
//                else {
//                    dateSelection.SelectedQuarter -= 1;
//                }
//            }

//            dateSelection.show();
//            dateSelection.getjsonData();

//        },
//        RightClick: function () {
//            if (dateSelection.SelectionMode == 'Year') {
//                dateSelection.SelectedYear += 1;
//            }
//            if (dateSelection.SelectionMode == 'Month') {
//                if (dateSelection.SelectedMonth == 11) {
//                    dateSelection.SelectedMonth = 0;
//                    dateSelection.SelectedYear += 1;
//                }
//                else {
//                    dateSelection.SelectedMonth += 1;
//                }
//            }
//            if (dateSelection.SelectionMode == 'Quarter') {
//                if (dateSelection.SelectedQuarter == 3) {
//                    dateSelection.SelectedQuarter = 0;
//                    dateSelection.SelectedYear += 1;
//                }
//                else {
//                    dateSelection.SelectedQuarter += 1;
//                }
//            }

//            dateSelection.show();
//            dateSelection.getjsonData();
//        },
//        init: function () {
//            dateSelection.LeftNavControl.bind('click', dateSelection.LeftClick);
//            dateSelection.RightNavControl.bind('click', dateSelection.RightClick);
//        },

//        show: function () {
//            if (dateSelection.SelectionMode == 'Year') {
//                dateSelection.LabelControl.val('Jan - Dec ' + dateSelection.SelectedYear);
//            }
//            if (dateSelection.SelectionMode == 'Month') {
//                dateSelection.LabelControl.val(dateSelection.MonthNames[dateSelection.SelectedMonth] + ' ' + dateSelection.SelectedYear);
//            }
//            if (dateSelection.SelectionMode == 'Quarter') {
//                dateSelection.LabelControl.val(dateSelection.Quarters[dateSelection.SelectedQuarter] + ' ' + dateSelection.SelectedYear);
//            }
//            //alert(dateSelection.getStartDate());
//            //alert(dateSelection.getEndDate());
//        },
//        getStartDate: function () {
//            if (dateSelection.SelectionMode == 'Year') {
//                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.StartDate.setMonth(0, 1);
//                dateSelection.StartDate.setDate(1);
//            }
//            if (dateSelection.SelectionMode == 'Month') {
//                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.StartDate.setMonth(dateSelection.SelectedMonth, 1);
//                dateSelection.StartDate.setDate(1);
//            }
//            if (dateSelection.SelectionMode == 'Quarter') {
//                dateSelection.StartDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.StartDate.setDate(1);
//                dateSelection.StartDate.setMonth(dateSelection.SelectedQuarter * 3);
//            }
//            return dateSelection.StartDate;
//        },
//        getEndDate: function () {
//            if (dateSelection.SelectionMode == 'Year') {
//                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.EndDate.setMonth(11);
//                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
//            }
//            if (dateSelection.SelectionMode == 'Month') {
//                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.EndDate.setMonth(dateSelection.SelectedMonth, 1);
//                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
//            }
//            if (dateSelection.SelectionMode == 'Quarter') {
//                dateSelection.EndDate.setFullYear(dateSelection.SelectedYear);
//                dateSelection.EndDate.setMonth(dateSelection.SelectedQuarter * 3 + 2, 1);
//                dateSelection.EndDate.setDate(dateSelection.EndDate.getDaysInMonth());
//            }
//            return dateSelection.EndDate;
       
//        },
//        getjsonData: function () {
//            var sMode = dateSelection.SelectionMode;
//            var sStartDate = dateSelection.getStartDate();
//            var sEndDate = dateSelection.getEndDate();
//            var jsonDataObj = {};
//            var dateRangeData = []
//            jsonDataObj.dateRangeData = dateRangeData;
//            var temp={
//                "SelectionMode": sMode,
//                "StartDate": sStartDate,
//                "EndDate": sEndDate
//            }
//            jsonDataObj.dateRangeData.push(temp);           
//            var objMain = $("#reportDaterangeSelectionData");
//            if (objMain != undefined) {
//                $("#reportDaterangeSelectionData").val(JSON.stringify(jsonDataObj));
//            }
//        }
//    };

//    dateSelection.init();
//    dateSelection.show();
//    dateSelection.getjsonData();
//    $('.classDateMode li a').click(function () {
//        dateSelection.SelectionMode = $(this).text();
//        dateSelection.show();
//        dateSelection.getjsonData();
//        $('.classDateMode li').removeClass('selectedDateMode');
//        $(this).parent().addClass('selectedDateMode');
        
//    });
//    //$('#Show').click(function () {
//    //   alert('Start Date: ' + dateSelection.getStartDate() + '\nEnd Date:' + dateSelection.getEndDate());
//    //    //var obj = { "SelectionMode": dateSelection.SelectionMode, "StartDate": dateSelection.getStartDate(), "EndDate": dateSelection.getEndDate() };
//    //    //$("#reportDaterangeSelectionData").val(obj);
//    //});
   
//    //(function ($) {
//    //    $.fn.JqueryFunction = function () {
//    //        alert('Hello, This jquery function called from angular');
//    //        var obj = { "SelectionMode": dateSelection.SelectionMode, "StartDate": dateSelection.getStartDate(), "EndDate": dateSelection.getEndDate() };
//    //        return obj;
//    //    };
//    //})(jQuery);
//});