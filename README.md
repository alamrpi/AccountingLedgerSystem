# Accounting Ledger System - Full Setup Guide

## Backend (.NET 8 API) Setup

### 1. Configure Database Connection
Edit `appsettings.json` in the API project:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=db-als;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;Connection Timeout=30;"
}
```

### 2. Run the API
#### Option A: Visual Studio
- Open `AccountingLedgerSystem.sln`
- Set `AccountingLedgerSystem.API` as startup project
- Click Run (F5)

#### Option B: .NET CLI
```bash
cd src/AccountingLedgerSystem.API
dotnet restore
dotnet build
dotnet run
```

Your API will typically run at:
- `https://localhost:7183` (or similar port)
- `http://localhost:5183`

## Frontend (React) Setup

### 1. Configure API Base URL
Create/update `.env` file in your React project root:
```env
VITE_API_URL=https://localhost:7183/api
```
*Replace with your actual API URL if different*

### 2. Install Dependencies & Run
```bash
cd frontend/accounting-ledger-frontend
npm install
npm run dev
```

The React app will launch at `http://localhost:5173`

## Key Notes
1. **Environment Variables**:
   - All Vite env variables must be prefixed with `VITE_`
   - Access in code via `import.meta.env.VITE_API_URL`

2. **Troubleshooting**:
   - If connection fails, verify:
     - API is running
     - Correct port in `.env`
