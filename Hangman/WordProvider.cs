namespace Hangman;

public class WordProvider
{
    private string WordDirectory { get; }
    private readonly List<string> _topics  = [];
    public WordProvider(string wordDirectory)
    {
        WordDirectory  = wordDirectory;
        
        if (Directory.Exists(WordDirectory))
        {
            string[] existTopics = Directory.GetFiles(WordDirectory, "*.txt");

            foreach (var topic in existTopics)
                _topics.Add(topic);
            _topics.Sort();
        }
        else
        {
            Console.WriteLine("The specified directory doesn't exist!");
        }
    }

    public string[] GetWords()
    {
        string selectedFile =  SelectTopic();
        string[] words = File.ReadAllLines(selectedFile);
        
        return words;
    }

    public void AddNewWord()
    {
        do
        {
            if (File.Exists(WordDirectory) && _topics.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have {_topics.Count} topics");
                Console.WriteLine("");
            }
            
            Render.WordMenu();
            int.TryParse(Console.ReadLine(), out int userSelect);

            switch (userSelect)
            {
                case 1:
                    CreateNewTopic(_topics);
                    return;
                case 2:
                    AddWordsToTopic();
                    return;
                case 9:
                    return;
                default:
                    Console.WriteLine("Invalid value!");
                    break;
            }
            
        } while (true);
    }

    private void CreateNewTopic(List<string> topics)
    {
        Console.Write("Type in the title of the topic: ");
        string topicName = Console.ReadLine()!.Trim();
        string path = $"{WordDirectory}{topicName}.txt";
        if (!File.Exists(path))
        {
            using (File.Create(path))
                topics.Add(path);
        }
        else
        {
            Console.WriteLine("The topic already exists!");
        }

        Console.WriteLine($"Would you like to add words to {topicName}?");
        Console.WriteLine("1 - Yes");
        Console.WriteLine("2 - No");
        Console.Write("Your pick: ");
        int.TryParse(Console.ReadLine(), out int uselSelect);
        
        switch (uselSelect)
        {
            case 1:
                AddWordsToTopic(path);
                break;
            case 2:
                break;
            default:
                Console.WriteLine("Invalid value!");
                break;
        }
        
    }

    private void AddWordsToTopic()
    {        
        string topicPath = SelectTopic();
        AddWordsToTopic(topicPath);
    }

    private void AddWordsToTopic(string topicPath)
    {
        do
        {
            Console.Write("Type The Word | 9 - Save And Exit: ");
            string userInput = Console.ReadLine()!;
            
            if (userInput != "9")
            {
                StreamWriter writer = File.AppendText(topicPath);
                writer.WriteLine(userInput);
                writer.Close();
            }
            else
            {
                return;
            }
        } while (true);
    }

    private string SelectTopic()
    {
        do
        {
            Render.TopicMenu(_topics);
            
            bool success = int.TryParse(Console.ReadLine(), out var userSelect);
            
            if (success && userSelect >= 1 && userSelect <= _topics.Count)
            {
                string selectedFile = _topics[userSelect - 1];
                
                return selectedFile;
            }
            else
            {
                Console.WriteLine("Invalid Value!");
            }
            
        } while (true);
    }
    
}