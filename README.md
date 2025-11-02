# Parking API
### Requirements:
- Allocating vehicles to the first available space
- Determine the number of available and full spaces
- Determine the parking charge on vehicle exit
- De-Allocate a space on vehicle exit
- Vehicles will be charged per minute they are parked
- The parking charges are: 
  - Small Car - £0.10/minute (1)
  - Medium Car - £0.20/minute (2)
  - Large Car £0.40/minute (3)
- Every 5 minutes an additional charge of £1 will be added
- The Vehicle Type argument should be either 1, 2 or 3

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
