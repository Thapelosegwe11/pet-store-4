# pet-store-4.

![Gauge](https://img.shields.io/badge/Gauge-1.6-orange) ![OpenAPI](https://img.shields.io/badge/OpenAPI-Generator-orange) ![.NET](https://img.shields.io/badge/.NET-8.0-purple) ![Docker](https://img.shields.io/badge/Docker-Compose-blue)

## Description
Automated API test plans for the Swagger Petstore application using Gauge and an OpenAPI generated client in C#. Test plans are written in plain English markdown specs and backed by generated API client code.

## 🛠️ Tech Stack
- **Language:** C#
- **Test Plan Framework:** Gauge
- **API Client:** OpenAPI Generator (auto-generated)
- **Assertions:** FluentAssertions
- **System Under Test:** Swagger Petstore (via Docker)

## 📁 Project Structure
pet-store-4/
├── Applications/
│   └── PetStore/
│       ├── specs/
│       │   ├── inventory.spec   # Inventory test plan
│       │   └── pet.spec         # Pet test plan
│       ├── Steps/
│       │   ├── InventorySteps.cs  # Inventory step implementations
│       │   └── PetSteps.cs        # Pet step implementations
│       └── Api/                   # OpenAPI generated client
├── env/
│   └── default/                   # Gauge configuration
└── .lms/
└── exercises.toml             # School submission file

## ✅ Prerequisites
- .NET 8.0
- Docker
- Gauge CLI
- Java (for OpenAPI Generator)

## ⚙️ Installation
Clone the repo:
```bash
git clone git@github.com:Thapelosegwe11/pet-store-4.git
cd pet-store-4
```

## 🐳 Running the Petstore API with Docker
```bash
docker run -d -p 80:8080 -e SWAGGER_BASE_PATH=/v2 swaggerapi/petstore
```

Verify it's running at:
http://localhost:80

## 🧪 Running the Tests
```bash
dotnet build
gauge run
```

## 📋 Test Plans
| Spec | Scenario | Description |
|------|----------|-------------|
| inventory.spec | Store has inventory per status | Verifies sold, pending, available statuses |
| pet.spec | Add a pet | Adds a pet and verifies it was added |
| pet.spec | Delete a pet | Adds then deletes a pet and verifies removal |

## 🎯 Key Concepts
- **Gauge Specs** — human readable test plans written in plain English markdown
- **OpenAPI Generated Client** — auto-generated C# client from Swagger definition
- **Clean separation** — specs define WHAT to test, steps define HOW to test it

## 🔧 Troubleshooting
- **Connection refused** — Make sure Docker is running and Petstore container is up
- **Gauge build failed** — Run `dotnet build` first before running gauge

## 📄 License
This project is for educational purposes at WeThinkCode_.
