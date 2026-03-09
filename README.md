# ASP.NET Core Unit Testing Example

## 📌 Overview

This project demonstrates how to implement **unit tests for business rules** in an **ASP.NET Core application** using **xUnit**.

The main goal is to validate **authorization and domain logic** when registering employees.
The tests ensure that users can only perform actions that comply with the defined business rules.

---

## 🧠 Business Rules Implemented

The following rules are validated through unit tests:

* A user **cannot register another employee**.
* A user **can register their own employee**.
* The system **throws an exception when the employee does not exist**.
* The system **throws an exception when the user is inactive**.
* The system **saves the registration when all rules are valid**.

---

## 🧪 Unit Tests

The following tests are implemented in the project:

* `Register_ShouldThrowException_WhenUserTriesToRegisterAnotherEmployee`
* `Register_ShouldNotThrowException_WhenUserRegistersOwnEmployee`
* `Register_ShouldThrowException_WhenEmployeeDoesNotExist`
* `Register_ShouldThrowException_WhenUserIsInactive`
* `Register_ShouldSaveData_WhenAllRulesAreValid`

All tests are implemented using **xUnit** and validate the **service layer business logic**.

---

## 🏗 Project Structure

```
UnitTests
│
├── UnitTests
│   ├── Controllers
│   │   └── EmployeeController.cs
│   │
│   ├── Dtos
│   │   └── RegisterEmployeeRequest.cs
│   │
│   ├── Models
│   │   ├── Employee.cs
│   │   └── User.cs
│   │
│   ├── Services
│   │   ├── IEmployeeRegistrationService.cs
│   │   └── EmployeeRegistrationService.cs
│   │
│   └── Program.cs
│
└── Tests
    └── EmployeeRegistrationServiceTests.cs
```

---

## ⚙ Technologies Used

* **.NET 8**
* **ASP.NET Core**
* **xUnit**
* **C#**
* **Visual Studio**

---

## ▶ Running the Tests

Clone the repository:

```
git clone https://github.com/jonas-ferreira-dev/UnitTests.git
```

Open the solution in **Visual Studio** and run the tests using **Test Explorer**.

Expected result:

```
5 tests passed
0 failed
```

---

## 🎯 Purpose of This Project

This repository was created as a learning exercise to demonstrate:

* Unit testing practices
* Validation of business rules
* Clean architecture separation
* Service layer testing


