namespace Store_Dutta_Kaur
{
    #region Structs -@Pratiksha

    // Struct for Employee -@Pratiksha.
    struct Employee
    {
        public int UniqueId;
        public string Password;
        //primary constructor for structure Employee -@Pratiksha
        public Employee(int uniqueId, string password)
        {
            UniqueId = uniqueId;
            Password = password;
        }
    }

    // Struct for Client  -@Pratiksha 
    struct Client
    {
        public int UniqueId;
        public string FirstName;
        public string LastName;
        public string Password;
        //primary constructor for structure Client -@Pratiksha
        public Client(int uniqueId, string firstName, string lastName, string password)
        {
            UniqueId = uniqueId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }

    // Struct for Product -@Pratiksha
    struct Product
    {
        public int UniqueId;
        public string Name;
        public double UnitPrice;
        public int QuantityAvailable;
        //primary constructor for structure Product -@Pratiksha
        public Product(int uniqueId, string name, double unitPrice, int quantityAvailable)
        {
            UniqueId = uniqueId;
            Name = name;
            UnitPrice = unitPrice;
            QuantityAvailable = quantityAvailable;
        }
    }

    // Struct for Purchase -@Pratiksha
    struct Purchase
    {
        public Client Client;
        public Product[] Products;
        public double Subtotal;
        public double Taxes;
        public double TotalPrice;
        //primary constructor for structure Product -@Pratiksha
        public Purchase(Client client, Product[] products, double subtotal, double taxes, double totalPrice)
        {
            Client = client;
            Products = products;
            Subtotal = subtotal;
            Taxes = taxes;
            TotalPrice = totalPrice;
        }
    }

    #endregion
    internal class Program
    {
        #region Array Storage and constants -@Pratiksha and -@Gurleen
        // Constants and Variables for default data -@Gurleen
        const int maxProducts = 100;
        static int productsCount = 0;
        const int maxClients = 10;
        static int clientsCount = 0;
        const int maxPurchases = 100;
        static int purchasesCount = 0;

        // Variable to store employee -@Gurleen
        static Employee employee;
        // Array to hold clients -@Pratiksha and -@Gurleen
        static Client[] client = new Client[maxClients];
        // Array to hold products -@Pratiksha and -@Gurleen
        static Product[] product = new Product[maxProducts];
        // Array to hold sales -@Pratiksha and -@Gurleen
        static Purchase[] sale = new Purchase[maxPurchases];

        // Constants for default data -@Pratiksha
        const int defaultEmployeeId = 111111;
        const string defaultEmployeePassword = "tester";
        const string defaultClientPassword = "clientPass";


        #endregion 

        #region Input Validations -@Pratiksha 
        //Function to read an Integer , if not retry with error message
        static int readInteger()
        {
            int toReturn = 0;
            while (!Int32.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid integer value, please try again: ");
            }

            return toReturn;
        }

        //Function to ReadInteger within a range
        static int readInteger(int min, int max)
        {
            int toReturn = readInteger();
            while (!isWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = readInteger();
            }

            return toReturn;
        }

        //Function to check if in range
        static bool isWithinRange(int num, int min, int max)
        {
            return num >= min && num <= max;
        }

        //Function to read a double
        static double readDouble()
        {
            double toReturn = 0;
            while (!Double.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid real value, please try again: ");
            }

            return toReturn;
        }

        //Function to read a double in a range
        static double readDouble(double min, double max)
        {
            double toReturn = readDouble();
            while (!isWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = readDouble();
            }

            return toReturn;
        }

        //Function to check if double is within the range
        static bool isWithinRange(double num, double min, double max)
        {
            return num >= min && num <= max;
        }

        //Function to read a string or retry is empty or null
        static string readString()
        {
            string toReturn = null;
            do
            {
                toReturn = Console.ReadLine();
                if (toReturn == null)
                    Console.Write("Invalid string value, please try again: ");
            } while (String.IsNullOrEmpty(toReturn));

            return toReturn;
        }

        #endregion

