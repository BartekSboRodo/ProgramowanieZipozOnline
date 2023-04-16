

string[] row1 = { " ", " ", " " };
string[] row2 = { " ", " ", " " };
string[] row3 = { " ", " ", " " };
string[][] field = {row1, row2, row3};

bool Xwin = false;
bool Owin = false;

while (Xwin == false && Owin == false)
{
    var fieldChosen = ChooseFieldPlayer();

    while (field[fieldChosen.Item1][fieldChosen.Item2] != " ")
    {
        Console.WriteLine("Wybrałeś pan zajęte pole. Spróbuj pan jeszcze raz.");

        ChooseFieldPlayer();
    }
    field[fieldChosen.Item1][fieldChosen.Item2] = "X";

    var fieldChosen2 = ChooseFieldRandom();

    while (field[fieldChosen2.Item1][fieldChosen2.Item2] != " ")
    {
        ChooseFieldRandom();
    }

    field[fieldChosen2.Item1][fieldChosen2.Item2] = "O";

    Console.WriteLine(field[0][0] + field[0][1] + field[0][2]);
    Console.WriteLine(field[1][0] + field[1][1] + field[1][2]);
    Console.WriteLine(field[2][0] + field[2][1] + field[2][2]);

//fantastycznie
    Xwin = CheckForXWin(field);
    Owin = CheckForXWin(field);

    if (Xwin == true)
    {
        Console.WriteLine("X wygranko");
    }
    if (Owin == true)
    {
        Console.WriteLine("O wygranko");
    }
}


static Tuple<int, int> ChooseFieldPlayer()
{
    Console.WriteLine("Wybierz rząd:");
    string chosenRowString = Console.ReadLine();
    while (chosenRowString != "1" && chosenRowString != "2" && chosenRowString != "3")
    {
        Console.WriteLine("Gowno prawda, wybierz rząd 1-3");
        chosenRowString = Console.ReadLine();
    }
    int chosenRow = Int32.Parse(chosenRowString);

    Console.WriteLine("Teraz wybierz kolumnę:");

    string chosenColumnString = Console.ReadLine();
    while (chosenColumnString != "1" && chosenColumnString != "2" && chosenColumnString != "3")
    {
        Console.WriteLine("Gowno prawda, wybierz kolumnę 1-3");
        chosenColumnString = Console.ReadLine();
    }
    int chosenColumn = Int32.Parse(chosenColumnString);
    return Tuple.Create(chosenRow-1, chosenColumn-1);
}

static Tuple<int, int> ChooseFieldRandom()
{
    Random rnd = new Random();
    int chosenRow = rnd.Next(0,3);
    int chosenColumn = rnd.Next(0, 3);

    return Tuple.Create(chosenRow, chosenColumn);
}

static bool CheckForXWin(string[][] field)
{
    bool win = false;
    string check = ("X");

    if (field[0][0] == check && field[0][1] == check && field[0][2] == check)
    {
        win = true;
    }
    if (field[1][0] == check && field[1][1] == check && field[1][2] == check)
    {
        win = true;
    }
    if (field[2][0] == check && field[2][1] == check && field[2][2] == check)
    {
        win = true;
    }



    if (field[0][0] == check && field[1][0] == check && field[2][0] == check)
    {
        win = true;
    }
    if (field[0][1] == check && field[1][1] == check && field[2][1] == check)
    {
        win = true;
    }
    if (field[0][2] == check && field[1][2] == check && field[2][2] == check)
    {
        win = true;
    }


    if (field[0][0] == check && field[1][1] == check && field[2][2] == check)
    {
        win = true;
    }
    if (field[0][2] == check && field[1][1] == check && field[2][0] == check)
    {
        win = true;
    }

    return win;
}


static bool CheckForOWin(string[][] field)
{
    bool win = false;
    string check = ("O");

    if (field[0][0] == check && field[0][1] == check && field[0][2] == check)
    {
        win = true;
    }
    if (field[1][0] == check && field[1][1] == check && field[1][2] == check)
    {
        win = true;
    }
    if (field[2][0] == check && field[2][1] == check && field[2][2] == check)
    {
        win = true;
    }



    if (field[0][0] == check && field[1][0] == check && field[2][0] == check)
    {
        win = true;
    }
    if (field[0][1] == check && field[1][1] == check && field[2][1] == check)
    {
        win = true;
    }
    if (field[0][2] == check && field[1][2] == check && field[2][2] == check)
    {
        win = true;
    }


    if (field[0][0] == check && field[1][1] == check && field[2][2] == check)
    {
        win = true;
    }
    if (field[0][2] == check && field[1][1] == check && field[2][0] == check)
    {
        win = true;
    }

    return win;
}

// coś w tym kodzie nie działa. Ale trudno, to na eksperyment

