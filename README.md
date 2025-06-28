# Accounting Ledger System - Full Setup Guide
## Prerequisites

- .NET 8 SDK
- Node.js (for React frontend)
- SQL Server (or compatible database)

## Backend (.NET 8 API) Setup

### 1. Configure Database Connection
Edit `appsettings.json` in the API project:
```json
"ConnectionStrings": {
  "DefaultConnection": ""
}
```
 Add your database connection string in 'DefaultConnection'

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

# Sample entries
Sample seed data:
### Accounts
### Asset Accounts (100-199)

| ID  | Name                | Description                                  |
|-----|---------------------|----------------------------------------------|
| 100 | Raw Materials       | Raw materials held for production            |
| 101 | Work In Progress    | Goods in the production process              |
| 102 | Finished Goods      | Completed products ready for sale            |
| 103 | Trading Goods       | Goods purchased for resale                   |
| 104 | Packing Materials   | Materials used for product packaging         |
| 105 | Store & Spare parts | Spare parts for maintenance                  |
| 106 | Goods in Transit    | Inventory in shipment                        |
| 107 | Stationery Items    | Office stationery supplies                   |
| 108 | Consumable Items    | Consumable supplies                          |

### Liability Accounts (200-299)

| ID  | Name               | Description                                                  |
|-----|--------------------|--------------------------------------------------------------|
| 200 | Short Term Loan    | Current portion of long-term debt and short-term borrowings  |
| 201 | Trade Payable      | Amounts owed to suppliers for goods/services purchased on credit |
| 202 | Tax & VAT Payable  | Outstanding tax and value-added tax liabilities              |
| 203 | Provision & Accrual| Estimated liabilities and accrued expenses                   |

### Equity Accounts (300-399)

| ID  | Name                  | Description                                          |
|-----|-----------------------|------------------------------------------------------|
| 300 | Share Capital         | Ordinary share capital at nominal value             |
| 301 | Share Premium         | Amount received above nominal share value           |
| 302 | Retained Earnings     | Cumulative net earnings not distributed as dividends |
| 304 | Opening Balance Equity| Initial balance when setting up accounting system   |

### Revenue Accounts (400-499)

| ID  | Name                | Description                                  |
|-----|---------------------|----------------------------------------------|
| 400 | Operating Revenue   | Primary revenue from core business operations |
| 401 | Revenue from Branch | Income generated from branch operations      |
| 402 | Revenue from B2B    | Business-to-business sales income            |
| 403 | E-Commerce Revenue  | Online sales through electronic channels     |

### Expense Accounts (500-599)

| ID  | Name                      | Description                                  |
|-----|---------------------------|----------------------------------------------|
| 500 | Material and Service Cost | Direct costs of materials and outsourced services |
| 501 | Branch Operation Expenses | All costs associated with branch operations  |
| 502 | Factory Overhead          | Indirect manufacturing costs                 |
| 503 | Settling Expenses         | Costs related to transaction settlements     |

# Journal Entry System

This document describes the journal entry structure and provides sample data for the accounting ledger system.

## Journal Entry Structure

The system consists of two main entities:

1. **JournalEntry** - The header record containing:
   - Date of transaction
   - Description
   - Timestamps
   - Reference to associated line items

2. **JournalEntryLine** - The detail records containing:
   - Associated JournalEntry ID
   - Account ID
   - Debit amount
   - Credit amount
   - Timestamps

## Sample Journal Entries

### Test Journal Entries

| ID | Date       | Description                 | Created At                  |
|----|------------|-----------------------------|-----------------------------|
| 1  | 2025-01-15 | Initial capital injection   | 2023-01-15T09:00:00         |
| 2  | 2025-01-20 | Purchase of inventory       | 2023-01-20T14:30:00         |
| 3  | 2025-01-25 | Sales revenue               | 2023-01-25T16:45:00         |
| 4  | 2025-01-31 | Month-end adjustments       | 2023-01-31T23:59:00         |

### Test Journal Entry Lines

| Entry ID | Line ID | Account ID | Debit    | Credit   | Description                         |
|----------|---------|------------|----------|----------|-------------------------------------|
| 1        | 1       | 101        | 10000.00 | 0.00     | Cash received (Capital injection)   |
| 1        | 2       | 301        | 0.00     | 10000.00 | Share capital increase              |
| 2        | 3       | 102        | 5000.00  | 0.00     | Inventory purchase (DR)             |
| 2        | 4       | 101        | 0.00     | 5000.00  | Cash payment (CR)                   |
| 3        | 5       | 101        | 3000.00  | 0.00     | Cash from sales (DR)                |
| 3        | 6       | 401        | 0.00     | 3000.00  | Revenue recognition (CR)            |
| 4        | 7       | 501        | 1000.00  | 0.00     | Branch operation expense (DR)       |
| 4        | 8       | 203        | 0.00     | 1000.00  | Accrued liabilities (CR)            |

# Screenshots
#### Accounts Page
![image](https://github.com/user-attachments/assets/aec20aa4-a907-4cf7-a207-f0106b93fce5)

#### Add Journal Entry Page
![image](https://github.com/user-attachments/assets/018d836e-e83f-4626-aab1-2241c822c6a8)

#### Journal Entries Page
![image](https://github.com/user-attachments/assets/0b62e117-2733-44aa-a96b-abb15e998420)

#### Trial Balance Page
![image](https://github.com/user-attachments/assets/dad55430-68f8-4bd9-9bbd-893492c26003)



