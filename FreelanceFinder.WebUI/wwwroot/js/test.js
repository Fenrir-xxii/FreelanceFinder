"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("sweetalert2");
//import Swal from 'sweetalert2';
function TSButton() {
    var name = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
    //Swal.fire({
    //    title: 'Error!',
    //    text: 'Do you want to continue',
    //    icon: 'error',
    //    confirmButtonText: 'Cool'
    //})
}
var Student = /** @class */ (function () {
    function Student(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return Student;
}());
function greeter(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
var user = new Student("Fred", "M.", "Smith");
//# sourceMappingURL=test.js.map