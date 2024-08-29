
const  url=" https://localhost:44364/api/Products";


async function getProducts()
 {
    let request= await fetch(url);
    let data=await request.json();
 
    let container= document.getElementById("container");



    data.forEach(products =>{
        

        container.innerHTML+=`
    <tr>
      <th scope="row">${products.id}</th>
      <td>${products.productName}</td>
      <td>${products.description}</td>
      <td>${products.price}</td>
      <td>${products.categoryId}</td>
      <td><img src="../../../taskTwoAPICore/taskTwoAPICore/Uploads/${products.productImage}" alt="${products.productImage}" style="width: 100px; height: auto;"></td>
      <td><a href="../Products/updateProduct.html" onclick="getProduct(${products.id})">Edit</a></td>


    </tr>
 `});
  
}


function getProduct(productid) {
    localStorage.setItem("productid", id);  
    
        }

getProducts();
       