        #region Initialize default data -@Pratiksha and -@Gurleen
        static void initializeDefaultData()
        {
            // Initialize default employee -@Gurleen
            employee = new Employee(defaultEmployeeId, defaultEmployeePassword);

            // Initialize default products -@Pratiksha
            product[0] = new Product(100001, "Product 1", 10.99, 50);
            product[1] = new Product(100002, "Product 2", 5.75, 30);
            product[2] = new Product(100003, "Product 3", 7.49, 25);
            product[3] = new Product(100004, "Product 4", 15.25, 40);
            product[4] = new Product(100005, "Product 5", 3.99, 20);
            product[5] = new Product(100006, "Product 6", 8.50, 60);
            product[6] = new Product(100007, "Product 7", 12.75, 35);
            product[7] = new Product(100008, "Product 8", 6.80, 45);
            product[8] = new Product(100009, "Product 9", 4.25, 55);
            product[9] = new Product(100010, "Product 10", 9.99, 70);

            // Initialize default client -@Pratiksha
            client[0] = new Client(100001, "Default", "Client", defaultClientPassword);

            // Initialize default products count -@Gurleen
            productsCount = 10;

            // Initialize default clients count -@Gurleen
            clientsCount = 1;

        }
        #endregion

        #region Menu Displays -@Pratiksha and -@Gurleen
        //function to display the main menu lines -@Pratiksha
        static void displayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Exit Application");
            Console.WriteLine("Please enter the appropriate option");
        }
        //function to display the role menu lines -@Pratiksha
        static void displayRoleMenu()
        {
            Console.WriteLine("1.Employee");
            Console.WriteLine("2.Client");
            Console.WriteLine("Please enter the appropriate option");
        }
        //function to display the client menu lines -@Pratiksha
        static void displayClientMenu()
        {
            Console.WriteLine("1.Display all products");
            Console.WriteLine("2.Display purchases");
            Console.WriteLine("3.Sign Out");
            Console.WriteLine("Please enter the appropriate option (1-3)");
        }

        //function to display the employee menu lines -@Gurleen
        static void displayEmployeeMenu()
        {
            Console.WriteLine("1. Create products");
            Console.WriteLine("2. Modify one product");
            Console.WriteLine("3. Display all the products sorted by ID");
            Console.WriteLine("4. Create a client");
            Console.WriteLine("5. Modify a client");
            Console.WriteLine("6. Display all the clients sorted by ID");
            Console.WriteLine("7. Sell");
            Console.WriteLine("8. Display all the sales");
            Console.WriteLine("9. Display total of sales");
            Console.WriteLine("10. Sign Out: to return to the main menu");
            Console.WriteLine("Please enter the appropriate option (1-10)");
        }
        #endregion

        #region Client Verification -@Pratiksha
        //function to get the password from console and verify length -@Pratiksha
        static string getPassword()
        {
            {
                string toReturn = null;
                while (String.IsNullOrEmpty(toReturn) || toReturn.Length < 6 || toReturn.Length > 10)
                {
                    toReturn = Console.ReadLine();
                }

                return toReturn;
            }
        }
        /** function to check the unique ID and password and return
        the client if found or return a client with ID 0  -@Pratiksha
        **/
        static Client verifyClient()
        {
            Console.WriteLine("Enter Client ID:");
            //read an interger between 100000 and 999999 -@Pratiksha
            int clientId = readInteger(100000, 999999);

            //read a string which is not empty or null -@Pratiksha
            Console.WriteLine("Enter Password:");
            string password = getPassword();

            //for loop to go throught the record and match -@Pratiksha
            for (int i = 0; i < client.Length; i++)
            {
                if (client[i].UniqueId == clientId && client[i].Password == password)
                {
                    return client[i]; // Return verified client -@Pratiksha
                }
            }
            // Return a Client with ID 0 if verify fails -@Pratiksha
            return new Client { UniqueId = 0 };
        }
        #endregion

        #region Employee Verification -@Gurleen
        /** function to check the unique ID and password and return
        the employee if found or return a employee with ID 0  -@Gurleen
        **/
        static Employee verifyEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            //read an interger between 100000 and 999999 -@Gurleen
            int employeeId = readInteger(100000, 999999);

