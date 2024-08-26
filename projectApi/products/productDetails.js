
const n= (localStorage.getItem("productid"));


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
    <button onClick="ProductDetails(${products.id})" class="btn btn-success">Add to cart</button>
   
  </div>
</div>
        `
        
    });
}
function ProductDetailst(id) {
    localStorage.setItem("productid", id);  
    alert("IDsaved")
    window.location.href ="./productDetails.html";

        }

getProducts();



