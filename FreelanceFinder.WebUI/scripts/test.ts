import 'sweetalert2'
//import Swal from 'sweetalert2';

function TSButton() {
    let name: string = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
    //Swal.fire({
    //    title: 'Error!',
    //    text: 'Do you want to continue',
    //    icon: 'error',
    //    confirmButtonText: 'Cool'
    //})
}


class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

interface Person {
    firstName: string;
    lastName: string;
}

function greeter(person: Person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}

let user = new Student("Fred", "M.", "Smith");


