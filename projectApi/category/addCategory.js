

async function addCategory()
{
    var form=document.getElementById("form");
    const url="https://localhost:44364/api/Categories";
   var formData = new FormData(form);
   event.preventDefault();
   let response= await fetch(url,
        {
            method:"POST",
            body:formData,
        });

        var data = response;
    }

 