var url = "/checkout/trustpilot/" + document.getElementById('order-id').dataset.value;
fetch(url, {
    method: "GET",
    headers: {
        "Content-Type": "application/json"
    }
}).then(response => response.json())
    .then(function (data) {
        const trustpilot_invitation = {
            recipientEmail: data.email,
            recipientName: data.name,
            referenceId: data.referenceId,
            source: 'InvitationScript',
            productSkus: data.productSkus,
            products: data.products
        };
        Log("trustpilot invitation");
        tp('createInvitation', trustpilot_invitation);
    });