            //read a string which is not empty or null -@Gurleen
            Console.WriteLine("Enter Password:");
            string password = getPassword();

            //Verify the employee record and match -@Gurleen
            if (employeeId == defaultEmployeeId && password == defaultEmployeePassword)
            {
                return employee; // Return verified client -@Gurleen
            }
            // Return a Client with ID 0 if verify fails -@Gurleen
            return new Employee { UniqueId = 0 };
        }
        #endregion

        #region Client Functionality -@Pratiksha
        //function to display all products -@Pratiksha
        static void displayAllProducts()
        {
            Console.WriteLine("List of Products:");

            for (int i = 0; i < product.Length; i++)
            {
                Product productInfo = product[i];
                Console.WriteLine($"ID: {productInfo.UniqueId}, Name: {productInfo.Name}, Price: {productInfo.UnitPrice}, Quantity Available: {productInfo.QuantityAvailable}");
            }
        }

        //function to display purchases -@Pratiksha
        static void displayPurchases()
        {
            throw new NotImplementedException();
        }

        //function to display Client Menu and perform client functions -@Pratiksha
        static void handleClientFunctionality(Client client)
        {
            bool exit = false;

            while (!exit)
            {

                //function to client menu -@Pratiksha
                displayClientMenu();

                //read the choice between 1 and 3 from the menu -@Pratiksha
                int getChoice = readInteger(1, 3);

                //switch statement for handling client functions -@Pratikha
                switch (getChoice)
                {
                    case 1:
                        displayAllProducts();
                        break;
                    case 2:
                        displayPurchases();
                        break;
                    case 3:
                        exit = true;
                        Console.WriteLine("Signing out....");
                        break;
                }
            }
            if (exit)
            {
                // return to main menu after signing out -@Pratikha
                startProgram();
            }
        }
        #endregion 

        #region Employee Functionality -@Gurleen and -@Pratiksha
        //function to create products -@Gurleen
        static void createProducts()
        {
            string createProducts = "YES";
            while (createProducts == "YES")
            {
                if (productsCount == maxProducts)
                {
                    Console.WriteLine("Unable to create more products, maximum products reached!");
                    break;
                }

                Console.WriteLine("Enter Product ID:");
                int productId = readInteger(100000, 999999);
                Console.WriteLine("Enter Product Name:");
                string productName = readString();
                Console.WriteLine("Enter Subtotal:");
                double unitPrice = readDouble();
                Console.WriteLine("Enter Quantity Available:");
                int quantityAvailable = readInteger();
                product[productsCount] = new Product(productId, productName, unitPrice, quantityAvailable);
                productsCount += 1;

                Console.WriteLine("Do you want to create more products (Type Yes):");
                createProducts = readString().ToUpper();
            }

        }

