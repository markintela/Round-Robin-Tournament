
using ConsoleApp1;
using RoundRobin;


var roundRobinList = new RoundRobinList<int>(
    new List<int>{
        9,8,7,6,5,4,3,2,1
    }
);

var reverse = new RoundRobinList<int>(
    new List<int>{
        2,3,4,5,6,7,8,9,1
    }
);


int numerosTimes = 9;
int away = 0;
int home = 0;
int halfSize = (numerosTimes)/2;
int jogosRodada= (numerosTimes)/2 + 1;
int totalJogos = ((numerosTimes)*(jogosRodada)) ;

NumeroImpar();
Console.WriteLine();
Console.WriteLine("---------------------------");
Console.WriteLine();

int[] arrayTeams = new int[] { 6,5,4,3,2,1 };

NumeroPar(arrayTeams);

void NumeroImpar()
{
    for (var i = 0; i < totalJogos; i++)
    {

        if (i == halfSize)
        {
            reverse.IncreaseWeight(element: away, amount: 1);

        }
        var auxi = away;
        if (i == halfSize+1)
        {
            reverse.DecreaseWeight(element: auxi, amount: 1);
            Console.WriteLine();
            halfSize = halfSize+jogosRodada;


        }
        away = reverse.Next();
        home = roundRobinList.Next();
        if (home != away)
        {        
            Console.Write("["+ home+" vs "+away+"]");
        }
    }
}
void NumeroPar(int[] ListTeam)
{

    int numTeams = ListTeam.Length;
    int numDays = (numTeams - 1);
    int halfSize = numTeams / 2;

    List<int> teams = new List<int>();

    teams.AddRange(ListTeam); // Copy all the elements.
    teams.RemoveAt(0); // To exclude the first team.

    int teamsSize = teams.Count;

    for (int round = 0; round < numDays; round++)
    {
        
        int teamIdx = round % teamsSize;
        if (round > 0 && round % 2 != 0) {
            Console.Write("[{0} vs {1}]", ListTeam[0], teams[teamIdx]);
        }
        else
        {
            Console.Write("[{0} vs {1}]", teams[teamIdx], ListTeam[0]);
        }
       

        for (int idx = 1; idx < halfSize; idx++)
        {
            int firstTeam = (round + idx) % teamsSize;
            int secondTeam = (round  + teamsSize - idx) % teamsSize;
            Console.Write("[{0} vs {1}]", teams[firstTeam], teams[secondTeam]);
        }
        Console.WriteLine();
    }
}

