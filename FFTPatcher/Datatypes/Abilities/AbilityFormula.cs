/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using PatcherLib;

namespace FFTPatcher.Datatypes
{
    public class AbilityFormula
    {
		#region Public Properties (6) 

        public string Formula { get; private set; }

        public static Dictionary<byte, AbilityFormula> PSPAbilityFormulaHash { get; private set; }

        public static List<AbilityFormula> PSPAbilityFormulas { get; private set; }

        public static Dictionary<byte, AbilityFormula> PSXAbilityFormulaHash { get; private set; }

        public static List<AbilityFormula> PSXAbilityFormulas { get; private set; }

        public byte Value { get; private set; }

		#endregion Public Properties 

		#region Constructors (2) 

        static AbilityFormula()
        {
            PSXAbilityFormulas = new List<AbilityFormula>( Resources.AbilityFormulas.Count );
            PSXAbilityFormulaHash = new Dictionary<byte, AbilityFormula>( Resources.AbilityFormulas.Count );

            PSPAbilityFormulas = new List<AbilityFormula>( Resources.AbilityFormulas.Count );
            PSPAbilityFormulaHash = new Dictionary<byte, AbilityFormula>( Resources.AbilityFormulas.Count );

            foreach (KeyValuePair<byte, string> kvp in Resources.AbilityFormulas)
            {
                AbilityFormula a = new AbilityFormula();
                a.Value = kvp.Key;
                a.Formula = kvp.Value;

                if( a.Value >= 0x65 && a.Value <= 0x6A )
                {
                    AbilityFormula ab = new AbilityFormula();
                    ab.Value = kvp.Key;
                    ab.Formula = string.Empty;
                    PSXAbilityFormulas.Add( ab );
                    PSXAbilityFormulaHash.Add( ab.Value, ab );
                }
                else
                {
                    PSXAbilityFormulas.Add( a );
                    PSXAbilityFormulaHash.Add( a.Value, a );
                }
                PSPAbilityFormulas.Add( a );
                PSPAbilityFormulaHash.Add( a.Value, a );
            }
        }

        private AbilityFormula()
        {
        }

		#endregion Constructors 

		#region Public Methods (1) 

        public override string ToString()
        {
            return string.Format( "{0:X2} {1}", Value, Formula );
        }

		#endregion Public Methods 
    }
}
