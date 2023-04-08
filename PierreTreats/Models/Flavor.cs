using System.Collections.Generic;

namespace PierreTreats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string Description {get; set; }
    public List<TreatFlavor> JoinEntities {get; set; }
  }
}