fetch('http://localhost:29075/student')
    .then(x => x.json())
    .then(y => console.log(y));