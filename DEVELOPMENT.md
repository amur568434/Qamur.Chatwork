# Development of Qamur.Chatwork.


The desciprtions for development of Qamur.Chatwork.


## Projects
- **Qamur.Chatwork** - The main project.
- **Qamut.Chatwork.Test** - The test project for Qamur.Chatwork.

##  How to build.
Select and execute one of the following.
- Build from Visual  Studio.
- Src/build.ps1
- Src/build.sh
- dotnet build Src/Qamur.Chatwork --configuration Release

## How to tun tests.

Put and edit **test_setting.json** file in **Src/Qamur.Chatwork.Test**.

```
{
  // The API token.
  "token": "your_api_token",

  // The owner's mychat room id.
  "room": 1111,

  // The owner's account id.
  "account_id": 11111,

  // The chat room id list.
  "rooms": [
    111111
  ],

  // The member account id list.
  "members": [
    1111111
  ]
}

```

Select and execute one of the following.
- Run from Visual Studio.
- Src/test.ps1
- Src/test.sh
- dotnet test Src/Qamur.Chatwork.Test

## License
[Apache License, Version 2.0](./LICENSE)

## Author
[Kohei Oizumi](https://github.com/amur568434)
