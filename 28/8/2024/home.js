// function Store()
// {
//     localStorage.setItem("productId",2);
//     localStorage.setItem("CartId",1);
// }


async function addToCart()
{
    const url="https://localhost:44364/api/CartItems";
    const Q = document.getElementById('qInput').value; 
     var request={
        cartId: 1,
        productId: 5,
        quantity: parseInt(Q)
      }
        var  data = await fetch(url,{
            method:"POST",
             body:JSON.stringify(request),
             headers: {
                'Content-Type': 'application/json'
             }
        })
   
    }
    

