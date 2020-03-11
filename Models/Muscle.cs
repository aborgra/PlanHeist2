using System;

namespace HeistPart2 {

  public class Muscle : IRobber {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }

    public void PerformSkill (Bank bank) {
      bank.SecurityGuardScore -= SkillLevel;
      Console.WriteLine ($"{Name} is taking care of the security guard.  Decreased security score by {SkillLevel}");
      if (bank.AlarmScore <= 0) {
        Console.WriteLine ($"{Name} has disabled the security guard!");
      }
    }

    public override string ToString () {
      return $"{Name} is the muscle, has a skill level of {SkillLevel} and wants a {PercentageCut}% cut.";
    }

  }

}