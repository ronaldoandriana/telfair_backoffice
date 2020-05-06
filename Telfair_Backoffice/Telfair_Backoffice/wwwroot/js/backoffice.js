function testPassword() {
    var save_button = document.getElementById('save_button');
    if (save_button) save_button.setAttribute('disabled', 'disabled');
    var message = ["At least 8 characters", "Must contains number", "Must be different from user name"];
    var password = "";
    var HashCode = document.getElementById("HashCode");
    if (HashCode) password = HashCode.value;
    var password_suggestion = document.getElementById('password_suggestion');
    if (password.length < 8) {
        if (password_suggestion) {
            password_suggestion.setAttribute('style', 'color: red');
            password_suggestion.innerHTML = "Suggestions: " + message[0];
        }
    }
    else {
        if (!containsNumber(password) && false) {
            if (password_suggestion) {
                password_suggestion.setAttribute('style', 'color: red');
                password_suggestion.innerHTML = "Suggestions: " + message[1];
            }
        }
        else {
            var UserName = document.getElementById('UserName');
            if (UserName) {
                if (UserName.value === password) {
                    if (password_suggestion) {
                        password_suggestion.setAttribute('style', 'color: red');
                        password_suggestion.innerHTML = "Suggestions: " + message[2];
                    }
                }
                else {
                    if (save_button)
                    {
                        save_button.removeAttribute('disabled');
                        save_button.setAttribute('enabled', 'enabled');
                    }
                    if (password_suggestion)
                    {
                        password_suggestion.setAttribute('style', 'color: green');
                        password_suggestion.innerHTML = "Password is strong";
                    }
                }
            }
        }
    }
}

function containsNumber(password) {
    for (var i = 0; i <= 9; i++) {
        if (password.includes("" + i)) return true;
    }
}