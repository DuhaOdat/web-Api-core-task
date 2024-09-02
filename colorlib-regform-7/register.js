  

const url ="https://localhost:44364/api/Users/Register" ;
    async function Register()
{
    event.preventDefault(); // Prevent the form from submitting

    debugger;
   
    var form = document.getElementById("register-form");
    var pass = document.getElementById("pass");
    var confirmPass = document.getElementById("confirm-pass");

    if (pass.value === confirmPass.value) {
        debugger;
        var formData = new FormData(form);

        try {
            let response = await fetch(url, {
                method: "POST",
                body: formData,
            });

            if (response.ok) {
                alert("Registered successfully");
            } else {
                alert("Registration failed. Please try again.");
            }
        } catch (error) {
            alert("An error occurred during registration.");
        }
    } else {
        alert("Passwords do not match");
    }
}
