

let url="https://localhost:44364/api/Categories/AllCategories";

async function getCategory()
{
    let request= await fetch(url);
    let data= await request.json();

    let container=document.getElementById("cards_container");

    data.forEach(category => {

        container.innerHTML+=` 
            <div class="card" style="width: 18rem;">
           <div class="card-body">
           <h5 class="card-title">${category.id}</h5>
           <h6 class="card-subtitle mb-2 text-muted">${category.categoryName}</h6>
           <button onClick="store(${category.id})" class="btn btn-success">show more product</button>
           </div>
        </div> 
`
    });

    
}
function store(id) {
    localStorage.id = id;
    window.location.href ="../products/products.html";

        }
getCategory();
