using Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Fakes
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 100;

        public int DurabilityPoints => 50;

        public void Attack(ITarget target)
        {

        }
    }
}
