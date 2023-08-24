using System;

namespace CourseEndProject1
{

    class Player
    {
        public int PlayerId { get; }
        public string PlayerName { get; }
        public int PlayerAge { get; }

        public Player(int playerId, string playerName, int playerAge)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            PlayerAge = playerAge;
        }

    }
    interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string PlayerName);
        List<Player> GetAllPlayers();
    }
    class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();
        public OneDayTeam()
        {
            oneDayTeam.Capacity = 11;
        }
        public void Add(Player player)
        {
            if (oneDayTeam.Count < 11)
            {
                oneDayTeam.Add(player);
                Console.WriteLine("Player is added successfully.");
            }
            else
            {
                Console.WriteLine("Team is full.");
            }
        }
        public void Remove(int playerId)
        {
            Player p = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (p != null)
            {
                oneDayTeam.Remove(p);
                Console.WriteLine("Player is removed successfully.");
            }
            else
            {
                Console.WriteLine($"Player with Id {playerId} not found.");
            }
        }
        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.Find(p => p.PlayerId == playerId);
        }
        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.Find(p => p.PlayerName == playerName);
        }
        public List<Player> GetAllPlayers()
        {
            return oneDayTeam.ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam oneDayTeam = new OneDayTeam();

            while (true)
            {
                
                Console.Write("Enter 1: To Add Player  ");
                Console.Write("2: Remove Player by Id  ");
                Console.Write("3: Get Player By Id  ");
                Console.Write("4: Get Player by Name  ");
                Console.Write("5: Get All Players  ");
                
                Console.WriteLine();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Player Id: ");
                            int playerId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Player Name: ");
                            string playerName = Console.ReadLine();
                            Console.Write("Enter Player Age: ");
                            int playerAge = int.Parse(Console.ReadLine());
                            oneDayTeam.Add(new Player(playerId, playerName, playerAge));
                            break;

                        case 2:
                            Console.Write("Enter Player Id to remove: ");
                            int idToRemove = int.Parse(Console.ReadLine());
                            oneDayTeam.Remove(idToRemove);
                            break;

                        case 3:
                            Console.Write("Enter Player Id to get: ");
                            int idToGet = int.Parse(Console.ReadLine());
                            Player playerById = oneDayTeam.GetPlayerById(idToGet);
                            if (playerById != null)
                            {
                                Console.WriteLine($"{playerById.PlayerId}    {playerById.PlayerName}    {playerById.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine($"Player with Id {idToGet} not found.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Player Name to get: ");
                            string nameToGet = Console.ReadLine();
                            Player playerByName = oneDayTeam.GetPlayerByName(nameToGet);
                            if (playerByName != null)
                            {
                                Console.WriteLine($"{playerByName.PlayerId}    {playerByName.PlayerName}    {playerByName.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine($"Player with Name {nameToGet} not found.");
                            }
                            break;

                        case 5:
                            List<Player> allPlayers = oneDayTeam.GetAllPlayers();
                            foreach (Player player in allPlayers)
                            {
                                Console.WriteLine($"{player.PlayerId}    {player.PlayerName}    {player.PlayerAge}");
                            }
                            break;

                        //case 6:
                        //    return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option");
                            break;
                    }

                    Console.Write("Do you want to continue (yes/no)? ");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice.ToLower() != "yes")
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric choice.");
                }
            }
        }
    }

}