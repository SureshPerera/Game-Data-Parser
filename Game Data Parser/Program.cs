var loger = new Loger("Input.txt");

try
{
new Main().Run();

}
catch(Exception ex)
{
    Console.WriteLine($"Sorry! The application has experienced an unexpected error and will have to be closed." +
                $"\nException Massage :{ex.Message}");
    loger.log(ex);
}


Console.ReadKey();


