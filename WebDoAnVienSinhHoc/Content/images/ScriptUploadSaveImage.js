function ShowImgPreview(imgUploader, imgPreview) {
    if (imgUploader.files && imgUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(imgPreview).attr('src', e.target.result);
        }
        reader.readAsDataURL(imgUploader.files[0]);
    }
}