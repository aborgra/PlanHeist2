using System;
using System.Collections.Generic;
using System.Linq;

namespace HeistPart2 {
    class Program {
        static void Main (string[] args) {
            var rolodex = new List<IRobber> ();
            Bank targetBank = new Bank ();

            var garrett = new Muscle () {
                Name = "MMuscle",
                SkillLevel = 100,
                PercentageCut = 20,
            };

            var willy = new LockSpecialist () {
                Name = "Pick",
                SkillLevel = 100,
                PercentageCut = 30,
            };

            var kevin = new Hacker () {
                Name = "Kith",
                SkillLevel = 100,
                PercentageCut = 10,
            };

            var namita = new Hacker () {
                Name = "Hack",
                SkillLevel = 100,
                PercentageCut = 20,
            };

            var mac = new LockSpecialist () {
                Name = "MMac",
                SkillLevel = 100,
                PercentageCut = 85,
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

            Dictionary<string, int> bankScores = new Dictionary<string, int> ();

            Random rand = new Random ();
            var alarmScore = rand.Next (0, 101);
            var vaultScore = rand.Next (0, 101);
            var securityGuardScore = rand.Next (0, 101);
            var cashOnHand = rand.Next (50000, 1000001);

            targetBank.AlarmScore = alarmScore;
            targetBank.CashOnHand = cashOnHand;
            targetBank.VaultScore = vaultScore;
            targetBank.SecurityGuardScore = securityGuardScore;

            bankScores.Add ("alarmScore", alarmScore);
            bankScores.Add ("vaultScore", vaultScore);
            bankScores.Add ("securityGuardScore", securityGuardScore);

            var orderedScores = bankScores.OrderBy (score => score.Value);

            var mostSecure = orderedScores.Last ();
            var leastSecure = orderedScores.First ();

            Console.WriteLine ($"Most secure:{mostSecure.Key} at {mostSecure.Value}");
            Console.WriteLine ($"Least secure: {leastSecure.Key} at {leastSecure.Value}");

            foreach (var mem in rolodex) {
                Console.WriteLine ($"{rolodex.IndexOf(mem)} {mem.ToString()}");
            }

            List<IRobber> crew = new List<IRobber> ();
            double totalCutPercentage = 100;

            while (true) {

                Console.WriteLine ("Add member to crew?(Enter member #)");
                var chosenMember = Console.ReadLine ();

                if (chosenMember == "") {
                    break;
                } else {
                    foreach (var item in rolodex) {
                        if (int.Parse (chosenMember) == rolodex.IndexOf (item)) {

                            crew.Add (item);
                            totalCutPercentage -= item.PercentageCut;
                            Console.WriteLine ($"Cut left: {totalCutPercentage}");
                            rolodex.Remove (item);
                            break;

                        }
                    }
                    foreach (var item in rolodex) {
                        if (item.PercentageCut < totalCutPercentage) {
                            Console.WriteLine ($"{rolodex.IndexOf(item)} {item.ToString()}");
                        }
                    }
                }
            }
            Console.WriteLine ("Your assembled crew:");
            foreach (var mem in crew) {
                Console.WriteLine ($"{mem.ToString()}");
            }

            foreach (var crewMember in crew) {
                crewMember.PerformSkill (targetBank);
            }
            double allCuts = 0;

            if (targetBank.IsSecure == true) {
                Console.WriteLine ("You failed the heist.");
            } else {
                Console.WriteLine ($"You did it!");
                foreach (var member in crew) {
                    var yourTake = (member.PercentageCut / 100) * targetBank.CashOnHand;
                    allCuts += yourTake;
                    Console.WriteLine ($"{member.Name}: your cut is ${yourTake.ToString("C")}.");
                    Console.WriteLine ($"Remaining cut: {(targetBank.CashOnHand-allCuts).ToString("C")}");
                }
                Console.WriteLine ($"Leader's cut: {(targetBank.CashOnHand-allCuts).ToString("C")}");
            }

        }
    }
}