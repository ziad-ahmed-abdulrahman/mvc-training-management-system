# 🎓 Training Management System

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core%208.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

An integrated management solution for training courses, departments, instructors, and trainees, built using **ASP.NET Core MVC**.

---

## 🛠️ Manual Setup & Installation

To ensure the project runs successfully on your local machine, the user **must** perform the following configuration steps:

### 1️⃣ Connection String Configuration
You need to point the application to your local SQL Server instance:

* Open the `appsettings.json` file.
* Update the `DefaultConnection` value to match your server name (e.g., `.\\SQLEXPRESS`).

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TrainingManagementSystem;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "AdminUserData": {
    "Email": "admin@ziad.com",
    "UserName": "AdminZiad",
    "Password": "YourSecurePassword123!"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
---

## 2️⃣ Database Update (Migrations)

The project includes ready-to-use Migrations. You must execute them to create the tables and initial data:

1.  Open the **Package Manager Console** in Visual Studio.
2.  Run the following command:

```powershell
update-database
```

---

## 🔐 Demo Credentials (Testing)

Once the database is updated, a pre-seeded Admin account is created automatically. Use these credentials to explore all system features:

| Field | Value |
| :--- | :--- |
| **Email** | `admin@ziad.com` |
| **User Name** | `AdminZiad` |
| **Password** | `YourSecurePassword123!` |

---

## 🚀 Technical Highlights

* **Identity System:** Robust authentication and authorization with Role-based access control (RBAC).
* **Fluent API:** Professional configuration of entity relationships (One-to-Many & Many-to-Many).
* **Clean UI:** Responsive interfaces built with **Bootstrap 5** and custom CSS enhancements.
* **Data Integrity:** Secure handling of cascading deletes and server-side data validation.

---

### 0️⃣ Clone the Repository
To get a local copy of this project, run the following command in your terminal:

```bash
git clone https://github.com/ziad-ahmed-abdulrahman/mvc-training-management-system.git
```

---


## 👨‍💻 Author

**Ziad Ahmed** *Communication & Electronics Engineering Student | Backend Developer specializing in .NET*

