

function setShowsByMovie(movie) {
    var other = document.getElementById("shows");
    var option = document.createElement("option");
    option.value = "VALUE";
    other.appendChild(option);

}

function addSpectator(form) {

  if (document.getElementById("seatsAvailable").textContent >= 1) {

    var element = document.getElementById("spectators");

    var row = document.createElement("tr");
    row.name = "Spectator";

    var name = document.createElement("td");
    name.textContent = form.spectatorName.value;
    name.scope = "row";
    var surname = document.createElement("td");
    surname.textContent = form.spectatorSurname.value;
    var birthdate = document.createElement("td");
    birthdate.textContent = form.spectatorYear.value;

    var deleteButton = document.createElement("td");
    deleteButton.classList.add("link-warning");
    deleteButton.textContent = "Supprimer";
      deleteButton.onclick = function (deleteButton) {
        if (document.getElementById("spectatorForm").contains(document.getElementById("errorMessage"))) {
          document.getElementById("spectatorForm").removeChild(document.getElementById("errorMessage"));
        }
      element.removeChild(row);
      document.getElementById("seatsAvailable").textContent =
        parseInt(document.getElementById("seatsAvailable").textContent) + 1;
    }

    var nameInput = document.createElement("input");
    nameInput.name = "Name";
    nameInput.type = "hidden";
    nameInput.value = form.spectatorName.value;
    nameInput.className = "form-control"

    var surnameInput = document.createElement("input");
    surnameInput.name = "Surname";
    surnameInput.type = "hidden";
    surnameInput.value = form.spectatorSurname.value;
    surnameInput.className = "form-control"

    var ageInput = document.createElement("input");
    ageInput.name = "Age";
    ageInput.type = "hidden";
    ageInput.value = form.spectatorYear.value;
    ageInput.className = "form-control";

    row.appendChild(name);
    row.appendChild(surname);
    row.appendChild(birthdate);
    row.appendChild(deleteButton);

    row.appendChild(nameInput);
    row.appendChild(surnameInput);
    row.appendChild(ageInput);

    element.appendChild(row);

    document.getElementById("seatsAvailable").textContent -= 1;
  } else {
      var element = document.getElementById("spectatorForm");
      if (!element.contains(document.getElementById("errorMessage"))) {
        var errorMessage = document.createElement("p");
        errorMessage.className = "text-danger";
        errorMessage.id = "errorMessage";
        errorMessage.textContent =
          "Vous ne pouvez plus ajouter de spectateur car il reste aucune place";
        element.appendChild(errorMessage);
      }
  }

}