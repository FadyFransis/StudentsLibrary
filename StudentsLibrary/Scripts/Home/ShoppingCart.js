var ShoppingCart = {
    FinidhShop: function () {
        debugger
        if (ShoppingCart.validation()) {
            $.ajax({
                type: "POST",
                url: "ShoppingCart/ValidationFinishShop",
                data: JSON.stringify({
                    "Params": localStorage.Cart,
                    "DeliveryPlace": document.getElementById("ddl_DeliveryPlace").value,
                    "DeliveryDate": document.getElementById("kt_daterangepicker_3").value,
                    "DeliveryHour": document.getElementById("ddl_DeliverHour").value,
                    "TotalPrice": document.getElementById("txt_PriceAfterDiscout").innerText
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                cache: false,
                success: function (result) {
                    if (result == "1") {
                        localStorage.setItem('DeliveryPlace', document.getElementById("ddl_DeliveryPlace").value);
                        localStorage.setItem('DeliveryDate', document.getElementById("kt_daterangepicker_3").value);
                        localStorage.setItem('DeliveryHour', document.getElementById("ddl_DeliverHour").value);
                        localStorage.setItem('TotalPrice', document.getElementById("txt_PriceAfterDiscout").innerText);
                        localStorage.setItem('TotalPriceBefoteDis', document.getElementById("txt_TotalPrice").innerText);
                        window.location.href =  "../OnlineBookStore/FinishShop";
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
    },

    FinidhShop2: function () {
        debugger;
        var url = "https://pprdonlinegate.paaet.edu.kw/frmPay.aspx" +
            "ApplicationCode=DYYDOQQS" +
            "&ServiceCode=NFFQXNAR" +
            "&Action=1" +
            "&Amount=74.000" +
            "&Currency=414" +
            "&Language=ARA" +
            "&ResponseURL=ShoppingCart/FinishShop" +
            "&ErrorURL=ShoppingCart/FinishShop" +
            "&TransactionID=1" +
            "&CID=a@gmail.com" +
            "&CN=CUSTOMERNAME" +
            "&UDF1=USERDEFINEDFIELD1" +
            "&UDF2=USERDEFINEDFIELD2" +
            "&UDF3=USERDEFINEDFIELD3" +
            "&UDF4=USERDEFINEDFIELD4";

        var formdata = new FormData();
        formdata.append("ApplicationCode", "DYYDOQQS");
        formdata.append("ServiceCode", "NFFQXNAR");
        formdata.append("Action", "1");
        formdata.append("Amount", "74.000");
        formdata.append("Currency", "414");
        formdata.append("Language", "ARA");
        formdata.append("ResponseURL", "ShoppingCart/FinishShop");
        formdata.append("ErrorURL", "ShoppingCart/FinishShop");
        formdata.append("TransactionID", "1");
        formdata.append("CID", "a@gmail.com");
        formdata.append("CN", "CUSTOMERNAME");
        formdata.append("UDF1", "USERDEFINEDFIELD1");
        formdata.append("UDF2", "USERDEFINEDFIELD2");
        formdata.append("UDF3", "USERDEFINEDFIELD3");
        formdata.append("UDF4", "USERDEFINEDFIELD4");
        if (ShoppingCart.validation()) {
            $.ajax({
                type: "POST",
                url: "https://pprdonlinegate.paaet.edu.kw",
                data: formdata,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                cache: false,
                success: function (result) {
                    if (result == "1") {
                        localStorage.setItem('DeliveryPlace', document.getElementById("ddl_DeliveryPlace").value);
                        localStorage.setItem('DeliveryDate', document.getElementById("kt_daterangepicker_3").value);
                        localStorage.setItem('DeliveryHour', document.getElementById("ddl_DeliverHour").value);
                        localStorage.setItem('TotalPrice', document.getElementById("txt_PriceAfterDiscout").innerText);
                        localStorage.setItem('TotalPriceBefoteDis', document.getElementById("txt_TotalPrice").innerText);
                        window.location.href = "/FinishShop";
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
    },
    validation: function () {
        if (document.getElementById("ddl_DeliveryPlace").value == "-1") {
            Notification_success('يرجى اختيار مكان التسليم', 'false');
            return false;
        }
        if (ShoppingCart.isDateVlide(new Date(document.getElementById("kt_daterangepicker_3").value)) == 0) {
            return false;
        }
        return true;
    },
    compareDates: function (currentDate, SelectedDate) {
        currentDate = new Date(currentDate).getTime();
        SelectedDate = new Date(SelectedDate).getTime();

        if (currentDate <= SelectedDate) {
            return 1
        } else (currentDate >= SelectedDate)
        return 0
    },

    ShowCart: function () {
        if (localStorage.Cart == undefined) {
            document.getElementById("EmptyCartDetails").style.display = ""
            document.getElementById("CartDivDetails").style.display = "none"
        }
        else {
            document.getElementById("EmptyCartDetails").style.display = "none"
            document.getElementById("CartDivDetails").style.display = ""
        }
        if (localStorage.Cart != undefined) {
            var Cart = JSON.parse(localStorage.Cart);
            if (Cart.length == 0) {
                document.getElementById("EmptyCartDetails").style.display = ""
                document.getElementById("CartDivDetails").style.display = "none"

            }
            else {
                document.getElementById("tbody_cart_Details").innerHTML = ""
                var IsSingleCopy = ShoppingCart.Settings[0].Is_One_Copy;
                var price = 0;
                for (var i = 0; i < Cart.length; i++) {
                    var Script = "";
                    Script += "<tr BookId = " + Cart[i].BookId + ">" +
                        "<th scope = 'row'>" +
                        "<div class='d-flex align-items-center' style='justify-content: center;'>" +
                        "<img src='" + Cart[i].BookImage+"' class='img-fluid rounded-3' style='width: 120px;' alt='Book'>" + "</div>" +
                        "</th>" +
                        "<td class='align-middle' style='text-align: center;'>" +
                        "<p class='mb-0' style='font-weight: 500;'>" + Cart[i].BookName + "</p>" +
                        "</td>" +
                        "<td class='align-middle'>" +
                        " <div class='d-flex flex-row' style='align-items: center;justify-content: center;'>";
                    if (IsSingleCopy == "0") {
                        Script += "<button type='button' class='btn btn-link px-2'" +
                            "onclick ='ShoppingCart.StepDown(this);ShoppingCart.ChangeQuantity(" + Cart[i].BookId + ",this.parentNode.querySelector(`input[type = number]`).value)' > " +
                            "<i class='fas fa-minus'></i>" +
                            "</button>" +
                            " <input id='form1' disabled onChange='ShoppingCart.ChangeQuantity(" + Cart[i].BookId + ",this.parentNode.querySelector(`input[type = number]`).value)'  min='0' name='quantity' value='" + Cart[i].BookQuantity + "' type='number' class='form-control form-control-sm'style='width: 50px' />" +
                            " <button type='button' class='btn btn-link px-2' onclick='this.parentNode.querySelector(`input[type=number]`).stepUp();ShoppingCart.ChangeQuantity(" + Cart[i].BookId + ",this.parentNode.querySelector(`input[type = number]`).value)'>" +
                            "<i class='fas fa-plus'></i>" +
                            " </button>";
                    }
                    else {
                        Script += "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookQuantity + "</p>"
                    }
                    Script += "</div> " +
                        "</td>";
                    if (ShoppingCart.Settings[0].IsStudent == "1") {
                        Script += "<td class='align-middle'>" +
                            "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookPrice + "</p>" +
                            "</td>";
                    }
                        Script += "<td class='align-middle'>" +
                            "<p class='mb-0' style='font-weight: 500'>" + Cart[i].BookPriceBeforeDis + "</p>" +
                            "</td>";
                    
                    Script+=   "<td class='align-middle'>" +
                        "<button class='btn btn-danger rounded - 0' onclick='ShoppingCart.Delete(event," + Cart[i].BookId + ")'><i class='fa-solid fa-trash'></i></button>" +
                        "</td>" +
                        "</tr>";

                    document.getElementById("tbody_cart_Details").innerHTML += Script;
                }
                ShoppingCart.SetTotalPrice()
            }
        }
    },
    StepDown: function (ele) {
        if (ele.parentNode.querySelector(`input[type=number]`).value > 1)
            ele.parentNode.querySelector(`input[type=number]`).stepDown();
    },
    SetTotalPrice: function () {
        var price = 0;
        var discout = 0;
        var Cart = JSON.parse(localStorage.Cart);
        var supportedBooks = "";
        var NotsupportedBooks = "";
        for (var i = 0; i < Cart.length; i++) {
            price += parseFloat(Cart[i].BookPriceBeforeDis) * Cart[i].BookQuantity;
            if (ShoppingCart.Settings[0].IsStudent == "1" && Cart[i].IsSupported) {
                discout += (parseFloat(Cart[i].BookPrice) * 1) + parseFloat(Cart[i].BookPriceBeforeDis) * (Cart[i].BookQuantity - 1);
                supportedBooks += "( "+ Cart[i].BookName + " )"
            }
            else {
                discout += parseFloat(Cart[i].BookPriceBeforeDis) * Cart[i].BookQuantity;
                NotsupportedBooks += "( "+ Cart[i].BookName + " ) "
            }
        }
        var Notes = "";
        if (supportedBooks != "") {
            Notes += "لديك دعم على نسخة واحدة من كتب " + supportedBooks +" ";
        }
        if (NotsupportedBooks != "") {
            if (supportedBooks == "")
                Notes += "تم اخذ نسخة مدعومه بالفعل من  كتب  " + NotsupportedBooks + " لذلك لن يتم احتساب دعم لها  ";
            else
               Notes += "<br> و تم اخذ نسخة مدعومه بالفعل من  كتب  " + NotsupportedBooks + " لذلك لن يتم احتساب دعم لها";

        }
        document.getElementById("txt_notes").innerHTML = Notes;
        document.getElementById("txt_TotalPrice").innerText = ShoppingCart.setPrice(price);
        if (ShoppingCart.Settings[0].IsStudent == "1") {
            document.getElementById("txt_PriceAfterDiscout").innerText = ShoppingCart.setPrice(discout);
            document.getElementById("SupportedCopy").style.display = "";
            document.getElementById("PriceOtherCopies").innerHTML = "<h5>سعر باقى النسخ</h5>";
        }
        else {
            document.getElementById("txt_PriceAfterDiscout").innerText = ShoppingCart.setPrice(price);
            document.getElementById("SupportedCopy").style.display = "none";
            document.getElementById("PriceOtherCopies").innerHTML = "<h5>السعر  </h5>";
        }

    },
    setPrice: function (price) {
        var EditedPrice = "";
       var p  = price.toString().split(".");
        if (p.length > 1) {
            if (p[1].length == 1)
                EditedPrice = price.toString() + "00"
            else if (p[1].length == 2)
                EditedPrice = price.toString() + "0"
            else if (p[1].length >= 3)
                EditedPrice = p[0] +"."+ p[1].substring(0, 3);
        }
        else {
            EditedPrice = price.toString() + ".000"
        }
        return EditedPrice;
    },
    ChangeQuantity: function (Id, Quantity) {
        var Cart = JSON.parse(localStorage.Cart);
        for (var i = 0; i < Cart.length; i++) {
            if (Cart[i].BookId == Id) {
                Cart[i].BookQuantity = Quantity
                localStorage.setItem('Cart', JSON.stringify(Cart));
                ShoppingCart.SetTotalPrice()
                return;
            }
        }
    },
    Delete: function (event, Id) {
        var Cart = JSON.parse(localStorage.Cart);
        for (var i = 0; i < Cart.length; i++) {
            if (Cart[i].BookId == Id) {
                Cart.splice(i, 1);
                localStorage.setItem('Cart', JSON.stringify(Cart));
            }
        }
        var SelectedRow = event.target.closest("tr");
        SelectedRow.remove();
        if (Cart.length == 0) {
            document.getElementById("EmptyCartDetails").style.display = ""
            document.getElementById("CartDivDetails").style.display = "none"
        }
        ShoppingCart.SetTotalPrice()

    },
    getDeliveryPlaces: function () {
        $.ajax({
            type: "POST",
            url: "ShoppingCart/GetDeliveryPlaces",
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                ShoppingCart.DrawDeliveryPlaces(result);
            }
        });

    },
    DrawDeliveryPlaces: function (Data) {
        var DDL = document.getElementById("ddl_DeliveryPlace");
        for (var i = 0; i < Data.length; i++) {
            DDL.innerHTML += "<option value='" + Data[i].StoreId + "'>" + Data[i].StoreName + "</option>"
        }

    },
    getSettings: function () {
        $.ajax({
            type: "POST",
            url: "ShoppingCart/GetSettings",
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                ShoppingCart.Settings = result;
            }
        });
    },
    CheckIsBookSuported: function () {
        $.ajax({
            type: "POST",
            url: "ShoppingCart/IsBookSupported",
            data: JSON.stringify({
                "Params": localStorage.Cart,               
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                var Cart = JSON.parse(localStorage.Cart);
                for (var i = 0; i < Cart.length; i++) {
                    debugger
                    Cart[i].IsSupported = parseInt(result[i]) > 0 ? false : true;
                    localStorage.Cart = JSON.stringify(Cart);
                }
               
            }
        });
    },
    isDateVlide: function (StartDate) {
        var ValidDate = new Date();
            var Waiting = ShoppingCart.Settings[0].Waiting_Period
            ValidDate.setDate(ValidDate.getDate() + parseInt(Waiting))
            
            var IsValid = ShoppingCart.compareDates(ValidDate.getFullYear() + '/' + (ValidDate.getMonth() + 1) + '/' + ValidDate.getDate()
                , StartDate.getFullYear() + '/' + (StartDate.getMonth() + 1) + '/' + StartDate.getDate());
        if (IsValid == 0) {
            Notification_success('لا يمكن اختيار تاريخ التسليم قبل ' + Waiting + ' يوم من تاريخ اليوم', 'false')
            return IsValid;
        }
    }
}
$(document).ready(function () {
    ShoppingCart.getSettings();
    ShoppingCart.CheckIsBookSuported();
    ShoppingCart.getDeliveryPlaces();
    ShoppingCart.ShowCart();
    $("#kt_daterangepicker_3").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 2023,
        maxYear: parseInt(moment().format("YYYY"), 12),
        minDay:12
    }, function (start, end, label) {
            ShoppingCart.isDateVlide(start._d);
        
    });

})
