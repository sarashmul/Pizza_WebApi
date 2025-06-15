# 🍕 Pizza Web API – Fullstack Project

This is a fullstack Web API project developed with **ASP.NET Core**, **JavaScript**, and **modular services architecture**.  
It demonstrates a functional pizza management and order system with secure access, logging, and separation of concerns.

## 🧩 Technologies Used

- **Backend:** ASP.NET Core Web API (Controllers, Middleware)
- **Frontend:** Vanilla JavaScript (Fetch API)
- **Authorization:** JWT-based Role Policy (Admin, SuperWorker)
- **Middleware:** Custom request/response logger
- **Services:** Dependency Injection with interface-based abstraction
- **File Handling:** IFileService for logging and persistence
- **Validation & Security:** Model validation, Range attributes, and token headers

## 📁 Project Structure

```
📦 lesson2/
├── Controllers/
│   ├── MyPizzaController.cs
│   └── OrderController.cs
├── Middlewares/
│   └── ActionLogMiddleware.cs
├── Interfaces/
│   └── IPizzaService.cs
│   └── IOrderService.cs
├── Models/
│   └── MyPizza.cs
├── wwwroot/
│   └── index.html (login & pizza UI logic)
├── Services/
│   └── PizzaService.cs
│   └── OrderService.cs
└── Program.cs / Startup.cs
```

## ⚙️ Core Features

### 🔐 Authentication & Authorization

- Role-based access using JWT tokens
- Admin/SuperWorker permissions control CRUD operations
- Token passed via `Authorization` header from frontend

### 🍕 Pizza Management (CRUD)

- **GET /MyPizza/GetById/{id}**: Get pizza by ID
- **POST /MyPizza/Post**: Add a new pizza (Admin only)
- **PUT /MyPizza/putName**: Update pizza name (Admin only)
- **PUT /MyPizza/putGlotan**: Update gluten flag (SuperWorker)
- **DELETE /MyPizza/Del/{id}**: Delete pizza (SuperWorker)

### 📦 Order Management

- **GET /Order/OGetById/{id}**: Retrieve order by ID
- **POST /Order/OPost**: Place a new order with card details

### 📝 Logging Middleware

- Logs every request and response including:
  - Time
  - Method
  - Headers
  - Body content
  - Status code
- Logs are saved to a `.txt` file in `App_Data/actionLog.txt` via `IFileService<string>`

### 💻 Frontend UI

- Simple HTML/JS login and pizza add form
- Handles token storage and passing to secure endpoints
- Dynamic DOM display for login/pizza sections

## 🧪 Sample Usage

```bash
POST /Login/Login?name=admin&password=123
→ returns JWT token

GET /MyPizza/GetById/101
→ returns pizza details

POST /MyPizza/Post?nameOfPizza=Margherita&id=101&glotan=false
→ adds pizza (requires token in header)

PUT /MyPizza/putName/101/NewName
→ updates name (Admin only)
```

## 🛠️ To Run the Project

1. Clone the repository
2. Ensure `.NET SDK` is installed
3. Restore dependencies and run the project:
   ```bash
   dotnet restore
   dotnet run
   ```
4. Open the frontend `index.html` in browser or integrate with frontend framework

## 🔒 Notes

- Passwords are handled via query parameters for simplicity (in real applications, use body + HTTPS)
- Token-based auth is enforced via `[Authorize(Policy = "...")]`
- Middleware auto-writes logs for every request and response

---

🔁 This project is modular and easily extendable with new controllers, middleware, or frontend components. Perfect as a base for RESTful service practice or fullstack demos.
