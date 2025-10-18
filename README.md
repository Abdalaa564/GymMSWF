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
| **Ramiz Magdy** | Developer |

---

## 🧑‍🤝‍🧑 Team Collaboration & Work Distribution

We worked together as a **team** throughout the entire development process.  
All members participated in **coding, designing, and testing** different parts of the project.

### 🧠 Collaboration Highlights:
- We always worked together in **team meetings**, sharing ideas and helping each other solve problems.  
- Every member contributed to both **frontend (WinForms UI)** and **backend (EF Core & Services)**.  
- Some tasks were **shared between two members**, such as working on attendance logic and dashboard integration.  
- The project was built through **continuous communication, feedback, and collaboration** on all modules.

---

## 📸 Screenshots (Optional)
> <img width="388" height="455" alt="image" src="https://github.com/user-attachments/assets/4a3d5abc-9a66-4ae6-be9c-bf36b7bf0c72" />
<img width="1266" height="601" alt="image" src="https://github.com/user-attachments/assets/b0e449cd-39df-415a-825e-51b4aeebef9a" />
<img width="688" height="424" alt="image" src="https://github.com/user-attachments/assets/29d79511-130e-4d17-83c7-8f42266a102f" />
<img width="1272" height="606" alt="image" src="https://github.com/user-attachments/assets/206470cb-170c-47c9-9067-8f11fd0eb0b3" />
<img width="697" height="422" alt="image" src="https://github.com/user-attachments/assets/7f8dc3a1-31e0-43d2-b5e1-8f49aae2981a" />
<img width="1262" height="602" alt="image" src="https://github.com/user-attachments/assets/767cdd7a-5402-4cc3-9663-24efaf4c81ac" />
<img width="1263" height="607" alt="image" src="https://github.com/user-attachments/assets/ddd41556-a024-40b1-a836-e245acb33b53" />
<img width="1265" height="601" alt="image" src="https://github.com/user-attachments/assets/524f209a-a218-4a08-bd92-17ff9f3c52f4" />
<img width="1265" height="597" alt="image" src="https://github.com/user-attachments/assets/33f60b68-8217-418b-8c60-b0e5802eb451" />
<img width="311" height="418" alt="image" src="https://github.com/user-attachments/assets/58b7ca6d-59a3-465a-bdb7-bd985b865b17" />


