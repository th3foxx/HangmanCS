namespace Hangman;

public class Game
{
    private const string Directory = @"C:\Users\lamer\RiderProjects\Hangman\Hangman\render\";
    private const string FileLogo = "logo.txt";
    private const string FileHeader = "header.txt";

    public void Run()
    {
        int userSelect;
        Render render = new Render(Directory, FileLogo, FileHeader);
        render.LogoRender();

        do
        {
            render.Menu();
            int.TryParse(Console.ReadLine(), out userSelect);

            switch (userSelect)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    ViewLeaderBoard();
                    break;
                case 3:
                    AddNewWord();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Invalid value!");
                    break;

            }
            
        } while (userSelect != 9);


    }

    private void StartGame()
    {
        Player player = new Player();
        player.PlayerInput();
    }
    
    private void ViewLeaderBoard()
    {
        Console.WriteLine("WIP");
    }
    
    private void AddNewWord()
    {
        Console.WriteLine("WIP");
    }
}