$(function () {
    const maxSize = 5 * 1024 * 1024; // 5 MB
    const allowedTypes = ["application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"];
    const fileError = $("span[data-valmsg-for='UploadFileDto.File']");

    $("#UploadFileDto_File").on("change", function () {
        const file = $(this)[0].files[0];

        // Clear any previous error messages
        fileError.text("").removeClass("field-validation-error").addClass("field-validation-valid");
        debugger
        if (file) {
            // Check if the file type is PDF or DOCX
            if (!allowedTypes.includes(file.type)) {
                fileError.text("Only PDF and DOCX files are allowed.")
                    .removeClass("field-validation-valid")
                    .addClass("field-validation-error");
                $(this).val("")
                return false;
            }

            // Check if the file size exceeds the 5 MB limit
            if (file.size > maxSize) {
                fileError.text("File is too large. Maximum size is 5 MB.")
                    .removeClass("field-validation-valid")
                    .addClass("field-validation-error");
                $(this).val("")
                return false;
            }
        }
    });


    $("form").on("submit", function (e) {
        const file = $("#UploadFileDto_File")[0].files[0];

        if (!file || file.size > maxSize || file.type !== "application/pdf") {
            e.preventDefault(); // Prevent form submission
            fileError.text("Please ensure the file is a PDF and under 10 MB.")
                .removeClass("field-validation-valid")
                .addClass("field-validation-error");
        }
    });

});