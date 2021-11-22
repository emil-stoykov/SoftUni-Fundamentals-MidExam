using System;

namespace MidExam11
{
    class Program
    {
        static void Main(string[] args)
        {
            double maxXP = double.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());
            double XP = 0;
            int battleCntr = 0;

            if (maxXP == 0 || maxBattles == 0)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(maxXP - XP):F2} more needed.");
                return;
            }
            while (battleCntr < maxBattles)
            {
                double currXP = double.Parse(Console.ReadLine());
                XP += currXP;
                battleCntr++;
                if (battleCntr % 15 == 0)
                {
                    XP += currXP * 0.05;
                    if (XP >= maxXP)
                    {
                        PrintWin(battleCntr);
                        return;
                    }
                }
                if (battleCntr % 5 == 0)
                {
                    XP -= currXP * 0.10;
                }
                if (battleCntr % 3 == 0)
                {
                    XP += currXP * 0.15;
                    if (XP >= maxXP)
                    {
                        PrintWin(battleCntr);
                        return;
                    }
                }

                if (XP >= maxXP)
                {                   
                    PrintWin(battleCntr);
                    return;
                }

            }

            if (XP < maxXP)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(maxXP - XP):F2} more needed.");
            }
            else
            {
                PrintWin(battleCntr);
            }
        }

        private static void PrintWin(int battleCntr)
        {
            Console.WriteLine($"Player successfully collected his needed experience for {battleCntr} battles.");
        }

    }
}