        //function to modify one product -@Gurleen
        static void modifyOneProduct()
        {
            Console.WriteLine("Enter Product ID:");
            int productId = readInteger(100000, 999999);
            //for loop to go through the products and match -@Gurleen
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].UniqueId == productId)
                {
                    Console.WriteLine("Enter Product Name:");
                    product[i].Name = readString();
                    Console.WriteLine("Enter Subtotal:");
                    product[i].UnitPrice = readDouble();
                    product[i].QuantityAvailable = readInteger();
                    Console.WriteLine("Enter Quantity Available:");
                    break;
                }
            }
            Console.WriteLine("Product not found!");
        }

        //function to display all products sorted by ID -@Pratiksha
        static void displayAllProductsSortedByID()
        {       
            // Sort the array based on ProductID 
            Array.Sort(product, (x, y) => x.UniqueId.CompareTo(y.UniqueId));

            // Display the sorted array using a for loop
            for (int i = 0; i < product.Length; i++)
            {
                Product Product = product[i];
                Console.WriteLine($"ID: {Product.UniqueId}, Name: {Product.Name}, Price: {Product.UnitPrice}, Quantity Available: {Product.QuantityAvailable}");
            }
        
        }

        //function to create a client -@Gurleen
        static void createAClient()
        {
            if (clientsCount == maxClients)
            {
                Console.WriteLine("Unable to create more clients, maximum clients reached!");
                return;
            }
            
            Console.WriteLine("Enter Client ID:");
            int clientId = readInteger(100000, 999999);
            Console.WriteLine("Enter First Name:");
            string firstName = readString();
            Console.WriteLine("Enter Last Name:");
            string lastName = readString();
            Console.WriteLine("Enter Password:");
            string password = readString();
            client[clientsCount] = new Client(clientId, firstName, lastName, password);
            clientsCount += 1;
            
        }

        //function to modify a client -@Gurleen
        static void modifyAClient()
        {
            Console.WriteLine("Enter Client ID:");
            int clientId = readInteger(100000, 999999);
            //for loop to go through the products and match -@Gurleen
            for (int i = 0; i < client.Length; i++)
            {
                if (client[i].UniqueId == clientId)
                {
                    Console.WriteLine("Enter First Name:");
                    client[i].FirstName = readString();
                    Console.WriteLine("Enter Last Name:");
                    client[i].LastName = readString();
                    Console.WriteLine("Enter Password:");
                    client[i].Password = readString();
                    break;
                }
            }
            Console.WriteLine("Client not found!");
        }

        //function to display all clients sorted by ID -@Pratiksha
        static void displayAllClientsSortedByID()
        {
                // Sort the array based on UniqueId using Comparison delegate
                Array.Sort(client, (x, y) => x.UniqueId.CompareTo(y.UniqueId));

                // Display the sorted array using a for loop
                for (int i = 0; i < client.Length; i++)
                {
                    Client Client = client[i];
                    Console.WriteLine($"ID: {Client.UniqueId}, Name: {Client.FirstName} {Client.LastName}");
                }      
        }

        //function to sell -@Gurleen
        static void sell()
        {
            if (purchasesCount == maxPurchases)
            {
                Console.WriteLine("Unable to create another purchase, maximum purchases reached!");
                return;
            }

            Console.WriteLine("Enter Client ID:");
            int clientId = readInteger(100000, 999999);
            Client c = new Client { UniqueId = 0 };
            //for loop to go through clients to search the correct client -@Gurleen
            for (int j = 0; j < client.Length; j++)
            {
                if (client[j].UniqueId == clientId) {
                    c = client[j];
                    break;
                }
            }
            if (c.UniqueId == 0)
            {
                Console.WriteLine("Client not found!");
                return;
            }

            double subtotal = 0;
            Console.WriteLine("Enter number of products sold:");
            int numOfProductsSold = readInteger(1, maxProducts);
            Product[] productsSold = new Product[numOfProductsSold];
            for (int i = 0; i < numOfProductsSold; i++)  
            {
                Product productToSell = new Product { UniqueId = 0 };
                while (productToSell.UniqueId == 0)
                {
                    Console.WriteLine("Enter Product ID:");
                    int productId = readInteger(100000, 999999);
                    //for loop to go through the products and match -@Gurleen
                    for (int j = 0; j < product.Length; j++)
                    {
                        if (product[j].UniqueId == productId)
                        {
                            productToSell = product[j];
                            int quantityAvailable = productToSell.QuantityAvailable;

                            Console.WriteLine("Enter Quantity Available:");
                            int quantitySold = readInteger(1, quantityAvailable);

                            productToSell = new Product(productId, productToSell.Name, productToSell.UnitPrice, quantitySold);
                            subtotal += (productToSell.UnitPrice * quantitySold);
                            productToSell -= quantitySold;
                            break;
                        }
                    }
                    if (productToSell.Name == null)
                        Console.WriteLine("Product not found, please try again.");
                }
            }

            // todo: need to ask about how much taxes we need to have
            double taxes = 0.15;
            double totalPrice = subtotal + subtotal * taxes;
            sale[purchasesCount] = new Purchase(c, productsSold, subtotal, taxes, totalPrice);
            purchasesCount += 1;
        }

        //function to display all sales -@Pratiksha
        static void displayAllSales()
        {
            for (int i = 0; i < sale.Length; i++)
            {
                var purchase = sale[i];

                Console.WriteLine($"Client: {purchase.Client.FirstName} {purchase.Client.LastName}");
                Console.WriteLine($"Products Purchased:");
                for (int j = 0; j < purchase.Products.Length; j++)
                {
                    var product = purchase.Products[j];
                    Console.WriteLine($"  - {product.Name}: ${product.UnitPrice}");
                }

                Console.WriteLine($"Subtotal: {purchase.Subtotal:$}, Taxes: {purchase.Taxes:$}, Total Price: {purchase.TotalPrice:$}");
                Console.WriteLine();
            }
        }

        //function to display total sales -@Gurleen
        static void displayTotalSales()
        {
            double totalSales = 0;

            // Calculate total sales by summing up the TotalPrice of each purchase
            for (int i = 0; i < sale.Length; i++)
            {
                totalSales += sale[i].TotalPrice;
            }

            Console.WriteLine($"Total Sales: ${totalSales}");
        }


        //function to display Employee Menu and perform employee functions -@Gurleen
        static void handleEmployeeFunctionality(Employee employee)
        {
            bool exit = false;
            while (!exit)
            {

                //function to client menu -@Gurleen
                displayEmployeeMenu();

                //read the choice between 1 and 3 from the menu -@Gurleen
                int getChoice = readInteger(1, 3);

                //switch statement for handling client functions -@Gurleen
                switch (getChoice)
                {
                    case 1:
                        createProducts();
                        break;
                    case 2:
                        modifyOneProduct();
                        break;
                    case 3:
                        displayAllProductsSortedByID();
                        break;
                    case 4:
                        createAClient();
                        break;
                    case 5:
                        modifyAClient();
                        break;
                    case 6:
                        displayAllClientsSortedByID();
                        break;
                    case 7:
                        sell();
                        break;
                    case 8:
                        displayAllSales();
                        break;
                    case 9:
                        displayTotalSales();
                        break;
                    case 10:
                        exit = true;
                        Console.WriteLine("Signing out....");
                        break;
                }
            }
            startProgram();
        }
        #endregion 

        #region Exit Application Functionality -@Pratiksha
        //Function to safely exit the application with confirmation -@Pratiksha
        static void exit()
        {
            Console.WriteLine("Are you sure you want to exit? (Type Yes)");
            string input = readString().ToUpper();
            if (input == "YES")
            {
                Console.WriteLine("Exiting the application...");
                Environment.Exit(0);
            }
        }
        #endregion

        #region App Functionality -@Pratiksha 

        //Core function to run the logic of the App -@Pratiksha (client) -@Gurleen (employee)
        static void startProgram()
        {
            //display the main menu and take the inputs  -@Pratiksha
            displayMainMenu();
            int choiceMainMenu = readInteger(1, 2);
            if (choiceMainMenu == 1)
            {
                //display the role menu and take the inputs  -@Pratiksha
                displayRoleMenu();
                int roleChoice = readInteger(1, 2);
                if (roleChoice == 1)
                {
                    // display employee and functions -@Gurleen
                    Employee employee = verifyEmployee();
                    if (employee.UniqueId != 0)
                    {
                        //handle the employee functionalities with menu -@Gurleen
                        handleEmployeeFunctionality(employee);
                    }
                    else
                    {
                        Console.WriteLine("Failed to authenticate user");
                        startProgram();
                    }
                }
                else if (roleChoice == 2)
                {
                    //verify the client by password -@Pratiksha
                    Client client = verifyClient();
                    if (client.UniqueId != 0)
                    {
                        //handle the client functioanlities with menu -@Pratiksha
                        handleClientFunctionality(client);
                    }
                    else
                    {
                        Console.WriteLine("Failed to authenticate user");
                        startProgram();
                    }

                }

            }
            else
            {
                Console.WriteLine("Exiting the application");
                exit();
            }

        }
        #endregion

        static void Main(string[] args)
        {
            initializeDefaultData();

            startProgram();
        }
    }

}