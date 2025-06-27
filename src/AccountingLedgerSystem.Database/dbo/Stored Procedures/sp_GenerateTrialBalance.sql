
        CREATE PROCEDURE [dbo].[sp_GenerateTrialBalance]
            @AsOfDate DATE = NULL,
            @IncludeZeroBalances BIT = 0
        AS
        BEGIN
            SET NOCOUNT ON;

            IF @AsOfDate IS NULL
                SET @AsOfDate = GETDATE();

            CREATE TABLE #TrialBalance (
                AccountId INT,
                AccountName NVARCHAR(100),
                AccountType NVARCHAR(50),
                DebitTotal DECIMAL(18, 2) DEFAULT 0,
                CreditTotal DECIMAL(18, 2) DEFAULT 0,
                NetBalance DECIMAL(18, 2) DEFAULT 0,
                BalanceType NVARCHAR(10)
            );

            INSERT INTO #TrialBalance (AccountId, AccountName, AccountType, DebitTotal, CreditTotal)
            SELECT 
                a.Id,
                a.Name,
                CASE a.Type
                    WHEN 1 THEN 'Asset'
                    WHEN 2 THEN 'Liability'
                    WHEN 3 THEN 'Equity'
                    WHEN 4 THEN 'Revenue'
                    WHEN 5 THEN 'Expense'
                END,
                SUM(jel.Debit),
                SUM(jel.Credit)
            FROM 
                Accounts a
                LEFT JOIN JournalEntryLines jel ON a.Id = jel.AccountId
                LEFT JOIN JournalEntries je ON jel.JournalEntryId = je.Id
            GROUP BY 
                a.Id, a.Name, a.Type;

            UPDATE #TrialBalance
            SET 
                NetBalance = CASE 
                                WHEN AccountType IN ('Asset', 'Expense') THEN DebitTotal - CreditTotal
                                ELSE CreditTotal - DebitTotal
                            END,
                BalanceType = CASE 
                                WHEN AccountType IN ('Asset', 'Expense') THEN 
                                    CASE WHEN (DebitTotal - CreditTotal) >= 0 THEN 'Debit' ELSE 'Credit' END
                                ELSE 
                                    CASE WHEN (CreditTotal - DebitTotal) >= 0 THEN 'Credit' ELSE 'Debit' END
                             END;

            SELECT 
                AccountId,
                AccountName,
                AccountType,
                DebitTotal,
                CreditTotal,
                ABS(NetBalance) AS Balance,
                BalanceType,
                CASE 
                    WHEN AccountType IN ('Revenue', 'Expense') THEN 'Income Statement'
                    ELSE 'Balance Sheet'
                END AS FinancialStatement
            FROM 
                #TrialBalance
            WHERE 
                @IncludeZeroBalances = 1 OR (DebitTotal <> 0 OR CreditTotal <> 0)
            ORDER BY 
                AccountType, AccountName;

            DROP TABLE #TrialBalance;
        END
        
