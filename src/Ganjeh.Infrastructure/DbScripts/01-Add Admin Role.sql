IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE Name = 'Admin')
BEGIN 
	INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
	VALUES (NEWID(), 'Admin', 'Admin', NEWID())
END
GO