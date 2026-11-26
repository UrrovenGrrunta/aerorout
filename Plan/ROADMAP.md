# AeroRoute — Development Roadmap

**Status:** Planning / new implementation  
**Primary branch:** `main`  
**Version target:** v1.0

AeroRoute is an independent C#/.NET application for estimating a direct flight between two airports. Its initial scope is deliberately limited so it can be completed, tested, and documented for the college assessment while remaining extensible afterwards.

The earlier Python flight-planning project is a **functional reference only**: AeroRoute is not a port and does not inherit its architecture or implementation.

## Agreed requirements

### Core functionality

- Accept departure and arrival ICAO airport codes.
- Look up both airports in a local CSV database loaded into memory at application startup; no network/API access is required for core functionality.
- Represent each airport as a typed object with readable properties such as `airport.Name`, `airport.Latitude`, and `airport.Longitude`.
- Use the Haversine formula to calculate direct great-circle distance in nautical miles (NM).
- Accept user-entered ground speed in knots (kt).
- Estimate flight time as distance / ground speed.
- Show the airport names, a direct route such as `EGPD DCT EGLL`, distance to **two decimal places**, and estimated time as `HH:MM` rounded to the nearest minute.
- Offer export of the calculated route to a `.txt` file containing airport ICAOs, names, distance, ground speed, and estimated time.

### Input and error handling

- ICAO input must contain **exactly four Latin letters** (`A–Z`/`a–z`). Mixed or lowercase input is accepted and normalized to uppercase during processing.
- Each ICAO must exist in the loaded airport database.
- Ground speed must be a positive number.
- Show a clear error and exit for invalid input, missing/unreadable CSV files, or other handled failures.
- Re-prompting after an error is **not required** in v1.0.

### User interface and design

- **Initial interface:** console (CLI).
- **CLI flow:** departure ICAO → arrival ICAO → ground speed → validation/calculation → results → optional TXT export → exit.
- Generating another route in the same session is not required for v1.0.
- Keep calculations and data-handling logic independent of console input/output, allowing automated testing and a possible later GUI.
- **GUI framework:** TBD.
- **GUI architecture:** TBD.
- **Airport object form (class/record):** TBD during implementation.
- **In-memory airport collection:** TBD during implementation.
- **CSV parsing approach:** TBD during implementation.
- Do not add unnecessary interfaces, layers, or frameworks without a concrete need.

### Testing

- **Automated test framework:** xUnit (works with Visual Studio and JetBrains Rider).
- Unit tests for ICAO/ground-speed validation, distance, and flight-time calculations.
- Integration tests for CSV loading, airport lookup, and TXT export.
- Run regression tests after relevant changes.
- Manually check the CLI flow and error messages.
- **Workflow:** implement each feature, then add and run its tests before marking the task complete.
- Prepare assessment-specific test plan, test log, error log, and usability-testing evidence separately.

## Implementation checklist

### Phase 0 — Planning and assessment alignment

- [x] Agree on the v1.0 scope and constraints.
- [x] Establish a clean `main` branch and retain the old implementation in `legacy`.
- [x] Add a project README and Visual Studio-oriented `.gitignore`.
- [x] Choose xUnit as the test framework.
- [ ] Review the college assessment checklist against the planned implementation.
- [ ] Ask the lecturer how the **two required event handlers** should be demonstrated, and whether a CLI satisfies the assessment; adjust the interface plan if necessary.
- [ ] Draft requirements analysis and detailed design (including storyboard/interface description, algorithm or pseudocode, data dictionary, and functions).

### Phase 1 — Project foundations

- [ ] Confirm the C# project builds and runs as a CLI application.
- [ ] Set up an xUnit test project.
- [ ] Establish a simple separation between console interaction and reusable logic, without committing prematurely to a complex architecture.

### Phase 2 — Input and airport data

- [ ] Implement ICAO validation and normalization.
- [ ] Implement ground-speed validation.
- [ ] Add tests for both validators.
- [ ] Define the typed airport model with property access.
- [ ] Read airport records from the local CSV and store them in memory.
- [ ] Look up airports by normalized ICAO.
- [ ] Handle missing/unreadable CSV files and missing airports with clear errors.
- [ ] Add tests for database loading and lookup.

### Phase 3 — Route calculations

- [ ] Implement direct great-circle distance using Haversine.
- [ ] Report distance in NM to two decimal places.
- [ ] Implement estimated flight time from distance and ground speed; display `HH:MM` rounded to the nearest minute.
- [ ] Add calculation tests using known inputs and expected results.

### Phase 4 — CLI flow

- [ ] Prompt for departure ICAO, arrival ICAO, and ground speed in the approved order.
- [ ] Validate input and resolve airport records.
- [ ] Display the route (`ICAO DCT ICAO`), airport names, distance, and time.
- [ ] Display readable errors and exit rather than requiring retries.
- [ ] Manually verify the full flow.

### Phase 5 — File export

- [ ] Offer the user a choice to save the completed route.
- [ ] Write a readable `.txt` report with both airports, distance, ground speed, and flight time.
- [ ] Test exported content and file-writing failures.

### Phase 6 — College assessment and release

- [ ] Verify the assessment's technical criteria, including **two event handlers**, standard libraries, arrays, operators, selection and repetition, modularity, parameters, file I/O, error handling, and algorithms.
- [ ] Implement any assessment-required event-handling approach confirmed with the lecturer, without unnecessary features.
- [ ] Complete requirements analysis and detailed design documents.
- [ ] Complete test plan, test log, error log, and usability testing, including findings and recommendations.
- [ ] Write user instructions and collect screenshots or video of the running application.
- [ ] Run the complete xUnit suite and perform final manual/regression tests.
- [ ] Update README to reflect what is actually implemented, and mark v1.0 complete when all approved requirements are met.

## Working rules

1. Work on **one clearly specified task at a time**, with acceptance criteria agreed before review.
2. Implement first; write tests for that feature afterwards.
3. Review against the actual task and assessment requirements, not hypothetical production-grade edge cases.
4. Refactor where useful before committing.
5. Aim for **one commit per completed feature or coherent milestone** on `main`.
6. Update the README and assessment documentation as functionality becomes real.
7. Keep `legacy` as an archive; do not use old code as the new implementation's blueprint.

## Beyond v1.0 — Backlog only

These are **not** requirements for the initial release:

- GUI application (framework and architecture **TBD**, unless required earlier for the assessment).
- Import/export of Microsoft Flight Simulator `.pln` files.
- Multi-leg routes and intermediate waypoints.
- Airways, SIDs, and STARs.
- SimBrief or other external integrations.
- Wind, altitude, and aircraft-performance modelling.

## Safety and limitations

AeroRoute provides simplified calculations for educational/simulation use. A direct great-circle route and constant-ground-speed estimate do not account for operational navigation constraints, winds, procedures, or aircraft limitations. **Do not use AeroRoute for real-world flight navigation or operations.**
