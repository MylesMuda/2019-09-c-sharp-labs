using System;
using System.IO;

namespace lab_28_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            // ERROR: programmer error in logic e.g. bank calculates interest incorrectly
            // EXCEPTION: code crashes and program cannot continue
            //      Handled:    expression takes place inside a TRY BLOCK
            //                  code is handled in the CATCH BLOCK
            //                  whether exception or not, run the FINALLY BLOCK
            //      Unhandled:  Messy exception, program terminates uncleanly
            //      Compiler:   Red lines in code: won't build
            //      Runtime:    e.g. divide by zero in program

            int x = 10;
            int y = 0;
            // Console.WriteLine(x/y); UNHANDLED 
            try
            {
                Console.WriteLine(x/y); // Throws an exception
                //any code which might produce an exception 
            }
            catch (Exception e)
            {
                Console.WriteLine("C'mon bruh");
                Console.WriteLine(e);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("L");
            }

            //custom exceptions
            var myException = new Exception("Hey buddy");
            try
            {
                //imagine engine is getting hot but hasn't burnt out yet
                throw (myException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Large Application
            // Nesting : Main, Sub, Sub.

            try
            {
                try
                {
                    try
                    {
                        throw (new Exception("Inner Exception - My Code"));
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This is awful");
                Console.WriteLine(e.Message);
                File.WriteAllText("log.txt", $"Myles' code not working as usual - {e.Message}");
            }

            // Types of exceptions

            try { Console.WriteLine(x/y); }
            catch (DivideByZeroException) { Console.WriteLine("Stop that"); }
            catch(Exception e) { Console.WriteLine("All exceptions caught"); }
        }
    }
}
