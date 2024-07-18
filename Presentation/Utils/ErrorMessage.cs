namespace Presentation.Utils.Error
{
    public static class ErrorMessage
    {
        public static void InvalidInput()
        {
            Console.Write("--- Invalid Input, try again --- \n> ");
        }

        public static void DataNotAvailable()
        {
            Console.WriteLine("--- Records Not Found --- \n");
            // Interactions.wait();
        }

        public static void MandatoryInput()
        {
            Console.Write("--- It's a Mandatory Field --- \n> ");
        }

        public static void RecordNotAvailable(string id)
        {
            Console.WriteLine($"--- Record Not Found with ID {id} --- \n");
        }

        public static void InvalidOption()
        {
           Console.Write("--- Invalid Option, try again --- \n> ");
        }

        public static void InvalidInput(string field)
        {
           Console.Write($"--- Invalid {field}, try again --- \n> ");
        }

        public static void OperationFailed()
        {
            Console.WriteLine("--- Operation Failed, try again ---\n");   
        }
    }


}
