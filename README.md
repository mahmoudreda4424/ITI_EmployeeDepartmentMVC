# Company Management WebApp

An ASP.NET Core MVC web application to manage **Departments** and **Employees** using Entity Framework Core and Identity for authentication and authorization.

---

## 🚀 Features

- ✅ User authentication using **ASP.NET Core Identity**
- 🏢 Manage Departments (Create, Read, Update, Delete)
- 👨‍💼 Manage Employees (Create, Read, Update, Delete)
- 🔐 Role-based access for different users
- 💾 Seeding initial data for both departments and employees
- 📊 Relational DB using **Entity Framework Core**
- 📦 Code-First with SQLite (or SQL Server)

---

## 🧱 Technologies Used

- ASP.NET Core 8 / 9 (MVC)
- Entity Framework Core (Code First)
- ASP.NET Core Identity
- C#
- SQLite (or your preferred database)
- Bootstrap (for styling)

---

## 🏗️ Database Schema

- `Department`
  - `Id` (int)
  - `Name` (string)
  - Navigation: `List<Employee>`

- `Employee`
  - `Id` (int)
  - `Name` (string)
  - `Email` (string)
  - `DepartmentId` (FK)

---

## 🧪 Sample Seeded Data

### Departments:
- Finance
- HR
- IT
- CS

### Employees:
- Alice → Finance  
- Bob → HR  
- Charlie → IT  
- Diana → CS  
- Ethan → HR  
- Fay → CS  
- George → Finance

---

## 🛠️ Getting Started

### 1️⃣ Clone the repository:
```bash
git clone https://github.com/mahmoudreda4424/ITI_EmployeeDepartmentMVC.git


## 📫 Contact

- LinkedIn: [Mahmoud Reda](linkedin.com/in/mahmoudredaprofile)
