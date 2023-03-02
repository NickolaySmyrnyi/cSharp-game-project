using System;
using System.Collections.Generic;
using System.Text;

namespace Ulearn_project
{
    static class DeskModel
    {
        static public List<Horse> Horses { get; set; } = new List<Horse>(){new Horse("Black Death"),
                                                                           new Horse("Little Princess"),
                                                                           new Horse("Baby"),
                                                                           new Horse("Fast River"),
                                                                           new Horse("Julio"),
                                                                           new Horse("New Era") };

        static public void SetCoefficients(List<string> coefficients)
        {
            for (int i = 0, n = coefficients.Count; i < n; ++i)
                Horses[i].Coefficient = double.Parse(coefficients[i]);
        }
    }
}
