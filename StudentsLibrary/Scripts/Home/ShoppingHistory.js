var ShoppingHistory = {
    Allpurchases:"",
    DrawShoppingHisory: function (Purchases) {
        for (var i = 0; i < Purchases[0].length; i++) {
            var script = "";
            script += "<input type='text' style='display:none'  id='Clause_Contract_Sn'>" +
                "<div class='accordion-item'><h2 class='accordion-header' id='kt_accordion_1_header_" + i + "'>" +
                "<button class='accordion-button fs-4 fw-semibold collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#kt_accordion_1_body_" + i + "' aria-expanded='false' aria-controls='kt_accordion_1_body_" + i + "'> عملية شراء برقم طلب (" + Purchases[0][i].Purchase_No + ") و تاريخ (" + Purchases[0][i].PurchaseDate + ") واجمالى سعر (" + Purchases[0][i].Total_Price + " kw)</button></h2 > <div id='kt_accordion_1_body_" + i + "' class='accordion-collapse collapse' aria-labelledby='kt_accordion_1_header_1' data-bs-parent='#kt_accordion_1'><div class='accordion-body'>";
            script += "<div class='table-responsive'>" +
                "<table class='table'>" +
                "<thead>" +
                "<tr>" +
                "<th scope='col' class='h5'><h5>غلاف الكتاب</h5></th>" +
                "<th scope='col'><h5>اسم الكتاب</h5></th>" +
                "<th scope='col'><h5>الكمية</h5></th>" +
                "<th scope='col'><h5>سعر النسخة الواحدة</h5></th>" +
                "<th scope='col'><h5>سعر باقى النسخ</h5></th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            for (var k = 0; k < Purchases[i + 1].length; k++) {
                script += "<tr BookId = " + Purchases[i + 1][k].Book_Id + ">" +
                    "<th scope = 'row'>" +
                    "<div class='d-flex align-items-center' style='justify-content: center;'>" +
                    "<img src='" + Purchases[i + 1][k].ItemImage +"' class='img-fluid rounded-3' style='width: 120px;' alt='Book'>" + "</div>" +
                    "</th>" +
                    "<td class='align-middle' style='text-align: center;'>" +
                    "<p class='mb-0' style='font-weight: 500;'>" + Purchases[i + 1][k].ItemName + "</p>" +
                    "</td>" +
                    "<td class='align-middle'>" +
                    " <div class='d-flex flex-row' style='align-items: center;justify-content: center;'>" +
                    "<p class='mb-0' style='font-weight: 500'>" + Purchases[i + 1][k].Book_Quantity + "</p>" +
                    "</div> " +
                    "</td>" +
                    "<td class='align-middle'>" +
                    "<p class='mb-0' style='font-weight: 500'>" + Purchases[i + 1][k].Book_Price + "</p>" +
                    "</td>" +
                    "<td class='align-middle'>" +
                    "<p class='mb-0' style='font-weight: 500'>" + Purchases[i + 1][k].Book_Price_Before_Dis + "</p>" +
                    "</td>" +
                    "</tr>";
            }
            script+= "</tbody>" +
                "</table> <div class='row mb-6'>" +
                "<h3 class='col-lg-4 '> حالة الطلب :  <label>" + Purchases[0][i].DeliveryStatus +"</label></h3>" +
                "</div></div>";
            document.getElementById("dv_ShoppingHistory").innerHTML += script
        }


    }

}
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "ShoppingHistory/GetAllpurchases",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        cache: false,
        success: function (result) {
            ShoppingHistory.Allpurchases = result;
        }
    });
    ShoppingHistory.DrawShoppingHisory(Object.values(ShoppingHistory.Allpurchases))
})
