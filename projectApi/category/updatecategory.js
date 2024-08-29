var x = localStorage.getItem("id");
 const  url = `https://localhost:44364/api/Categories/${x}`;

 var form = document.getElementById("form");
 async function updateCategory() {
     event.preventDefault();
     var formData = new FormData(form);
 
     var response = await fetch(url,{
        method: "PUT",
        body : formData 
     })
 
     alert("Category updated Successfully");
 
 
 }