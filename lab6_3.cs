using System.Collections.Generic;
using System;

public class Participant {
    private int place;
    
    public Participant(int place) {
        this.place = place;
    }
    public int GetScore() {
        return Math.Max(0,6-this.place);
    }
}
public class Team {
    private List<Participant> p = new List<Participant>();
    private string name;
    
    public string Name {
        get {
            return this.name;
        }
    }
    
    public Team(string name) {
        this.name = name;
    }
    
    public void AddParticipant(int place) {
        Participant a = new Participant(place);
        this.p.Add(a);
    }
    public int Count {
        get {
            return this.p.Count;
        }
    }
    
    public int GetTeamScore() {
        int score = 0;
        for (int i = 0; i < this.p.Count; i++) {
            score += this.p[i].GetScore();
        }
        return score;
    }
}
public class Tournament {
    private List<Team> teams;
    
    public void SimulateTournament() {
        this.teams = new List<Team>();
        this.teams.Add(new Team("Первая"));
        this.teams.Add(new Team("Вторая"));
        this.teams.Add(new Team("Третья"));
        Random r = new Random();
        
        
        for (int i = 1; i <= 18; ) {
            int random = r.Next(0, 3);
            if (this.teams[random].Count < 6) {
                this.teams[random].AddParticipant(i);
                ++i;
            }
        }
    }
    public Team GetWinner() {
        int winnerIndex = 0, winnerScore = 0;
        for (int i=0; i < this.teams.Count; ++i) {
            if (winnerScore < this.teams[i].GetTeamScore()) {
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
        Tournament t = new Tournament();
        t.SimulateTournament();
        Console.WriteLine(String.Format("{0,20} {1,10}", "Команда победитель", "Счёт"));
        Console.WriteLine(String.Format("{0,20} {1,10}", t.GetWinner().Name, t.GetWinner().GetTeamScore()));

    }
}
