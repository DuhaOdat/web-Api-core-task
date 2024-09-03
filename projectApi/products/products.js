debugger;


async function getProducts()
 {
    var token = localStorage.getItem('jwtToken')
    const n= localStorage.getItem("id");
if(n==0 || n == null)
{var  url="https://localhost:44364/api/Products";}
else{
    var url=`https://localhost:44364/api/Products/productsByCategoryId/${n}`;

}

    if(token==null)
    {alert("Please login first");
        window.location.href="../../colorlib-regform-7/login.html";

    }
   
    var response = await fetch(url, {
        headers: {
            'Authorization': `Bearer ${token}`
        }   
    });
      
    let data=await response.json();
 
    let container= document.getElementById("container");

    data.forEach(products => {

        container.innerHTML+=`
        <div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">${products.productName}</h5>
    <h6 class="card-subtitle mb-2 text-muted">${products.price}</h6>
    <a href="productDetails.html" onClick="ProductDetails(${products.id})" class="btn btn-success">Go To Details</a>
   
  </div>
</div>
        `
        
    });
}
function ProductDetails(id) {
    localStorage.setItem("productid", id);  
    
    // window.location.href ="productDetails.html";

        }

getProducts();



