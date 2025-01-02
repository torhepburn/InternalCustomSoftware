function showMessage(message)
{
    alert(message);
}

function add(a, b)
{
    return a = b;
}


function openPDF(pdfData)
{
    const pdfWindow = window.open();
    pdfWindow.document.write(
        '<iframe width=100% height=100% src-"dat:application/pdf;base64,' + pdfData + '"></iframe>'
    )

}