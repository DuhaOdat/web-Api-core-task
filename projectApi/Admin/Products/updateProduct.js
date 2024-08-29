var x = localStorage.getItem("productid");

async function editProduct()
{
    
    var form=document.getElementById("form");
    const url=`https://localhost:44364/api/Products/${x}`;
   var formData = new FormData(form);
   event.preventDefault();
   let response= await fetch(url,
        {
            method:"PUT",
            body:formData,
        });

        var data = response;
         // Displaying the message if the product is Updated successfully
    if (response.ok) {
        alert("Product Updated successfully");
       
    }
     else {
        alert("Failed to update product");
    }
}

async function getAllCategory()
{
   
    let request= await fetch("https://localhost:44364/api/Categories/AllCategories");
    let data= await request.json();

    var CategoryId = document.getElementById("CategoryId");

    data.forEach(element => {
        
    CategoryId.innerHTML += `
    <option value="${element.id}">${element.categoryName}</option>

    `
    });

    
}
getAllCategory();