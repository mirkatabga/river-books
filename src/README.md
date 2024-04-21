##Add Migration 
`dotnet ef migrations add Initial -c BooksDbContext -p ..\Books\Books.csproj -s .\Api.csproj -o ..\Books\Infrastructure\Persistence\Migrations`

##Run Migration
`dotnet ef database update`