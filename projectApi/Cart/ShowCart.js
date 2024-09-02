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
                                <td>
                                <input type="number" value="${element.quantity}" id="quantity${element.cartItemId}">
                                </td>
                                <td>
                                <button type="button" class="btn btn-primary" onclick="edit(${element.cartItemId})">Edit</button>
                                </td>
                                <td>
                                <button type="button" class="btn btn-danger" onclick="deleteItem(${element.cartItemId})">Delete</button>
                                </td>
                            </tr>
                        `}
                }

            );
       
    }
    loadCart();

    async function edit(id) {
        debugger;
        event.preventDefault();
        var quantity = document.getElementById(`quantity${id}`);
        var data = {
            quantity: quantity.value
          };
        var url = `https://localhost:44364/api/CartItems/${id}`;
        var requist = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        console.log(response);
         location.reload();
    }
    
    async function deleteItem(data) {
        var url = `https://localhost:44364/api/CartItems/${data}`;
        var requist = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        location.reload();
        
    }