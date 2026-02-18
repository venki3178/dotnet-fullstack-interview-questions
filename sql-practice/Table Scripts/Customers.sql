--Q2. Write an SQL query to report the unique customers with postive revenue in the year 2021.
--Note: Use distinct operator to get unique values.

-- =====================================================
-- Script Name : customers_seed.sql
-- Description : Creates Customers table and inserts seed data
-- Author      : <Your Name / Team>
-- Created On  : 2025-12-27
-- Environment : Production
-- Database    : SQL Server
-- =====================================================

-- =========================
-- Create Table (Idempotent)
-- =========================
IF NOT EXISTS (
    SELECT 1
    FROM sys.tables
    WHERE name = 'Customers'
      AND schema_id = SCHEMA_ID('dbo')
)
BEGIN
    CREATE TABLE dbo.Customers (
        customer_id INT NOT NULL,
        [year] INT NOT NULL,
        revenue INT NOT NULL,

        CONSTRAINT PK_Customers PRIMARY KEY (customer_id, [year])
    );
END;
GO

-- =========================
-- Insert Seed Data
-- =========================
INSERT INTO dbo.Customers (customer_id, [year], revenue)
VALUES
    (108, 2021, -1),
    (106, 2019, 15),
    (102, 2019, -2),
    (100, 2021, 4);
GO

-- =========================
-- Validation Query (Optional)
-- =========================
-- SELECT * FROM dbo.Customers;
