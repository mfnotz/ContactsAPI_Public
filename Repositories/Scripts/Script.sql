INSERT INTO [ContactsAppDb].[dbo].[Contacts]([Id],
[FirstName]
  ,[LastName]
  ,[FullName]
  ,[Address]
  ,[Email]
  ,[MobilePhoneNumber]
  ,[DateOfBirth]
  ,[UserId], [LastModified], [LastModifiedBy])
  VALUES ('ADM', 'Martin', 'Notz', 'Martin Notz', 'Fake Street 123', 'notz.martin@gmail.com', '+353 087 348 4005', '1989-08-28', 'ADM', GetDate(), 'ADM')
	  
INSERT INTO [ContactsAppDb].[dbo].[Contacts]([Id],
[FirstName]
  ,[LastName]
  ,[FullName]
  ,[Address]
  ,[Email]
  ,[MobilePhoneNumber]
  ,[DateOfBirth]
  ,[UserId], [LastModified], [LastModifiedBy])
  VALUES ('USR', 'Metin', 'Melekli', 'Metin Melekli', 'Fake Street 1234', 'fake@email.com', '+34 971 971 971', '1990-06-28', null, GetDate(), 'ADM')
  

INSERT INTO [ContactsAppDb].[dbo].[Users]
  ([Id], [UserName]
      ,[Email]
      ,[LastModified]
      ,[Password]
      ,[IsActive], [ContactId], [LastModifiedBy], [IsAdmin])
  VALUES
  ('ADM', 'MNOTZ', 'notz.martin@gmail.com', GetDate(), 'carioca', 1, 'ADM', 'ADM', 1)