# 📋 Event Check-In App

Aplicação para gerenciamento de participantes em eventos, permitindo check-in e check-out de pessoas em tempo real.

---

## 🔧 Tecnologias utilizadas

### Backend (.NET 7 / Entity Framework Core / PostgreSQL)

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- CORS habilitado para o frontend

### Frontend (React / Vite / TailwindCSS)

- React + Vite
- Axios para chamadas HTTP
- TailwindCSS para estilização

---

## 🚀 Como rodar o projeto

### ✅ Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/en/) (versão 16+ recomendada)
- PostgreSQL instalado e rodando (ex: via Docker ou local)

---

## 📦 Backend (.NET)

### 1. Acesse a pasta `backend/EventCheckInApi`:

```bash
cd backend/EventCheckInApi

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=eventcheckin;Username=postgres;Password='sua_senha'"
}


dotnet restore                      # Restaura dependências
dotnet ef migrations add Initial   # Cria a migração inicial
dotnet ef database update          # Cria o banco e insere dados iniciais
dotnet run                         # Inicia o servidor (http://localhost:5201)


cd frontend

npm install
npm run dev

O frontend estará disponível em http://localhost:5173.

