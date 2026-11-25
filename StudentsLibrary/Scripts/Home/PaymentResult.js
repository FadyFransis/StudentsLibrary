var paymentResult = {
   
    
    FinishShop: function () {
        
            $.ajax({
                type: "POST",
                url: "PaymentResult/FinishTransaction",
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
                        Notification_success('تم انهاء عملية الشراء بنجاح', 'true');
                        localStorage.clear();
                        return result;
                    }
                    

                }
            });
        
    }
}
$(document).ready(function () {
    paymentResult.FinishShop();
})