# EmpSkillHub

Initialize Project and DB-Setup

1. Update connection string in EmpSkillHub.Web/appsettings.json
   <img width="1220" height="399" alt="image" src="https://github.com/user-attachments/assets/504f48f5-e1cf-4d73-9db5-24ccb786cbf5" />
  - Select LocalConnection/CloudConnection in UseConnection in AppSettings.

2. in Package Manager Console (inside .\EmpSkillHub.Data) run the below commands :
  - dotnet ef migrations add InitialCreate
  - dotnet ef database update

