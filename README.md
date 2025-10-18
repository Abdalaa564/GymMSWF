# 🏋️‍♂️ Gym Management System

A **Windows Forms Application** built using **C# (.NET Framework)** and **Entity Framework Core**, following a **3-Tier Architecture** design pattern.  
This project provides a complete solution to manage gym operations including clients, instructors, employees, packages, attendance, and finance records.

---

## 🧩 Project Architecture (3-Tier)

The system follows the **3-Tier Architecture** pattern for separation of concerns and maintainability:


### 📁 Layers Overview

1. **GymManagementSystemWinForms**  
   - Presentation Layer (UI)  
   - Contains all Windows Forms for user interaction.  

2. **GymManagementSystemServices**  
   - Business Logic Layer (Services)  
   - Contains logic for handling data between the UI and the Data Layer.  

3. **GymManagementSystemData**  
   - Data Access Layer  
   - Contains models, DbContext, and Entity Framework Core configurations.

---

## 🧱 Models

The system manages several entities related to the gym:

| Model Name     | Description |
|----------------|-------------|
| **Client**      | Stores client information, package, and payment details. |
| **Attendance**  | Tracks attendance records of clients. |
| **Employee**    | Stores gym employee data. |
| **Instructor**  | Holds instructor (coach) details and assigned packages. |
| **Package**     | Defines gym subscription plans and details. |
| **Payment**     | Records client payments and related information. |
| **FinanceRecord** | Keeps monthly finance statistics (scheduled, paid, overdue). |

---

## 🧠 Services

The **Services Layer** handles all core business operations:

| Service Name | Purpose |
|---------------|----------|
| **AttendanceService** | Manages attendance tracking and reporting. |
| **ClientServices** | Handles CRUD operations for clients. |
| **CoachService** | Manages instructors' data and schedules. |
| **EmployeeServices** | Handles employee management. |
| **FinanceService** | Calculates and manages finance records (income, payments). |
| **PackageService** | Manages gym packages and related offers. |
| **PaymentService** | Records and validates client payments. |

---

## 🖥️ Main Forms

| Form Name | Purpose |
|------------|----------|
| **LogInForm** | User authentication form. |
| **Home** | Main navigation hub after login. |
| **Dashboard** | Displays statistics and summaries (clients, finance, attendance). |
| **Packages** | Displays and manages gym subscription packages. |
| **InstructorForm** | Shows instructor details. |
| **ClientPage** | Displays all client data and history. |
| **EmployeeForm** | Manages employees. |
| **PaymentForm** | Handles payment operations. |
| **About** | Application information page. |
| **FAQ** | Frequently Asked Questions section. |
| **AddClient / AddEmployee / AddInstructor / AddPackageForm / AddPayment** | Forms for adding new entities. |
| **EditInstructorForm / EditPackageForm** | Forms for editing existing data. |

---

## 🧮 Features

- Manage **Clients**, **Employees**, **Instructors**, and **Packages**.
- Record and monitor **Attendance**.
- Handle **Payments** and generate **Finance Reports**.
- Track **Remaining Sessions**, **Active Packages**, and **Payment History**.
- Built with a clean **3-tier structure** for scalability and easy maintenance.

---

## 🛠️ Technologies Used

| Technology | Description |
|-------------|-------------|
| **C# (.NET Framework)** | Core programming language |
| **Entity Framework Core** | ORM for database management |
| **Windows Forms (WinForms)** | UI Framework |
| **SQL Server** | Database backend |
| **LINQ** | For querying data |
| **3-Tier Architecture** | Structural pattern for separation of concerns |

---

## 👥 Team Members

| Name | Role |
|------|------|
| **Mennatullah Atef** | Developer |
| **Rawan Ahmed** | Developer |
| **Abdalaa Khaleel** | Developer |
| **Ramiz Magdt** | Developer |

---

## 📸 Screenshots (Optional)
> *(You can add screenshots of your forms here)*  
Example:

