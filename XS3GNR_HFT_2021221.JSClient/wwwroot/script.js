let students = [];

getdata();

async function getdata() {

    await fetch('http://localhost:29075/student')
        .then(x => x.json())
        .then(y => {
            students = y;
            console.log(students);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    students.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.neptunId + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>`  +"</td></tr>";
    })
}


function remove(id) {

    fetch('http://localhost:29075/student/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.log('Error:', error);
        });
}

function create() {
    let studname = document.getElementById('studentname').value;
    let studentneptunid = document.getElementById('studentneptun').value;
    fetch('http://localhost:29075/student', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: studname,
                neptunId: studentneptunid,
                facultyId: 1
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.log('Error:', error);
        });
}