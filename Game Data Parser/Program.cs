using System.Text.Json;

new Main().Run();

Console.ReadKey();

public class Main()
{
    Repository repository = new Repository();
    string Input { get; set; }
    public void Run()
    {
        try
        {
            GetInput();
            repository.JsonRead(Input);
        }
        catch(NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    public void GetInput()
    {
        string input;
        bool IsCorrect = true;
        while (IsCorrect)
        {
            Console.WriteLine("Enter the name of the file you want to read:");
            input = Console.ReadLine();
            if(input != null)
            {
                if (input.Length > 0)
                {

                    if (File.Exists(input))
                    {
                        Input = input;
                        IsCorrect = false;
                    }
                    else
                    {
                        Console.WriteLine($"No file with such a name : {input}" +
                            $"File not found");
                    }
                }
                else
                {
                    Console.WriteLine("File name cannot be empty.\n");
                }
            }
            else
            {
                Console.WriteLine("File name cannot be null.");
            }
            
        }

    }
}

public class Repository
{
   public void JsonRead(string fileName)
    {
        try
        { 
            var Contain = File.ReadAllText(fileName);
            string dataFromJson = JsonSerializer.Serialize(Contain);

            if( Contain.Length > 0 )
            {
                var newData = dataFromJson.Split(Environment.NewLine);

                Console.WriteLine(newData);
            }
            else
            {
                Console.WriteLine("No games are present in the input file.” is printed to the console");
            }
            

            List<string> data = new List<string>();
            data.Add(dataFromJson);
          
                Console.WriteLine("See Reading the data from the JSON file.\r\n");
                

           



        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("There is no file" + ex.Message);
            throw;
        }
        
            
        
    }
}