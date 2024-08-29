
const n= localStorage.getItem("productid");


    var url=`https://localhost:44364/api/Products/${n}`;




async function getProducts()
 {
    let request= await fetch(url);
    let data=await request.json();
 
    let container= document.getElementById("container");

    data.forEach(products => {

        container.innerHTML+=`
        <div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">${products.productName}</h5>
    <h6 class="card-subtitle mb-2 text-muted">${products.price}</h6>
    <button onClick="ProductDetails(${products.id})" class="btn btn-success " >Edit</button>
   
  </div>
</div>
        `
        
    });
}
function ProductDetails(id) {
    localStorage.setItem("productid", id);  
    alert("ID saved")
    window.location.href ="../products/updateProduct.html";

        }

getProducts();



