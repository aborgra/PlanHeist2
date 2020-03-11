﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HeistPart2 {
    class Program {
        static void Main (string[] args) {
            var rolodex = new List<IRobber> ();
            Bank targetBank = new Bank ();

            var garrett = new Muscle () {
                Name = "Mr. Muscle",
                SkillLevel = 50,
                PercentageCut = 20,
            };

            var willy = new LockSpecialist () {
                Name = "Mr. Pick",
                SkillLevel = 35,
                PercentageCut = 30,
            };

            var kevin = new Hacker () {
                Name = "Mr. Kith",
                SkillLevel = 50,
                PercentageCut = 10,
            };

            var namita = new Hacker () {
                Name = "Ms. Hack",
                SkillLevel = 50,
                PercentageCut = 20,
            };

            var mac = new LockSpecialist () {
                Name = "Mr. Mac",
                SkillLevel = 40,
                PercentageCut = 20,
            };

            rolodex.Add (garrett);
            rolodex.Add (namita);
            rolodex.Add (willy);
            rolodex.Add (mac);
            rolodex.Add (kevin);

            Console.WriteLine ($"Your crew has {rolodex.Count} members");

            while (true) {

                Console.WriteLine ("Please enter a new crew member name:");
                var newCrewMemberName = Console.ReadLine ();
                if (newCrewMemberName == "") {
                    break;
                } else {

                    while (true) {
                        Console.WriteLine ($"What is {newCrewMemberName}'s specialty: Hacker(Disables Alarms), Muscle (Disarms Guards), or Lock Specialist(Cracks Vaults)?");
                        var newCrewMemberSpecialty = Console.ReadLine ();

                        if (newCrewMemberSpecialty.ToLower () == "muscle") {
                            Muscle newMuscle = new Muscle () {
                            Name = newCrewMemberName
                            };
                            Console.WriteLine ("Enter crew member's skill level (1-100)");
                            var newCrewMemberSkillLevel = Console.ReadLine ();
                            newMuscle.SkillLevel = int.Parse (newCrewMemberSkillLevel);
                            Console.WriteLine ("Enter crew member's percentage cut (1-100)");
                            var newCrewMemberPercentageCut = Console.ReadLine ();
                            newMuscle.PercentageCut = int.Parse (newCrewMemberPercentageCut);
                            rolodex.Add (newMuscle);
                            break;

                        } else if (newCrewMemberSpecialty.ToLower () == "hacker") {
                            Hacker newHacker = new Hacker () {
                            Name = newCrewMemberName
                            };
                            Console.WriteLine ("Enter crew member's skill level (1-100)");
                            var newCrewMemberSkillLevel = Console.ReadLine ();
                            newHacker.SkillLevel = int.Parse (newCrewMemberSkillLevel);
                            Console.WriteLine ("Enter crew member's percentage cut (1-100)");
                            var newCrewMemberPercentageCut = Console.ReadLine ();
                            newHacker.PercentageCut = int.Parse (newCrewMemberPercentageCut);
                            rolodex.Add (newHacker);
                            break;

                        } else if (newCrewMemberSpecialty.ToLower () == "lock specialist") {
                            LockSpecialist newLockSpecialist = new LockSpecialist () {
                            Name = newCrewMemberName
                            };
                            Console.WriteLine ("Enter crew member's skill level (1-100)");
                            var newCrewMemberSkillLevel = Console.ReadLine ();
                            newLockSpecialist.SkillLevel = int.Parse (newCrewMemberSkillLevel);
                            Console.WriteLine ("Enter crew member's percentage cut (1-100)");
                            var newCrewMemberPercentageCut = Console.ReadLine ();
                            newLockSpecialist.PercentageCut = int.Parse (newCrewMemberPercentageCut);
                            rolodex.Add (newLockSpecialist);
                            break;

                        } else {
                            Console.Clear ();
                            Console.WriteLine ("Please enter a valid specialty");
                        }

                    }
                }
            }
            Console.WriteLine ($"Your crew has {rolodex.Count} members");
            foreach (var crew in rolodex) {
                Console.WriteLine ($"{crew.Name}");
            }
            Dictionary<string, int> bankScores = new Dictionary<string, int> ();

            Random rand = new Random ();
            var alarmScore = rand.Next (0, 101);
            var vaultScore = rand.Next (0, 101);
            var securityGuardScore = rand.Next (0, 101);
            var cashOnHand = rand.Next (50000, 1000001);

            bankScores.Add ("alarmScore", alarmScore);
            bankScores.Add ("vaultScore", vaultScore);
            bankScores.Add ("securityGuardScore", securityGuardScore);

            var orderedScores = bankScores.OrderBy (score => score.Value);

            var mostSecure = orderedScores.Last ();
            var leastSecure = orderedScores.First ();

            Console.WriteLine ($"Most secure:{mostSecure.Key} at {mostSecure.Value}");
            Console.WriteLine ($"Least secure: {leastSecure.Key} at {leastSecure.Value}");

        }
    }
}