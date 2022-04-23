let students = [];

fetch('http://localhost:29075/student')
    .then(x => x.json())
    .then(y => {
        students = y;
        console.log(students);
        display();
    });

function display() {
    students.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.neptunId +"</td></tr>";
    })
}