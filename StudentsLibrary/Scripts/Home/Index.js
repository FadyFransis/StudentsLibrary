var PurchaseBook = {
    AllBooks: "",
    MinRow: 1,
    MaxRow: 50,
    SelectedBook: "",
    GetAllBooks: function (SearchObj) {
        $.ajax({
            type: "POST",
            url: "Home/GetAllBooks",
            data: JSON.stringify(SearchObj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                PurchaseBook.AllBooks = result;
                return result;
            }
        });

    },
    DrawBookCard: function () {
        for (var i = 0; i < PurchaseBook.AllBooks.length; i++) {
            var imageUrl =  PurchaseBook.AllBooks[i].PIC_PATH; // Adjust the property name as per your data structure
            var Script = "<div class='col-12 col-sm-8 col-md-6 col-lg-3' style='margin-bottom:15px'>" +
                "<div class='card'>" +
                "<img class='card-img' src='" + imageUrl + "' alt='" + PurchaseBook.AllBooks[i].ItemName + "' >" +
                "<div class='card-body'>" +
                "<h4 class='card-title'>" + PurchaseBook.AllBooks[i].ItemName + "</h4>" +
                "<h4 class='card-title'>  كود الكتاب: " + PurchaseBook.AllBooks[i].ItemId + "</h4>" +
                "<h6 class='card-subtitle mb-2 text-muted'>" + PurchaseBook.AllBooks[i].Publisher + "</h6>" +
                "<p class='card-text'>" +
                "" + PurchaseBook.AllBooks[i].Author + "" +
                "</p>" +
                "<div class='buy d-flex'>" +
                "<div class='price text-success' style='margin-left:5px'><h6 class='mt-4' style='color:red;text-decoration:line-through;'> K.W " + PurchaseBook.AllBooks[i].UnitPrice + "</h5></div>" +
                "<div class='price text-success'><h5 class='mt-4'> K.W " + PurchaseBook.AllBooks[i].UnitPriceAfterDiscount + "</h5></div>" +
                "</div>" +
                "<button class='cart-button' style='width:100%' onClick='PurchaseBook.cartClick(event)' BookId=" + PurchaseBook.AllBooks[i].ItemId + " BookName='" + PurchaseBook.AllBooks[i].ItemName + "' PriceBeforeDis='" + PurchaseBook.AllBooks[i].UnitPrice + "' BookPrice='" + PurchaseBook.AllBooks[i].UnitPriceAfterDiscount + "' BookImage='" + imageUrl + "'><span class='add-to-cart'>أضف الى العربة</span>" +
                "<span class='added'>تمت الاضافة</span>" +
                "<i class='fas fa-shopping-cart'></i>" +
                "<i class='fas fa-box'></i></button >" +
                "</div>" +
                "</div>" +
                "</div>";
            document.getElementById("CardContaainer").innerHTML += Script;
        }
    },
    GetSearchObject: function () {
        var SearchObj = {};
        SearchObj.bookName = document.getElementById("txt_bookName").value;
        SearchObj.BookAuthor = document.getElementById("txt_bookAuthor").value;
        SearchObj.BookPublisher = document.getElementById("txt_bookPublisher").value;
        SearchObj.BookId = document.getElementById("txt_bookId").value;
        SearchObj.StoreId = document.getElementById("ddl_DeliveryPlace").value;
        SearchObj.college = document.getElementById("ddl_college").value;
        SearchObj.MinRow = 0;
        SearchObj.MaxRow = 50;
        PurchaseBook.MinRow = 0;
        PurchaseBook.MaxRow = 50;
        return SearchObj;

    },
    search: function () {
        var SearchObj = PurchaseBook.GetSearchObject();
        PurchaseBook.GetAllBooks(SearchObj);
        document.getElementById("CardContaainer").innerHTML = ""
        PurchaseBook.DrawBookCard();
    },
    ShowMore: function () {
        var SearchObj = PurchaseBook.GetSearchObject();
        PurchaseBook.MinRow = PurchaseBook.MinRow + 50
        PurchaseBook.MaxRow = PurchaseBook.MaxRow + 50
        SearchObj.MinRow = PurchaseBook.MinRow;
        SearchObj.MaxRow = PurchaseBook.MaxRow;
        PurchaseBook.GetAllBooks(SearchObj);
        PurchaseBook.DrawBookCard();

    },
    cartClick: function (event) {
        debugger
        var SelectedBooks = [];
        var SelectedBook = event.target.closest("button");
        var book = {}
        book.BookId = SelectedBook.getAttribute("BookId");
        book.BookName = SelectedBook.getAttribute("BookName");
        book.BookPrice = SelectedBook.getAttribute("BookPrice");
        book.BookPriceBeforeDis = SelectedBook.getAttribute("PriceBeforeDis");
        book.BookQuantity = 1;
        book.BookImage = SelectedBook.getAttribute("BookImage");
        if (localStorage.Cart == undefined) {
            SelectedBooks.push(book)
            localStorage.setItem('Cart', JSON.stringify(SelectedBooks))
        }
        else {
            var Cart = JSON.parse(localStorage.Cart);
            var IsSingleCopy = document.querySelector(`[id$='IsSingleCopy']`).value;
            for (var i = 0; i < Cart.length; i++) {
                if (Cart[i].BookId == SelectedBook.getAttribute("BookId")) {
                    if (IsSingleCopy == "0") {
                        Cart[i].BookQuantity += 1;
                        localStorage.setItem('Cart', JSON.stringify(Cart));
                    }
                    event.target.closest("button").classList.add('clicked')
                    return;
                }
            }
            Cart.push(book)
            localStorage.setItem('Cart', JSON.stringify(Cart));
        }


        event.target.closest("button").classList.add('clicked')

    },
    getSettings: function () {
        $.ajax({
            type: "POST",
            url: "Home/GetSettings",
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                PurchaseBook.Settings = result;
                document.querySelector(`[id$='IsSingleCopy']`).value = result[0].Is_One_Copy;
            }
        });
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
                PurchaseBook.DrawDeliveryPlaces(result);
            }
        });

    },
    DrawDeliveryPlaces: function (Data) {
        var DDL = document.getElementById("ddl_DeliveryPlace");
        for (var i = 0; i < Data.length; i++) {
            DDL.innerHTML += "<option value='" + Data[i].StoreId + "'>" + Data[i].StoreName + "</option>"
        }

    },
    getcollege: function () {
        $.ajax({
            type: "POST",
            url: "ShoppingCart/Getcollege",
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            cache: false,
            success: function (result) {
                PurchaseBook.Drawddl_college(result);
            }
        });

    },
    Drawddl_college: function (Data) {
        var DDL = document.getElementById("ddl_college");
        for (var i = 0; i < Data.length; i++) {
            DDL.innerHTML += "<option value='" + Data[i].org_sn + "'>" + Data[i].org_Name + "</option>"
        }

    },
   


}

$(document).ready(function () {
    var SearchObj = {};
    PurchaseBook.getDeliveryPlaces();
    PurchaseBook.getcollege();
    SearchObj.MinRow = PurchaseBook.MinRow;
    SearchObj.MaxRow = PurchaseBook.MaxRow;
    PurchaseBook.GetAllBooks(SearchObj);
    PurchaseBook.getSettings();
    PurchaseBook.DrawBookCard();
    $('#kt_modal_scrollable_3').modal({ backdrop: 'static', keyboard: false })
    document.getElementById("MainInfo").innerHTML = PurchaseBook.Settings[0].Info_Home_Page
    document.getElementById("OpenInfo").click();
})

