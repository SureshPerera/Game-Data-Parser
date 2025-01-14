using System.Text.Json;
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

public class Main()
{
    Loger loger = new Loger("Input.txt");
    Repository repository = new Repository();
    string Input { get; set; }
    public void Run()
    {
        
        try
        {
            GetInput();
            repository.JsonRead(Input);
            //repository.WriteLogFile("Input.txt");
        }
        catch(NullReferenceException ex)
        {
            loger.log(ex);

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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"No file with such a name : {input}" +
                            $" \nFile not found");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File name cannot be empty.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File name cannot be null.");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

    }
}

public class Loger
{
    private readonly string _logFileName; 
    public Loger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void log(Exception ex)
    {
        var entry = $@"[{DateTime.Now}]
Exception Message : {ex.Message}
Stack trace : {ex.StackTrace}

";
        File.AppendAllText(_logFileName, entry);
    }
}

public class Repository
{
 
    public List<string> LogMessage = new List<string>();
   public void JsonRead(string fileName)
    {
        try
        { 
            var Contain = File.ReadAllText(fileName);
            string dataFromJson = JsonSerializer.Serialize(Contain);
            var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(Contain);
            if( Contain.Length > 0 )
            {
                Console.WriteLine("See Reading the data from the JSON file.\r\n");
                int count = 0;
                foreach (var item in videoGames)
                {
                   
                    Console.WriteLine(" \t" + $"{count+1}.{item}");
                    count++;
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("No games are present in the input file.");
                Console.ForegroundColor = ConsoleColor.White;

            }



        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var Contain = File.ReadAllText(fileName);
            Console.WriteLine(Contain);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            throw;
        }
        
            
        
    }

 
    
}


public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear {  get; init; }
    public decimal Rating { get; init; }

    public override string ToString() =>
        $"{Title}, Released in {ReleaseYear}, Rating {Rating} ";

}