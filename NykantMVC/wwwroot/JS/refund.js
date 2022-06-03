var refunddiv = document.getElementById('refund-div');
var paymentCaptureIdInput = document.getElementById('paymentCaptureId');
var refund = function (e) {
    refunddiv.style.display = 'block';
    paymentCaptureIdInput.value = e.dataset.paymentcaptureid;
}