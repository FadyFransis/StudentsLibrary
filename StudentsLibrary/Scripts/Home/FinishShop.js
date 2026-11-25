var finishShop = {
    getSettings: function () {
        $.ajax({
            type: "POST",
            url: "FinishShop/GetSettings",
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                finishShop.Settings = result;
            }
        });
    },
    DrawTable: function () {
        if (localStorage.Cart != undefined) {
            var Cart = JSON.parse(localStorage.Cart);
           
                document.getElementById("tbody_cart_Details").innerHTML = ""
                for (var i = 0; i < Cart.length; i++) {
                    var Script = "";
                    Script += "<tr BookId = " + Cart[i].BookId + ">" +
                       
                        "<td class='align-middle' style='text-align: center;'>" +
                        "<p class='mb-0' style='font-weight: 500;'>" + Cart[i].BookName + "</p>" +
                        "</td>" +
                        "<td class='align-middle'>" +
                        " <div class='d-flex flex-row' style='align-items: center;justify-content: center;'>";
                  
                        Script += "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookQuantity + "</p>"
                    
                    Script += "</div> " +
                        "</td>";
                    if (finishShop.Settings[0].IsStudent == "1") {
                        Script += "<td class='align-middle'>" +
                            "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookPrice + "</p>" +
                            "</td>";
                    }
                        Script+=  "<td class='align-middle'>" +
                            "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookPriceBeforeDis + "</p>" +
                            "</td>"
                    
                    Script += "</tr>";
                    document.getElementById("tbody_cart_Details").innerHTML += Script;
                }
        }
        document.getElementById("MainInfo").innerText = finishShop.Settings[0].Second_CheckBox
        document.getElementById("dv_Terms").innerHTML += "<a href='#kt_modal_scrollable_3'  data-bs-toggle=modal data-bs-target =#kt_modal_scrollable_3 >" + finishShop.Settings[0].First_CheckBox + "</a>";
        finishShop.SetTotalPrice();
    },
    SetTotalPrice: function () {
        if (finishShop.Settings[0].IsStudent == "1") {
            document.getElementById("totalPrice").innerText = localStorage.getItem('TotalPrice');
            document.getElementById("SupportedCopy").style.display = "";
            document.getElementById("PriceOtherCopies").innerHTML = "<h5>سعر باقى النسخ</h5>";
        }
        else {
            document.getElementById("totalPrice").innerText = localStorage.getItem('TotalPriceBefoteDis');
            document.getElementById("SupportedCopy").style.display = "none";
            document.getElementById("PriceOtherCopies").innerHTML = "<h5>السعر  </h5>";
        }
        document.getElementById("totalPriceBeforerDis").innerText = localStorage.getItem('TotalPriceBefoteDis');

    },
    FinishShop: function () {
        if (!(document.getElementById("chk_Terms").checked)) {
            Notification_success("يرجى اختيار الشروط والاحكام", false)
        }
        else {
            $.ajax({
                type: "POST",
                url: "FinishShop/FinishShop",
                data: JSON.stringify({
                    "Params": localStorage.Cart,
                    "DeliveryPlace": localStorage.getItem('DeliveryPlace'),
                    "DeliveryDate": localStorage.getItem('DeliveryDate'),
                    "DeliveryHour": localStorage.getItem('DeliveryHour'),
                    "TotalPrice": localStorage.getItem('TotalPrice')
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                cache: false,
                success: function (result) {
                    if (result == "1") {
                        window.location.href = "../OnlineBookStore/FinishShop/processpayment"
                        //Notification_success('تم انهاء عملية الشراء بنجاح', 'true');
                        //localStorage.clear();
                        return result;
                    }
                    else if (result == "-2") {
                        Notification_success('الوقت والتاريخ المختارين مزدحمين يرجى اختيار ساعه او تاريخ مختلفين', 'false');
                    } else {
                        Notification_success('الكتاب(' + result + ' ) غير موجود فى المخزن المختار بتاريخ الاستلام المطلوب برجاء اختيار مخزن او تاريخ مختلف', 'false');
                    }

                }
            });
        }
    }
}
$(document).ready(function () {
    finishShop.getSettings();

    finishShop.DrawTable();
    $('#kt_modal_scrollable_3').modal({ backdrop: 'static', keyboard: false })  

})