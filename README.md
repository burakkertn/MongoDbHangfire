# Project Name

You can change the name of the project.

## Getting Started

This project is a .NET Core application designed to perform specific functions. Follow the steps below to set up the project on your local machine.

### Prerequisites

You will need the following software installed on your machine to run this project:

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Installation

1. Clone the repository:
    ```sh
    git clone [https://github.com/username/project-name.git](https://github.com/burakkertn/ProjectName.git)
    cd ProjectName
    ```

2. Restore the required NuGet packages:
    ```sh
    dotnet add package Hangfire
    dotnet add package Hangfire.AspNetCore
    dotnet add package Hangfire.Mongo
    dotnet restore
    ```

3. Configure the `appsettings.json` file. For example:
    ```json
    {
      "MongoDbSettings": {
        "Username": "#",
        "Password": "#",
        "Host": "#",
        "Port": 1,
        "Database": "#"
      }
    }
    ```
4. Run the project:
    ```sh
    dotnet run
    ```
## Contributing

If you want to contribute, please open a pull request or create an issue.


