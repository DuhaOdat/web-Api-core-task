

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


async function addProduct()
{
    
    var form=document.getElementById("form");
    const url="https://localhost:44364/api/Products";
   var formData = new FormData(form);
   event.preventDefault();
   let response= await fetch(url,
        {
            method:"POST",
            body:formData,
        });

        var data = response;
         // Displaying the message if the product is added successfully
    if (response.ok) {
        alert("Product added successfully");
        form.reset(); // Reset the form
        window.location.href = "../products/products.html"; // Redirect to the product page 
    } else {
        alert("Failed to add product");
    }
}

   


   

   
   
    getAllCategory(); // Call the function to get all categories on page load
   