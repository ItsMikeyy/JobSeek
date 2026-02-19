$(document).ready(() => {
    $("#get-started").on("click", (e) => {
        e.preventDefault();
        if ($("#email-form").valid()) {
            $("#email-form-container").hide();
            $("#register-form").show();
        }
        
    });
})