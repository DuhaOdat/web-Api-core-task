

async function Login()
{

    event.preventDefault(); // Prevent the form from submitting

    debugger;
    var form=document.getElementById("login-form");
    const url="https://localhost:44364/api/Users/Login";
   var formData = new FormData(form);

   try {
    let response = await fetch(url,{
        method: "POST",
        body: formData,
       
    });

    if (response.ok) {
        var result= await response.json();
        localStorage.setItem('jwtToken', result.token);
        alert("/ Loggened successfully");
        window.location.href= "../projectApi/index.html";
    } else {
        alert("logging failed. Please try again.");
    }
} catch (error) {
   
    alert("An error occurred during Loggin.");
}


}
