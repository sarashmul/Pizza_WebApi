# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# העתקת קבצי הפתרון וקובצי הפרויקטים
COPY *.sln ./
COPY lesson2/*.csproj ./lesson2/
COPY MyServiceLib/*.csproj ./MyServiceLib/
COPY MyModelsLib/*.csproj ./MyModelsLib/
COPY MyFileServiceLib/*.csproj ./MyFileServiceLib/

# שיחזור תלותיות
RUN dotnet restore

# העתקת שאר הקוד
COPY . .

# בנייה ופרסום
RUN dotnet publish lesson2 -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "lesson2.dll"]
