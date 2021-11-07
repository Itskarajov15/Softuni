using MilitaryElite.Enums;
using MilitaryElite.Implementations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            var soldiers = new Dictionary<string, ISoldier>();

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                var id = input[1];
                var firstName = input[2];
                var lastName = input[3];

                if (input[0] == "Private")
                {
                    var salary = decimal.Parse(input[4]);

                    IPrivate privateSoldier = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, privateSoldier);
                }
                else if (input[0] == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(input[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        var currId = input[i];

                        IPrivate currPrivate = soldiers[currId] as IPrivate;

                        lieutenantGeneral.Privates.Add(currPrivate);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (input[0] == "Engineer")
                {
                    var salary = decimal.Parse(input[4]);
                    var corps = input[5];

                    var isValid = Enum.TryParse(corps, out Corps result);

                    if (!isValid)
                    {
                        input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        var repairPart = input[i];
                        var repairHours = int.Parse(input[i + 1]);

                        IRepair repair = new Repair(repairPart, repairHours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (input[0] == "Commando")
                {
                    var salary = decimal.Parse(input[4]);
                    var corps = input[5];

                    var isValid = Enum.TryParse(corps, out Corps result);

                    if (!isValid)
                    {
                        input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        continue;
                    }

                    IComando comando = new Comando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        var missionCode = input[i];
                        var missionStateAsString = input[i + 1];

                        bool isValidState = Enum.TryParse(missionStateAsString, out State missionStateResult);

                        if (!isValidState)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCode, missionStateResult);

                        comando.Missions.Add(mission);
                    }

                    soldiers.Add(id, comando);
                }
                else if (input[0] == "Spy")
                {
                    var codeNumber = int.Parse(input[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
