set file_name=%1
shift

dotnet run --project Potato.Ar.Api.Examples.csproj %file_name% %*
