var user = new Parse.User();
user.set("username", "Jazastry");
user.set("password", "falfalafa");
user.set("email", "jazastry@example.com");
  
// other fields can be set just like with Parse.Object
user.set("phone", "02/650-555-0000");
  
user.signUp(null, {
  success: function(user) {
    // Hooray! Let them use the app now.
  },
  error: function(user, error) {
    // Show the error message somewhere and let the user try again.
    alert("Error: " + error.code + " " + error.message);
  }
});