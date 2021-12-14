﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy <= 0)
                {
                    break;
                }

                if (bunny.Dyes.Count <= 0)
                {
                    break;
                }

                var dye = bunny.Dyes.FirstOrDefault();

                dye.Use();

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }

                bunny.Work();
                egg.GetColored();

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
