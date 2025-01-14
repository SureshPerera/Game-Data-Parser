using System.Text.Json;

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
