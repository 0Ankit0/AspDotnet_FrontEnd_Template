function AjaxCall(url, method="POST", data, successCallback, errorCallback) {
    var contentType;
    var processData;
    
    if (data === null || typeof data === "string") {
        // For null or string data, let the browser set the content type
        contentType = false;
        processData = true; // Allow jQuery to handle the data
    } else if (data instanceof Blob || data instanceof File) {
        // For file uploads, let the browser set the content type
        contentType = false;
        processData = false; // Prevent jQuery from trying to serialize the file
    } else {
        // For non-null, non-string, non-file data, assume JSON
        contentType = "application/json;charset=utf-8";
        processData = true; // Allow jQuery to serialize the data
    }
    $.ajax({
        url: url,
        type: method,
        data: data,
        contentType: contentType,
        processData: processData,
        success: function (response) {
            if (successCallback) {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (errorCallback) {
                errorCallback(error);
            }
        }
    });
}
function AjaxCallWithLoader(url, method="POST", data, successCallback, errorCallback) {
    var contentType;
    var processData;
    
    if (data === null || typeof data === "string") {
        // For null or string data, let the browser set the content type
        contentType = false;
        processData = true; // Allow jQuery to handle the data
    } else if (data instanceof Blob || data instanceof File) {
        // For file uploads, let the browser set the content type
        contentType = false;
        processData = false; // Prevent jQuery from trying to serialize the file
    } else {
        // For non-null, non-string, non-file data, assume JSON
        contentType = "application/json;charset=utf-8";
        processData = true; // Allow jQuery to serialize the data
    }
    $.ajax({
        url: url,
        type: method,
        data: data,
        contentType: contentType,
        processData: processData,
        beforeSend: function () {
            Swal.fire({
                html: '<div class="loader" id="loader-6">' +
                    '<span></span>' +
                    '<span></span>' +
                    '<span></span>' +
                    '<span></span>' +
                    '</div>' +
                    '<div>' +
                    '<p style="color:#fff; font-size:20px;">PLEASE WAIT...</p>' +
                    '</div>',
                background: 'unset',
                allowOutsideClick: false,
                showConfirmButton: false,
            });
        },
        success: function (response) {
            if (successCallback) {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (errorCallback) {
                errorCallback(error);
            }
        }
    });
}
