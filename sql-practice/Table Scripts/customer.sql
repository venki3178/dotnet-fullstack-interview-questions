-- =====================================================
-- Script Name : customer_seed.sql
-- Description : Creates and seeds the customer table
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
    WHERE name = 'customer'
      AND schema_id = SCHEMA_ID('dbo')
)
BEGIN
    CREATE TABLE dbo.customer (
        id INT NOT NULL,
        name VARCHAR(100) NOT NULL,
        referee_id INT NULL,
        CONSTRAINT PK_customer PRIMARY KEY (id)
    );
END;
GO

-- =========================
-- Insert Seed Data
-- =========================
INSERT INTO dbo.customer (id, name, referee_id)
VALUES
    (100, 'Genovera', 133),
    (101, 'Melodie', 101),
    (102, 'Teddie', 195),
    (103, 'Gwenneth', 102),
    (104, 'Karolina', 191),
    (105, 'Pearline', 159),
    (106, 'Daryl', 102);
GO

-- =========================
-- Validation Query (Optional)
-- =========================
-- SELECT * FROM dbo.customer;
