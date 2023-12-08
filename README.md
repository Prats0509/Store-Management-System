
# Store Dutta Matta
Author: Pratiksha Dutta and Gurleen Kaur Matta
## Note:
- The point of entry : StartProgram() function
- Added name after logging (Bonus)
- Added current date after logging (Bonus)
- Added modify a product using Name/ID (Bonus)

## Structs

- **Employee**
  - Represents an employee with a unique ID and password.
- **Client**
  - Represents a client with a unique ID, first name, last name, and password.
- **Product**
  - Represents a product with a unique ID, name, unit price, and available quantity.
- **Purchase**
  - Represents a purchase made by a client, containing client details, purchased products, subtotal, taxes, and total price.

## Array Storage and Constants

- `MAXPRODUCTS`: Maximum number of products stored.
- `MAXCLIENTS`: Maximum number of clients stored.
- `MAXPURCHASES`: Maximum number of purchases stored.
- `productsCount`, `clientsCount`, `purchasesCount`: Track the count of products, clients, and purchases.
- Employee `employee` : Holds employee information.
- Arrays:
  - `client[]`: Holds client information.
  - `product[]`: Holds product information.
  - `purchase[]`: Holds purchase information.
- Default data:
  - Default employee ID and password.
  - Default client password.

## Input Validations

- Functions to ensure valid input for integers and doubles within specified ranges.
- Function to read non-empty strings.

## Initialization of Default Data

- Initializes default employee, products, clients, and a sample purchase.

## Menu Displays

- Menu displays for main, role-based (employee or client), and specific functionalities.

## Client and Employee Verification

- Functions to verify client and employee credentials based on provided IDs and passwords.

## Client Functionality

- Display all products.
- Display purchases for a specific client.
- Client menu handling for respective functionalities.

## Employee Functionality

- Create, modify products.
- Display all products sorted by ID.
- Create, modify clients.
- Display all clients sorted by ID.
- Sell products.
- Display all sales.
- Display total sales.
- Employee menu handling for respective functionalities.

## Exit Application Functionality

- Safe exit option with confirmation prompt.

## App Functionality (StartProgram)

- Core function to run the logic of the application.
- Handles main menu, role selection, and respective functionality for employees and clients.
- Entry point: `Main()` function initializes default data and starts the program.

