

public class PlayingGamesFacade
{

    static void Main(string[] args)
    {

        PC realPC = new PC();
        Console.WriteLine("What game to launch?\r\nWrite either STALKER or HM.");
        string input1 = Console.ReadLine();
        if(input1 == "STALKER")
        {
            realPC.LaunchStalker();
        }
        if(input1 == "HM")
        {
            realPC.LaunchHM();
        }
        else{
            Console.WriteLine("Invaild request. Ending Facade program.");
        }
    }    
}

public class Screen
{
    public void ConnectScreen()
    {
        Console.WriteLine("Screen connected!");
    }
    public void DisconnectScreen()
    {
        Console.WriteLine("Screen disconnected!");
    }
}

public class PC
{
    public void LaunchStalker()
    {
        Screen realScreen = new Screen();
        Game realGame = new Game();
        Headphones realHeadphones = new Headphones();

        realScreen.ConnectScreen();
        TurnOnPC();
        CoolDownGPU();
        realGame.LaunchSTALKER(this, realHeadphones);

    }
    public void LaunchHM()
    {
        Screen realScreen = new Screen();
        Game realGame = new Game();
        Headphones realHeadphones = new Headphones();

        realScreen.ConnectScreen();
        TurnOnPC();
        realGame.LaunchSTALKER(this, realHeadphones);
    }


    public bool cooledGPU = false;
    public void TurnOnPC()
    {
        Console.WriteLine("PC is on");
    }
    public void TurnOffPC()
    {
        Console.WriteLine("PC is off");
    }
    public void CoolDownGPU()
    {
        cooledGPU = true;
        Console.WriteLine("Cooling town the GPU unit. It really is important.");
    }
}

public class Game
{  
    public void LaunchSTALKER(PC computer, Headphones headphones)
    { 
        if (computer.cooledGPU)
        {
            headphones.volume = 70; 
            Console.WriteLine("Loading the game STALKER...");
        }
        else
        {
            Console.WriteLine("Cannot launch STALKER, the PC is too hot");
        }
    }

    public void LaunchHM(Headphones headphones)
    {
        headphones.volume = 100;
        Console.WriteLine("Loading Hotline Miami");
    }
}

public class Headphones
{
    public int volume = 50;
}