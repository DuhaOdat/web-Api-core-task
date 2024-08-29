const url = "https://localhost:44364/api/CartItems/GetAllCartItems";
    async function loadCart() {
        // debugger
        const data = await fetch(url);
        var response = await data.json();

        const tableBody = document.getElementById("cartTableBody");
        const cartID = localStorage.getItem("Cartid");

       
        response.forEach((element) => {
                if (element.cartId == cartID) {
                    tableBody.innerHTML +=
                        `
                            <tr>
                                <td>${element.product.productName}</td>
                                <td>${element.product.price}</td>
                                <td>${element.quantity}</td>
                                <td></td>
                            </tr>
                        `}
                }

            );
       
    }
    loadCart();