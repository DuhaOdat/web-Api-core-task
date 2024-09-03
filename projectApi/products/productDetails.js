
const n= localStorage.getItem("productid");


    var url=`https://localhost:44364/api/Products/${n}`;




async function getProducts()
 {
    var token = localStorage.getItem('jwtToken')
    if(token==null)
    {alert("Please login first");
        window.location.href="../../colorlib-regform-7/login.html";
    }
   
    var response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }   
    });


    let request= await fetch(url);
    let data=await request.json();
 
    let container= document.getElementById("container");

    data.forEach(products => {

        container.innerHTML+=`
        <div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">${products.productName}</h5>
    <h6 class="card-subtitle mb-2 text-muted">${products.price}</h6>
    <input type="number" id="qInput"/>
    <button onClick="ProductDetails(${products.id})" class="btn btn-success " >Edit</button>
     <button onClick="addToCart()" class="btn btn-success " >Add To Cart</button>
   
  </div>
</div>
        `
        
    });
}

localStorage.setItem("Cartid",1);
async function addToCart()
{
    debugger
    const url="https://localhost:44364/api/CartItems";
  
     var request={
        cartId:localStorage.getItem("Cartid") ,
        productId:localStorage.getItem("productid"),
        quantity:document.getElementById('qInput').value 
      }
        var  data = await fetch(url,{
            method:"POST",
             body:JSON.stringify(request),
             headers: {
                'Content-Type': 'application/json'
             }
        })
   alert("add to cart successfully");
    }


function ProductDetails(id) {
    localStorage.setItem("productid", id);  
    alert("ID saved");
    window.location.href ="../Cart/Cart.html";

        }

getProducts();



