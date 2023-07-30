# KendoEmailAppSharp
KendoEmailAppSharp is a .NET Core library for working with the Kendo email API. It provides a high-level interface for getting.

### Installation
You can install KendoEmailAppSharp using NuGet:
```shell
dotnet add package KendoEmailAppSharp
```

### Usage
To use **KendoEmailAppSharp**, you will need to create an instance of the KendoEmailClient class and call its methods to interact with the Kendo email API.

Here's an example of how to retrieve email information for a specific email:

```csharp
using KendoEmailAppSharp;

string apiKey = "your-api-key";
var client = new KendoClient(apiKey);
var leads = await client.CompanyLeads("apple.com", 10);

foreach (var lead in leads)
{
    Console.WriteLine(lead.WorkEmail);
}

```

### Documentation
You can find the full API specifications for the Kendo email API [here](https://kendoemailapp.com/api-specs).

### Contributing
If you would like to contribute to this project, please fork the repository and submit a pull request.

### License
This project is licensed under the MIT License - see the LICENSE file for details.

