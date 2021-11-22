using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // SamsungA50, MotorolaG5, HuaweiP10
            List<string> phones = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string phone = string.Empty;
                string newPhone = string.Empty;

                if (command == "Bonus")
                {
                    string[] bonusTokens = tokens[3].Split(':');
                    phone = bonusTokens[0]; //old phone
                    newPhone = bonusTokens[1];
                }
                else
                {
                    phone = tokens[2];
                }

                switch(command)
                {
                    case "Add":
                        if (!phones.Contains(phone))
                        {
                            phones.Add(phone);
                        }
                        break;
                    case "Remove":
                        if (phones.Contains(phone))
                        {
                            phones.Remove(phone);
                        }
                        break;
                    case "Bonus":
                        if (phones.Contains(phone))
                        {
                            int currIndex = phones.IndexOf(phone);
                            if (currIndex + 1 > phones.Count - 1)
                            {
                                phones.Add(newPhone);
                            }
                            else
                            {
                                phones.Insert(currIndex + 1, newPhone);
                            }
                        }
                        break;
                    case "Last":
                        if (phones.Contains(phone))
                        {
                            phones.Remove(phone);
                            phones.Add(phone);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
