using System;

namespace HeistPart2 {

  public class Hacker : IRobber {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }

    public void PerformSkill (Bank bank) {
      bank.AlarmScore -= SkillLevel;
      Console.WriteLine ($"{Name} is hacking the alarm system.  Decreased security score by {SkillLevel}");
      if (bank.AlarmScore <= 0) {
        Console.WriteLine ($"{Name} has disabled the alarm system!");
      }
    }

    public override string ToString () {
      return $"{Name} is a hacker, has a skill level of {SkillLevel} and wants a {PercentageCut}% cut.";
    }

  }

}