


(according to)[https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell]
First of all resotre all nuget packages

Add these to the csproj

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.App" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.3" />
  <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="3.1.2" />
</ItemGroup>
```

Then in the Package Manage console I typed

```ps
Install-Package Microsoft.EntityFrameworkCore.Tools
Update-Package Microsoft.EntityFrameworkCore.Tools
```

I had to run this command on the project, 

```
dotnet ef migrations add InitialCreate --project .\DilaRepository\DilaRepository.csproj
```

> Your startup project 'DilaRepository' doesn't reference Microsoft.EntityFrameworkCore.Design

So I added that nuget package  and ran the command again 

```
dotnet ef migrations add InitialCreate --project .\DilaRepository\DilaRepository.csproj
```

> Unable to create an object of type 'DilaContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

So I read the (article)[https://docs.microsoft.com/en-gb/ef/core/miscellaneous/cli/dbcontext-creation] and apparently there are more things required in the context to make this work


