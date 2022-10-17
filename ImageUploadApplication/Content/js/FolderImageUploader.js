const MAX_IMAGE_WIDTH = 320;
const MAX_IMAGE_HEIGHT = 180;
const MIME__IMAGE_TYPE = "image/jpeg";
const IMAGE_QUALITY = 0.7;

const input_file = document.querySelector(".folder-photo-add");
input_file.onchange = function (ev) {

    const length = ev.target.files.length;
    console.log(length);
    for (var i = 0; i < length; i++) {
        const file = ev.target.files[i]; // get the file
        const blobURL = URL.createObjectURL(file);
        const img = new Image();
        img.src = blobURL;
        img.onerror = function () {
            URL.revokeObjectURL(this.src);
            console.log(this.src);
            // Handle the failure properly
            console.log("Cannot load image");
        };
        img.onload = function () {
            URL.revokeObjectURL(this.src);
            const [newWidth, newHeight] = calculateSize(img, MAX_IMAGE_WIDTH, MAX_IMAGE_HEIGHT);
            const canvas = document.createElement("canvas");
            canvas.width = newWidth;
            canvas.height = newHeight;
            const ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0, newWidth, newHeight);
            canvas.toBlob(
                (blob) => {
                    // Handle the compressed image. es. upload or save in local state
                    displayInfo('Original file', file);
                    displayInfo('Compressed file', blob);
                    var reader = new FileReader();
                    reader.readAsDataURL(blob);
                    reader.onloadend = function () {
                        var base64data = reader.result;
                        console.log(base64data);
                        $('#folder_images').prepend('<div class="col-lg-3 col-md-3 mb-2 col-xs-6 thumb"><a class= "thumbnail" href = "javascript:void(0)"  data-image - id="" data-toggle="modal" data - title="" data - target="#image-gallery" ><span class="close" onclick = "remove(this)"  >&times;</span><img class="img-thumbnail folder_img" src=' + base64data + ' alt="Another alt text"></a></div>');
                    }
                },
                MIME__IMAGE_TYPE,
                IMAGE_QUALITY
            );
            console.log(canvas);

        };
    }
};

function calculateSize(img, maxWidth, maxHeight) {
    let width = img.width;
    let height = img.height;

    // calculate the width and height, constraining the proportions
    if (width > height) {
        if (width > maxWidth) {
            height = Math.round((height * maxWidth) / width);
            width = maxWidth;
        }
    } else {
        if (height > maxHeight) {
            width = Math.round((width * maxHeight) / height);
            height = maxHeight;
        }
    }
    return [width, height];
}

// Utility functions for demo purpose

function displayInfo(label, file) {
    const p = document.createElement('p');
    p.innerText = `${label} - ${readableBytes(file.size)}`;

}

function readableBytes(bytes) {
    const i = Math.floor(Math.log(bytes) / Math.log(1024)),
        sizes = ['B', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    return (bytes / Math.pow(1024, i)).toFixed(2) + ' ' + sizes[i]
}