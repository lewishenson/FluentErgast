# FluentErgast

Fluent C# API for the Ergast Developer API.

## Exposed Data

* Driver Standings
* Constructor Standings

## Usage

Getting driver standings for a whole season:

```csharp
var driverStandings = await FluentErgast.F1.DriverStandings.ForYearAsync(2009);
```

Getting driver standings at a particular point in a season:

```csharp
var driverStandings = await FluentErgast.F1.DriverStandings.ForRound(3).ForYearAsync(2014);
```

Getting constructor standings for a whole season:

```csharp
var constructorStandings = await FluentErgast.F1.ConstructorStandings.ForYearAsync(2016);
```

Getting constructor standings at a particular point in a season:

```csharp
var constructorStandings = await FluentErgast.F1.ConstructorStandings.ForRound(1).ForYearAsync(2016);
```