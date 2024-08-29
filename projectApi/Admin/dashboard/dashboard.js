let url="https://localhost:44364/api/Categories/AllCategories";

async function getCategory()
{
    let request= await fetch(url);
    let data= await request.json();

    let container=document.getElementById("container");  
    data.forEach(category =>{

        container.innerHTML+=`
    <tr>
      <th scope="row">${category.id}</th>
      <td>${category.categoryName}</td>
      <td><img src="../../../taskTwoAPICore/taskTwoAPICore/Uploads/${category.categoryImage}" alt="${category.categoryName}" style="width: 100px; height: auto;"></td>
      <td><a href="../category/updateCategory.html" onclick="getCategoryId(${category.id})">Edit</a></td>


    </tr>
 `});
  
}
function getCategoryId(categoryid) {
    localStorage.setItem('categoryid', categoryid);
   
}

getCategory();