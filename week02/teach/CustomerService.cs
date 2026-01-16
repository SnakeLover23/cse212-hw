/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 0 will be inputed for the queue size
        // Expected Result: the queue will default to 10
        Console.WriteLine("Test 1");

        var service = new CustomerService(0);
        if (service._maxSize != 10)
        {
            Console.WriteLine("Test Fail: _maxSize did not default to 10");
        }
        else
        {
             Console.WriteLine("Test Pass");
        }
        
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: AddNewCustomer method will be used
        // Expected Result: A new customer will be added
        Console.WriteLine("Test 2");

        service = new CustomerService(1);
        service.AddNewCustomer();

        if (service._queue.Count != 1)
        {
            Console.WriteLine("Test Fail: Incorect number of customers in _queue");
        }
        else
        {
            Console.WriteLine("Test Pass");
        }

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Customers will be added to the queue beyond capacity
        // Expected Result: An error message will be displayed
        Console.WriteLine("Test 3");

        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();

        if (service._queue.Count > service._maxSize)
        {
            Console.WriteLine("Test Fail: Incorect number of customers in _queue");
        }
        else
        {
            Console.WriteLine("Test Pass");
        }

        // Defect(s) Found: 1

        Console.WriteLine("=================");

        // Test 4
        // Scenario: The ServeCustomer function will be used on a queue of costomers
        // Expected Result: The customer at the front of the queue will be removed and have their data displayed
        Console.WriteLine("Test 4");

        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();

        service.ServeCustomer();

        if (service._queue.Count != 1)
        {
            Console.WriteLine("Test Fail: Incorect number of customers in _queue");
        }
        else
        {
            Console.WriteLine("Test Pass");
        }

        // Defect(s) Found: 1

        Console.WriteLine("=================");

        // Test 5
        // Scenario: The ServeCustomer function will be used on an empty queue
        // Expected Result: An error message will be displayed
        Console.WriteLine("Test 5");

        service = new CustomerService(2);

        service.ServeCustomer();


        // Defect(s) Found: 1

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("There are no customers to serve.");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}