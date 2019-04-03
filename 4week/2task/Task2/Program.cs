using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UniqueListUI.Interaction();
            }
            catch (DeleteNonExistentNodeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (AddExistingNodeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
