# AeroRoute

AeroRoute is a C# application for planning simple flights between airports. It is intended to make basic route information easy to calculate and understand without requiring a full flight-planning suite.

## Purpose

Given a departure airport, a destination airport, and a ground speed, AeroRoute aims to provide useful information for a direct flight. It focuses on straightforward calculations and an approachable interface rather than real-world operational flight planning.

## Planned functionality

- Enter departure and arrival airports by their four-letter ICAO codes.
- Look up airports and their geographic coordinates using a local data file.
- Calculate the direct great-circle distance between two airports in nautical miles.
- Estimate flight time using the calculated distance and a user-provided ground speed in knots.
- Validate input and report errors clearly.
- Save route information to a file.

The initial application will be deliberately small. Additional functionality may be considered as the project develops.

## Technology

- **Language:** C#
- **Platform:** .NET
- **Data source:** Local airport data in CSV format

The user interface and exact technical design have not yet been finalised.

## Project status

**Planning / fresh implementation.** The current `main` branch is being built from scratch; the features above are goals, not claims about completed functionality.

The previous experimental implementation is preserved in the [`legacy` branch](https://github.com/UrrovenGrrunta/aerorout/tree/legacy).

## Scope and limitations

AeroRoute is a learning and development project. Direct-distance and time estimates are simplified calculations; they do not account for winds, airways, restricted airspace, aircraft performance, or operational requirements.

**AeroRoute is not intended for real-world flight navigation or flight operations.**
