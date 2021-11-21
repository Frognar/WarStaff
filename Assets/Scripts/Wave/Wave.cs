using System.Collections.Generic;
using System;

namespace Frognar {
  [Serializable]
  public class Wave {
    public List<EnemyType> enemies;
    public int count;
    public float timeBetweenSpawns;
  }
}
