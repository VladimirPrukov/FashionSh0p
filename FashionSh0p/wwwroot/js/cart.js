function updateCartCount() {
    fetch('/Cart/Count')
        .then(res => res.json())
        .then(count => {
            document.getElementById('cart-count').textContent = count;
        });
}

function showCartToast() {
    const toastElement = document.getElementById('cart-toast');
    if (toastElement) {
        const toast = new bootstrap.Toast(toastElement);
        toast.show();
    }
}
