"use strict;"

fetch('https://localhost:7010/Login',
  {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(
      {
        "email": "JSmith@myEmail.com",
        "password": "12345"
      }
    )
  })
  .then(res => {
    if (res.ok) {
      return res.json();
    }
  })
  .then(bod => {
    console.log(bod.email, bod.password);
  })
