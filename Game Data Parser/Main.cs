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

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() =>
        $"{Title}, Released in {ReleaseYear}, Rating {Rating} ";

}
