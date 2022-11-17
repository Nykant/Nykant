var refunddiv = document.getElementById('refund-div');
var paymentCaptureIdInput = document.getElementById('paymentCaptureId');
var refundButton = document.getElementById('refund-button');

function refund() {
    refunddiv.style.display = 'block';
    paymentCaptureIdInput.value = refundButton.dataset.paymentcaptureid;
}

refundButton.addEventListener("click", refund);

$('#refund-close').click(function () {
    $('#refund-div').css('display', 'none');
});