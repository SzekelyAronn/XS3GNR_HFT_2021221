let log = console.log;
let students = [];
let connection;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:29075/hub") 
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        getData();
    });
    connection.on("StudentDeleted", (user, message) => {
        getData();
    });
    connection.on("StudentUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {

    await fetch('http://localhost:29075/student')
        .then(x => x.json())
        .then(y => {
            students = y;
            //console.log(students);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    students.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + `</td><td><input type="text" id="studentname_${t.id}" value="${t.name}">` + `</td><td><input type="text" id="studentneptun_${t.id}" value="${t.neptunId}">` + "</td><td>"+ `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button" onclick="update(${t.id})">Update</button>`  +"</td></tr>";
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


function update(id) {
    log("update student " + id);
    let studname = document.getElementById('studentname_' + id).value;
    let studneptun = document.getElementById('studentneptun_' + id).value;
    fetch('http://localhost:29075/student', {
        method: 'PUT',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ id: id, name: studname, neptunId:studneptun, facultyId: 1 }),
    })
        .then(response => response)
        .then(data => {
            log("Student created");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}
