$(".barcodeText").on("keyup", function (e) {
    var BarCodeText = $(this).val();
    JsBarcode("#barcodeImage", BarCodeText, {
        fontSize: 15,
        font: "monofont", //change the font
        height: 55,
        width: 2, //set the width of the bar
        lineColor: "black",  //change the color of the bars
        displayValue: true,
        textAlign: "center",
        textPosition: "bottom",
        textMargin: 10 //set the margin of the text
    });
})
function createBarcode(barcodeValue, width = 2, height = 55) {
    const canvas = document.createElement("canvas");
    const context = canvas.getContext("2d");
    const fontSize = 15;
    const font = "monofont";
    const lineColor = "black";
    const textAlign = "center";
    const textPosition = "bottom";
    const textMargin = 10;

    JsBarcode(canvas, barcodeValue, {
        fontSize,
        font,
        height,
        width,
        lineColor,
        displayValue: true,
        textAlign,
        textPosition,
        textMargin,
    });
    
    return canvas;
}
