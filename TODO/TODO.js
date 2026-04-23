document.addEventListener("DOMContentLoaded", function () {

  const body = document.body;

    const container = document.createElement("div");
  container.className = "container py-5 d-flex justify-content-center";

  const card = document.createElement("div");
  card.className = "card shadow-lg p-4 w-50";

  const title = document.createElement("h3");
  title.textContent = "Todo List";
  title.className = "text-center mb-3";

  const form = document.createElement("form");
  form.className = "d-flex gap-2 mb-3";

  const input = document.createElement("input");
  input.className = "form-control";
  input.placeholder = "Add your todo...";
  input.type = "text";

  const btnAdd = document.createElement("button");
  btnAdd.className = "btn btn-primary";
  btnAdd.textContent = "+";
  btnAdd.type = "submit";

  const ul = document.createElement("ul");
  ul.className = "list-group";

  body.append(container);
  container.append(card);
  card.append(title, form, ul);
  form.append(input, btnAdd);


  form.addEventListener("submit", function (e) {
    e.preventDefault();

    if (input.value.trim() === "") return;

    const li = document.createElement("li");
    li.className = "list-group-item d-flex justify-content-between align-items-center";

    const text = document.createElement("span");
    text.textContent = input.value;

    const btnGroup = document.createElement("div");

    const doneBtn = document.createElement("button");
    doneBtn.className = "btn btn-success btn-sm me-2";
    doneBtn.textContent = "✔";

    const removeBtn = document.createElement("button");
    removeBtn.className = "btn btn-danger btn-sm";
    removeBtn.textContent = "✖";

    btnGroup.append(doneBtn, removeBtn);
    li.append(text, btnGroup);
    ul.append(li);


    doneBtn.addEventListener("click", () => {
      text.classList.toggle("text-decoration-line-through");
    });

  
    removeBtn.addEventListener("click", () => {
      li.remove();
    });

    input.value = "";
  });

});