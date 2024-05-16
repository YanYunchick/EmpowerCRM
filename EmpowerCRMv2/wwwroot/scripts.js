window.JS = {
    SaveAs: function (fileName, byteBase64) {
        var link = document.createElement('a');
        link.download = fileName;
        link.href = "data:application/pdf;base64," + byteBase64;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    },
    openBase64PdfInNewTab: function (base64) {
        var byteCharacters = atob(base64);
        var byteNumbers = new Array(byteCharacters.length);
        for (var i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        var blob = new Blob([byteArray], { type: 'application/pdf' });
        var url = URL.createObjectURL(blob);
        window.open(url);
    }
};