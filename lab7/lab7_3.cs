using System.Collections.Generic;
using System;

public class Participant
{
    private int place;

    public Participant(int place)
    {
        this.place = place;
    }
    public int GetScore()
    {
        return Math.Max(0, 6 - this.place);
    }
}
public abstract class Team
{
    public abstract string GetTeamType();
    private List<Participant> p = new List<Participant>();
    private string name;

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public Team(string name)
    {
        this.name = name;
    }

    public void AddParticipant(int place)
    {
        Participant a = new Participant(place);
        this.p.Add(a);
    }
    public int Count
    {
        get
        {
            return this.p.Count;
        }
    }

    public int GetTeamScore()
    {
        int score = 0;
        for (int i = 0; i < this.p.Count; i++)
        {
            score += this.p[i].GetScore();
        }
        return score;
    }
}
public class WomanTeam : Team
{
    public override string GetTeamType()
    {
        return "Женская";
    }
    public WomanTeam(string name) : base(name)
    {
    }
}
public class ManTeam : Team
{
    public override string GetTeamType()
    {
        return "Мужская";
    }
    public ManTeam(string name) : base(name)
    {
    }
}
public class Tournament
{
    private List<Team> teams = new List<Team>();
    
    public void AddTeam(Team x) 
    {
        this.teams.Add(x);
    }
    public void SimulateTournament()
    {
        Random r = new Random();
        for (int i = 1; i <= this.teams.Count*6;)
        {
            int random = r.Next(0, this.teams.Count);
            if (this.teams[random].Count < 6)
            {
                this.teams[random].AddParticipant(i);
                ++i;
            }
        }
        Console.WriteLine(this.teams.Count);
        Console.WriteLine("hh");
    }
    public Team GetWinner()
    {
        int winnerIndex = 0, winnerScore = 0;

        for (int i = 0; i < this.teams.Count; ++i)
        {
            if (winnerScore < this.teams[i].GetTeamScore())
            {
                winnerScore = this.teams[i].GetTeamScore();
                winnerIndex = i;
            }
        }
        return this.teams[winnerIndex];
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("bah?");
        Tournament manTournament = new Tournament();
        Tournament womanTournament = new Tournament();
        
        manTournament.AddTeam(new ManTeam("Первая"));
        manTournament.AddTeam(new ManTeam("Вторая"));
        manTournament.AddTeam(new ManTeam("Третья"));
        
        womanTournament.AddTeam(new WomanTeam("Первая"));
        womanTournament.AddTeam(new WomanTeam("Вторая"));
        womanTournament.AddTeam(new WomanTeam("Третья"));

        manTournament.SimulateTournament();
        womanTournament.SimulateTournament();

        Console.WriteLine(String.Format("{0,20} {1,10}", "Команда победитель у мужчин", "Счёт"));
        Console.WriteLine(String.Format("{0,20} {1,10}\n", manTournament.GetWinner().Name, manTournament.GetWinner().GetTeamScore()));

        Console.WriteLine(String.Format("{0,20} {1,10}", "Команда победитель у женщин", "Счёт"));
        Console.WriteLine(String.Format("{0,20} {1,10}\n\n", womanTournament.GetWinner().Name, womanTournament.GetWinner().GetTeamScore()));
        
        
        Team absoluteWinner = manTournament.GetWinner();
        if (womanTournament.GetWinner().GetTeamScore() > absoluteWinner.GetTeamScore()) 
        {
            absoluteWinner = womanTournament.GetWinner();
        }
        Console.WriteLine(String.Format("{0,20} {1,25} {2,10}", "Абсолютный победитель", "Тип команды", "Счёт"));
        Console.WriteLine(String.Format("{0,20} {1,25} {2,10}", absoluteWinner.Name, absoluteWinner.GetTeamType(), absoluteWinner.GetTeamScore()));

    }
}
