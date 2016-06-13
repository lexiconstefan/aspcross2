var userController = {

    getUserAccountList: function () {
        alert('hello');
        var jsonData = {municipality:'bromölla'};
        //var jsonData = this.getFilterValue();
        $.ajax({
            type: 'POST',
            url: "UserAccounts/QueryIndex/",
            data: JSON.stringify(jsonData),
            success: function (returnPayload) {
                console && console.log("request succeeded");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console && console.log("request failed");
            },
            dataType: "xml",
            contentType: "application/json",
            processData: false,
            async: false
        });
    },
    
    getFilterValue: function () {
        return JSON.stringify($('#form').serialize());
    }
};