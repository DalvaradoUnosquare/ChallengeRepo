SELECT [UserID]
      ,[Sid]
      ,[UserType]
      ,[AuthType]
      ,[UserName]
FROM 
  [ReportServer$SQLEXPRESS].[dbo].[Users]
WHERE 
    UserName LIKE '%@CurrenUserNameVariable%'