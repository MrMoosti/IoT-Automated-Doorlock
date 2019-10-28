<h1  align="center">IoT Smart Door</h1>

IoT SmartDoor is an application made by a student. It is open source and free. It's made in C# and Angular(Ionic). The main program runs on C#, it simulates an door with an RFID scanner. The other C# program is an API that connects the Angular Project. Currently the programming is working fine, soon I will add more functionality to it like a relays and an electric door lock, these schematics will be uploaded as soon when it is ready.

# Preview

### Screenshots

| ![Logs](https://i.imgur.com/94lNXbr.png) | ![Door Status](https://i.imgur.com/pHafkkd.png) | ![CPU](https://i.imgur.com/nF1aycl.png) |
| ---------------------------------------- | ----------------------------------------------- | --------------------------------------- |


## Getting Started

In order to run **IoT SmarDoor** on your local machine all what you need to do is to have the prerequisites stated below installed on your machine and follow the installation steps down below.

#### Prerequisites

- AngularCLI
- Ionic
- Node.js
- Git
- Cordova
- .NET 3.0
- MongoDB

#### Installing & Local Development

Start by typing the following commands in your terminal in order to get **IoT SmartDoor** full package on your machine and starting a local development server with live reload feature.

1. Clone

```
> git clone https://github.com/MrMoosti/IoT-Automated-Doorlock.git IoT_SmartDoor
> cd IoT_SmartDoor
```

2. Database connections

Getting the database connected is a little trickier than the other directions here. First you should create an mongodb atlas account and a cluster with a database(It's free). I won't be showing how to do this step(unless you really need help, then make a request).

```
> Create a new database
> Create collections called, CpuLogs, Logs, Doors
> Go into your Doors collection
> Create a new item in your Doors collection
> New item consists of _id(ObjectId), Unixtime(Int32), Status(String)
> Save
```

4. Run the API

```
> cd IoT_Automated_Doorlock
> dotnet build
> cd Rfid/Api/RfidApi
> dotnet run
```

This will probably fail when doing an API call, turn off the API, look trough the debug folder there should be a folder called Configs open it and edit the .json file add your connection string from your MongoDB.

5. Run the SmartDoor Application

```
> cd IoT_Automated_Doorlock/Rfid/Scanner/RfidScanner
> dotnet run
```

6. Run the SmartDoor Mobile App

```
> cd SmartDoorApp
> npm install
> ionic serve
```

## Deployment

### SmartDoor Mobile Application

In deployment process, you have three commands these are for the mobile application:

1. Build command

Used to generate the final result of compiling source files into www folder. This can be achieved by running the following command:

```
> cd SmartDoorApp
> ionic build
```

3. Android Build command

Used to build your application for android devices.

```
> ionic cordova build android
```

4. IOS Build command

Used to build your application for IOS devices.

```
> ionic cordova build ios
```

### Raspberry Pi App

In this deployment process you only have one command that builds the application.

1. Build command

Used to generate the final result of compiling source files into dependency files and an runnable dll file. This can be achieved by doing this command:

```
> cd IoT_Automated_Doorlock/Rfid/Scanner/RfidScanner
> dotnet build (or release or publish depends on what u prefer)
> cd bin/debug(or release or publish depends on what u prefer)
> cd netcoreapp3.0/
> dotnet run RfidScanner.dll
```

### .NET Api

In this deployment process you only have one command that builds the api aswell.

1. Build command

Used to generate the final result of compiling source files into dependency files and a runnable dll file. This can be achieved by the following command:

```
> cd IoT_Automated_Doorlock/Rfid/Api/RfidApi
> dotnet build (or release or publish depends on what u prefer)
> cd bin/debug(or release or publish depends on what u prefer)
> cd netcoreapp3.0/
> dotnet run RfidApi.dll
```

## Changelog

#### V 1.0.0

Functional without any relay or electric door

- Working mobile application
- Api that connects to MongoDB
- Working RFID scanner application

## Authors

- [M.E. Yilmaz](https://www.meyilmaz.com)

## License

Adminator is licensed under The MIT License (MIT). Which means that you can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the final products.
