namespace Store_Dutta_Matta
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
        // todo: ask how much should be the array size here as it is not mentioned
        const int maxPurchases = 100;
        static int purchasesCount = 0;

        // Variable to store employee -@Gurleen
        static Employee employee;
        // Array to hold clients -@Pratiksha and -@Gurleen
        static Client[] client = new Client[maxClients];
        // Array to hold products -@Pratiksha and -@Gurleen
        static Product[] product = new Product[maxProducts];
        // Array to hold sales -@Pratiksha and -@Gurleen
        static Purchase[] purchase = new Purchase[maxPurchases];

        // Constants for default data -@Pratiksha
        const int defaultEmployeeId = 111111;
        const string defaultEmployeePassword = "tester";
        const string defaultClientPassword = "clientPass";


        #endregion 

        #region Input Validations -@Pratiksha 
        //Function to read an Integer , if not retry with error message
        static int ReadInteger()
        {
            int toReturn = 0;
            while (!Int32.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid integer value, please try again: ");
            }

            return toReturn;
        }

        //Function to ReadInteger within a range
        static int ReadInteger(int min, int max)
        {
            int toReturn = ReadInteger();
            while (!IsWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = ReadInteger();
            }

            return toReturn;
        }

        //Function to check if in range
        static bool IsWithinRange(int num, int min, int max)
        {
            return num >= min && num <= max;
        }

        //Function to read a double
        static double ReadDouble()
        {
            double toReturn = 0;
            while (!Double.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid real value, please try again: ");
            }

            return toReturn;
        }

        //Function to read a double in a range
        static double ReadDouble(double min, double max)
        {
            double toReturn = ReadDouble();
            while (!IsWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = ReadDouble();
            }

            return toReturn;
        }

        //Function to check if double is within the range
        static bool IsWithinRange(double num, double min, double max)
        {
            return num >= min && num <= max;
        }

        //Function to read a string or retry is empty or null -@Gurleen
        static string ReadString()
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
        static void InitializeDefaultData()
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

            // Initialize default purchases
            Product[] defaultPurchase = { product[0], product[1], product[2] };
            purchase[0] = new Purchase(client[0], defaultPurchase, 909.25, 136.39, 1045.64);

            //Initialize default purchase count
            purchasesCount = 1;

        }
        #endregion

        #region Menu Displays -@Pratiksha and -@Gurleen
        //function to display the main menu lines -@Pratiksha
        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Exit Application");
            Console.WriteLine("Please enter the appropriate option");
        }
        //function to display the role menu lines -@Pratiksha
        static void DisplayRoleMenu()
        {
            Console.WriteLine("1.Employee");
            Console.WriteLine("2.Client");
            Console.WriteLine("Please enter the appropriate option");
        }
        //function to display the client menu lines -@Pratiksha
        static void DisplayClientMenu()
        {
            Console.WriteLine("1.Display all products");
            Console.WriteLine("2.Display purchases");
            Console.WriteLine("3.Sign Out");
            Console.WriteLine("Please enter the appropriate option (1-3)");
        }

        //function to display the employee menu lines -@Gurleen
        static void DisplayEmployeeMenu()
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
        static string GetPassword()
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
        static Client VerifyClient()
        {
            Console.WriteLine("Enter Client ID:");
            //read an interger between 100000 and 999999 -@Pratiksha
            int clientId = ReadInteger(100000, 999999);

            //read a string which is not empty or null -@Pratiksha
            Console.WriteLine("Enter Password:");
            string password = GetPassword();

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
        static Employee VerifyEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            //read an interger between 100000 and 999999 -@Gurleen
            int employeeId = ReadInteger(100000, 999999);

            //read a string which is not empty or null -@Gurleen
            Console.WriteLine("Enter Password:");
            string password = GetPassword();

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
        static void DisplayAllProducts()
        {
            Console.WriteLine("List of Products:");

            //check for productsCount products only -@Gurleen
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].UniqueId != 0)
                {
                    Console.WriteLine($"ID: {product[i].UniqueId}, Name: {product[i].Name}, Price: {product[i].UnitPrice}, Quantity Available: {product[i].QuantityAvailable}");
                }
            }
        }

        //function to display purchases -@Pratiksha
        static void DisplayPurchases(Client client)
        {
            Console.WriteLine($"Purchases for Client: {client.FirstName} {client.LastName}");

            for (int i = 0; i < purchasesCount; i++)
            {
                Purchase p = purchase[i];

                // Check if the purchase belongs to the specified client
                if (p.Client.UniqueId == client.UniqueId)
                {

                    Console.WriteLine($"Client: {p.Client.FirstName} {p.Client.LastName}");
                    Console.WriteLine($"Products Purchased:");

                    foreach (Product product in p.Products)
                    {
                        Console.WriteLine($"  - {product.Name}: ${product.UnitPrice} x Qty:{product.QuantityAvailable}");
                    }

                    Console.WriteLine($"Subtotal: ${p.Subtotal}, Taxes: ${p.Taxes}, Total Price: ${p.TotalPrice}");
                    Console.WriteLine();
                }
            }
        }

        //function to display Client Menu and perform client functions -@Pratiksha
        static void HandleClientFunctionality(Client client)
        {
            bool Exit = false;

            while (!Exit)
            {

                //function to client menu -@Pratiksha
                DisplayClientMenu();

                //read the choice between 1 and 3 from the menu -@Pratiksha
                int getChoice = ReadInteger(1, 3);

                //switch statement for handling client functions -@Pratikha
                switch (getChoice)
                {
                    case 1:
                        DisplayAllProducts();
                        break;
                    case 2:
                        DisplayPurchases(client);
                        break;
                    case 3:
                        Exit = true;
                        Console.WriteLine("Signing out....");
                        break;
                }
            }
            if (Exit)
            {
                // return to main menu after signing out -@Pratikha
                StartProgram();
            }
        }
        #endregion 

        #region Employee Functionality -@Gurleen and -@Pratiksha
        //function to create products -@Gurleen
        static void CreateProducts()
        {
            string CreateProducts = "YES";
            while (CreateProducts == "YES")
            {
                if (productsCount == maxProducts)
                {
                    Console.WriteLine("Unable to create more products, maximum products reached!");
                    break;
                }

                Console.WriteLine("Enter Product ID:");
                int productId = ReadInteger(100000, 999999);
                //for loop to go through the products to check if id already exists -@Gurleen
                bool existingProductId = false;
                for (int i = 0; i < client.Length; i++)
                {
                    if (product[i].UniqueId == productId)
                    {
                        Console.WriteLine("Product ID already exists!");
                        existingProductId = true;
                    }
                }
                if (existingProductId == true)
                {
                    continue;
                }

                Console.WriteLine("Enter Product Name:");
                string productName = ReadString();
                Console.WriteLine("Enter Unit Price:");
                double unitPrice = ReadDouble();
                Console.WriteLine("Enter Quantity Available:");
                int quantityAvailable = ReadInteger();
                product[productsCount] = new Product(productId, productName, unitPrice, quantityAvailable);
                productsCount += 1;

                Console.WriteLine("Do you want to create more products (Type Yes):");
                CreateProducts = ReadString().ToUpper();
            }

        }

        //function to modify one product -@Gurleen
        static void ModifyOneProduct()
        {
            Console.WriteLine("Enter Product ID:");
            int productId = ReadInteger(100000, 999999);
            //for loop to go through the products and match -@Gurleen
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].UniqueId == productId)
                {
                    Console.WriteLine("Enter Product Name:");
                    product[i].Name = ReadString();
                    Console.WriteLine("Enter Unit Price:");
                    product[i].UnitPrice = ReadDouble();
                    Console.WriteLine("Enter Quantity Available:");
                    product[i].QuantityAvailable = ReadInteger();
                    return;
                }
            }
            Console.WriteLine("Product not found!");
        }

        //function to display all products sorted by ID -@Pratiksha
        static void DisplayAllProductsSortedByID()
        {
            // Sort the array based on ProductID 
            Array.Sort(product, (x, y) => x.UniqueId.CompareTo(y.UniqueId));

            // Display the sorted array using a for loop
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].UniqueId != 0)
                {
                    Product Product = product[i];
                    Console.WriteLine($"ID: {Product.UniqueId}, Name: {Product.Name}, Price: {Product.UnitPrice}, Quantity Available: {Product.QuantityAvailable}");
                }
            }

        }

        //function to create a client -@Gurleen
        static void CreateAClient()
        {
            if (clientsCount == maxClients)
            {
                Console.WriteLine("Unable to create more clients, maximum clients reached!");
                return; // Exiting the function
            }

            Console.WriteLine("Enter Client ID:");
            int clientId = ReadInteger(100000, 999999);
            //for loop to go through the clients to check if id already exists -@Gurleen
            for (int i = 0; i < client.Length; i++)
            {
                if (client[i].UniqueId == clientId)
                {
                    Console.WriteLine("Client ID already exists!");
                    return;
                }
            }

            Console.WriteLine("Enter First Name:");
            string firstName = ReadString();
            Console.WriteLine("Enter Last Name:");
            string lastName = ReadString();
            Console.WriteLine("Enter Password:");
            string password = GetPassword();
            client[clientsCount] = new Client(clientId, firstName, lastName, password);
            clientsCount += 1;

        }

        //function to modify a client -@Gurleen
        static void ModifyAClient()
        {
            Console.WriteLine("Enter Client ID:");
            int clientId = ReadInteger(100000, 999999);
            //for loop to go through the clients and match -@Gurleen
            for (int i = 0; i < client.Length; i++)
            {
                if (client[i].UniqueId == clientId)
                {
                    Console.WriteLine("Enter First Name:");
                    client[i].FirstName = ReadString();
                    Console.WriteLine("Enter Last Name:");
                    client[i].LastName = ReadString();
                    Console.WriteLine("Enter Password:");
                    client[i].Password = GetPassword();
                    break;
                }
            }
            Console.WriteLine("Client not found!");
        }

        //function to display all clients sorted by ID -@Pratiksha
        static void DisplayAllClientsSortedByID()
        {
            // Sort the array based on UniqueId using Comparison delegate
            Array.Sort(client, (x, y) => x.UniqueId.CompareTo(y.UniqueId));

            // Display the sorted array using a for loop
            for (int i = 0; i < client.Length; i++)
            {
                if (client[i].UniqueId != 0)
                {
                    Console.WriteLine($"ID: {client[i].UniqueId}, Name: {client[i].FirstName} {client[i].LastName}");
                }
            }
        }

        //function to Sell -@Gurleen and -@Pratiksha
        static void Sell()
        {
            if (purchasesCount == maxPurchases)
            {
                Console.WriteLine("Unable to create another purchase, maximum purchases reached!");
                return;
            }

            Console.WriteLine("Enter Client ID:");
            int clientId = ReadInteger(100000, 999999);
            Client c = new Client { UniqueId = 0 };// creating a new blank client element
            //for loop to go through clients to search the correct client -@Gurleen
            for (int j = 0; j < client.Length; j++)
            {
                if (client[j].UniqueId == clientId)
                {
                    c = client[j]; //storing the matched client in the new Client element
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
            int numOfProductsSold = ReadInteger(1, maxProducts);
            Product[] productsSold = new Product[numOfProductsSold];
            int sold_count = 0;
            for (int i = 0; i < numOfProductsSold; i++)
            {

                Product productToSell = new Product { UniqueId = 0 };
                while (productToSell.UniqueId == 0)
                {

                    Console.WriteLine("Enter Product ID:");
                    int productId = ReadInteger(100000, 999999);
                    //for loop to go through the products and match -@Gurleen
                    for (int j = 0; j < product.Length; j++)
                    {

                        if (product[j].UniqueId == productId)
                        {
                            productToSell = product[j];
                            int quantityAvailable = productToSell.QuantityAvailable;
                            if (quantityAvailable <= 0)
                            {
                                Console.WriteLine("Quantity not Available");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter Quantity Sold:");
                                int quantitySold = ReadInteger(1, quantityAvailable);
                                // calling the parameterised constructor to fill the values
                                productToSell = new Product(productId, productToSell.Name, productToSell.UnitPrice, quantitySold);
                                productsSold[sold_count] = productToSell;
                                sold_count += 1;
                                subtotal += (productToSell.UnitPrice * quantitySold);
                                product[j].QuantityAvailable -= quantitySold;// decrease quantity form product array

                                break;
                            }
                        }
                    }
                    if (productToSell.Name == null)
                        Console.WriteLine("Product not found or quantity not available, please try again.");
                }
            }

            // todo: need to ask about how much taxes we need to have
            double taxes = 0.15;
            double totalPrice = subtotal + subtotal * taxes;
            purchase[purchasesCount] = new Purchase(c, productsSold, subtotal, taxes, totalPrice);// store at the next available purchase slot
            purchasesCount += 1;
        }

        //function to display all sales -@Pratiksha
        static void DisplayAllSales()
        {
            for (int i = 0; i < purchasesCount; i++)
            {
                //client element and array of product elements is accessed (to be printed)
                Console.WriteLine($"Client: {purchase[i].Client.FirstName} {purchase[i].Client.LastName}");
                Console.WriteLine($"Products Purchased:");
                for (int j = 0; j < purchase[i].Products.Length; j++)
                {

                    Console.WriteLine($"  - {purchase[i].Products[j].Name}: ${purchase[i].Products[j].UnitPrice} x Qty: {purchase[i].Products[j].QuantityAvailable}");
                }

                Console.WriteLine($"Subtotal: ${purchase[i].Subtotal}, Taxes: ${purchase[i].Taxes}, Total Price: ${purchase[i].TotalPrice}");
                Console.WriteLine();
            }
        }

        //function to display total sales -@Gurleen
        static void DisplayTotalSales()
        {
            double totalSales = 0;
            // Calculate total sales by summing up the TotalPrice of each purchase
            for (int i = 0; i < purchasesCount; i++)
            {
                totalSales += purchase[i].TotalPrice;
            }
            Console.WriteLine($"Total Sales: ${totalSales}");
        }


        //function to display Employee Menu and perform employee functions -@Gurleen
        static void HandleEmployeeFunctionality(Employee employee)
        {
            bool Exit = false;
            while (!Exit)
            {
                //function to client menu -@Gurleen
                DisplayEmployeeMenu();

                //read the choice between 1 and 10 from the menu -@Gurleen
                int getChoice = ReadInteger(1, 10);

                //switch statement for handling client functions -@Gurleen
                switch (getChoice)
                {
                    case 1:
                        CreateProducts();
                        break;
                    case 2:
                        ModifyOneProduct();
                        break;
                    case 3:
                        DisplayAllProductsSortedByID();
                        break;
                    case 4:
                        CreateAClient();
                        break;
                    case 5:
                        ModifyAClient();
                        break;
                    case 6:
                        DisplayAllClientsSortedByID();
                        break;
                    case 7:
                        Sell();
                        break;
                    case 8:
                        DisplayAllSales();
                        break;
                    case 9:
                        DisplayTotalSales();
                        break;
                    case 10:
                        Exit = true;
                        Console.WriteLine("Signing out....");
                        break;
                }
            }
            StartProgram();
        }
        #endregion 

        #region Exit Application Functionality -@Pratiksha and -@Gurleen
        //Function to safely Exit the application with confirmation -@Pratiksha and -@Gurleen
        static void Exit()
        {
            Console.WriteLine("Are you sure you want to Exit? (Type Yes)");
            string input = ReadString().ToUpper();
            if ("YES".Equals(input))
            {
                Console.WriteLine("Exiting the application...");
                Environment.Exit(0);
            }
            else
            {
                StartProgram();
            }
        }
        #endregion

        #region App Functionality (StartProgram) -@Pratiksha 

        //Core function to run the logic of the App -@Pratiksha (client) -@Gurleen (employee)
        static void StartProgram()
        {
            //display the main menu and take the inputs  -@Pratiksha
            DisplayMainMenu();
            int choiceMainMenu = ReadInteger(1, 2);
            if (choiceMainMenu == 1)
            {
                //display the role menu and take the inputs  -@Pratiksha
                DisplayRoleMenu();
                int roleChoice = ReadInteger(1, 2);
                if (roleChoice == 1)
                {
                    // display employee and functions -@Gurleen
                    Employee employee = VerifyEmployee();
                    if (employee.UniqueId != 0)
                    {
                        //handle the employee functionalities with menu -@Gurleen
                        HandleEmployeeFunctionality(employee);
                    }
                    else
                    {
                        Console.WriteLine("Failed to authenticate user");
                        StartProgram();
                    }
                }
                else if (roleChoice == 2)
                {
                    //verify the client by password -@Pratiksha
                    Client client = VerifyClient();
                    if (client.UniqueId != 0)
                    {
                        //handle the client functioanlities with menu -@Pratiksha
                        HandleClientFunctionality(client);
                    }
                    else
                    {
                        Console.WriteLine("Failed to authenticate user");
                        StartProgram();
                    }

                }

            }
            else
            {
                Exit();
            }

        }
        #endregion

        static void Main(string[] args)
        {
            InitializeDefaultData();

            StartProgram();
        }
    }

}