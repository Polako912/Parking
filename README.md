# Parking API
### Requirements:
- Park vehicle
- Exit vehicle
- Calculate parking charge on exit
- Count free and occupied spaces

### Local Setup
Database is EF InMemory so no extra set up needed, before you start the API you may want to change initial DB data, to do so you can edit this file as you wish:
`Parking.Infrastructure/DataGenerator`

### Assumptions:
- `Every 5 minutes an additional charge of £1 will be added` used `Math.Floor()` for calculation
- API has public access
- Basic error handling - no domain exceptions
- Time of parking and exit in local time - as enhancment it would be best to store in DB time in UTC and convrert it into local when returning response

### Questions:
- Is my approach to calculate charge correct?
- Is some extra validation needed for parking/exiting vehicle?
