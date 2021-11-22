using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Maya, Stevens, Blum, Seinfeld
            List<string> friends = Console.ReadLine().Split(", ").ToList();
            int blacklistCntr = 0;
            int lostFriendsCntr = 0;

            string input = Console.ReadLine();

            while (input != "Report")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch(command)
                {
                    case "Blacklist":
                        string name = tokens[1];
                        if (friends.Contains(name))
                        {       
                            friends[friends.IndexOf(name)] = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                        }
                        else
                        {
                            Console.WriteLine($"{name} was not found.");
                        }
                        break;
                    case "Error":
                        int currIndex = int.Parse(tokens[1]);
                        bool isCurrIndexValid = currIndex >= 0 && currIndex <= friends.Count - 1;
                        if (isCurrIndexValid && (friends[currIndex] != "Blacklisted" && friends[currIndex] != "Lost"))
                        {
                            string tempName = friends[currIndex];
                            friends[currIndex] = "Lost";
                            Console.WriteLine($"{tempName} was lost due to an error.");
                        }
                        break;
                    case "Change":
                        currIndex = int.Parse(tokens[1]);
                        if (currIndex >= 0 && currIndex <= friends.Count - 1)
                        {
                            // add the print for blacklisted names if someone changes their name to lost or blacklisted?
                            string newName = tokens[2];
                            string currName = friends[currIndex];
                            friends[currIndex] = newName;
                            Console.WriteLine($"{currName} changed his username to {newName}.");

                        }
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < friends.Count; i++)
            {
                if (friends[i] == "Blacklisted")
                    blacklistCntr++;

                if (friends[i] == "Lost")
                    lostFriendsCntr++;
            }

            Console.WriteLine($"Blacklisted names: {blacklistCntr}\nLost names: {lostFriendsCntr}\n{string.Join(" ", friends)}");
        }
    }
}
