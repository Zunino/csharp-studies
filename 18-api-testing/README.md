# ASP.NET Core Integration Tests

Based on https://youtu.be/7roqteWLw4s

Andre Zunino <neyzunino@gmail.com>
16 April 2020

## Setup

```sh
mkdir src test

dotnet new sln

dotnet new webapi -o src/CSharp.Studies.n18.Games.Api
dotnet new xunit -o test/CSharp.Studies.n18.Games.Api.Test

dotnet sln <SLN_FILE> add src/CSharp.Studies.n18.Games.Api
dotnet sln <SLN_FILE> add test/CSharp.Studies.n18.Games.Api.Test

dotnet add test/CSharp.Studies.n18.Games.Api.Test/ reference src/CSharp.Studies.n18.Games.Api/

dotnet add test/CSharp.Studies.n18.Games.Api.Test/ package Microsoft.AspNetCore.Mvc.Testing
dotnet add test/CSharp.Studies.n18.Games.Api.Test/ package xunit
dotnet add test/CSharp.Studies.n18.Games.Api.Test/ package FluentAssertions

```
