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

using System;
using FFTPatcher.Controls;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class ItemAttributeEditor : BaseEditor
    {
		#region Instance Variables (3) 

        private ItemAttributes attributes;
        private bool ignoreChanges = false;
        private NumericUpDownWithDefault[] spinners;

		#endregion Instance Variables 

		#region Public Properties (1) 

        public ItemAttributes ItemAttributes
        {
            get { return attributes; }
            set
            {
                if( value == null )
                {
                    this.Enabled = false;
                    this.attributes = null;
                }
                else if( value != attributes )
                {
                    attributes = value;
                    this.Enabled = true;
                    UpdateView();
                }
            }
        }

		#endregion Public Properties 

		#region Constructors (1) 

        public ItemAttributeEditor()
        {
            InitializeComponent();
            spinners = new NumericUpDownWithDefault[] { maSpinner, paSpinner, speedSpinner, moveSpinner, jumpSpinner };
            foreach( NumericUpDownWithDefault spinner in spinners )
            {
                spinner.ValueChanged += spinner_ValueChanged;
            }

            statusImmunityEditor.DataChanged += OnDataChanged;
            startingStatusesEditor.DataChanged += OnDataChanged;
            permanentStatusesEditor.DataChanged += OnDataChanged;

            strongElementsEditor.DataChanged += OnDataChanged;
            weakElementsEditor.DataChanged += OnDataChanged;
            halfElementsEditor.DataChanged += OnDataChanged;
            absorbElementsEditor.DataChanged += OnDataChanged;
            cancelElementsEditor.DataChanged += OnDataChanged;
        }

		#endregion Constructors 

		#region Public Methods (1) 

        public void UpdateView()
        {
            this.ignoreChanges = true;
            SuspendLayout();
            statusImmunityEditor.SuspendLayout();
            startingStatusesEditor.SuspendLayout();
            permanentStatusesEditor.SuspendLayout();
            strongElementsEditor.SuspendLayout();
            weakElementsEditor.SuspendLayout();
            halfElementsEditor.SuspendLayout();
            absorbElementsEditor.SuspendLayout();
            cancelElementsEditor.SuspendLayout();

            foreach( NumericUpDownWithDefault spinner in spinners )
            {
                spinner.SetValueAndDefault(
                    ReflectionHelpers.GetFieldOrProperty<byte>( attributes, spinner.Tag.ToString() ),
                    ReflectionHelpers.GetFieldOrProperty<byte>( attributes.Default, spinner.Tag.ToString() ) );
            }
            
            statusImmunityEditor.Statuses = attributes.StatusImmunity;
            startingStatusesEditor.Statuses = attributes.StartingStatuses;
            permanentStatusesEditor.Statuses = attributes.PermanentStatuses;

            strongElementsEditor.SetValueAndDefaults( attributes.Strong, attributes.Default.Strong );
            weakElementsEditor.SetValueAndDefaults( attributes.Weak, attributes.Default.Weak );
            halfElementsEditor.SetValueAndDefaults( attributes.Half, attributes.Default.Half );
            absorbElementsEditor.SetValueAndDefaults( attributes.Absorb, attributes.Default.Absorb );
            cancelElementsEditor.SetValueAndDefaults( attributes.Cancel, attributes.Default.Cancel );

            cancelElementsEditor.ResumeLayout();
            absorbElementsEditor.ResumeLayout();
            halfElementsEditor.ResumeLayout();
            weakElementsEditor.ResumeLayout();
            strongElementsEditor.ResumeLayout();
            permanentStatusesEditor.ResumeLayout();
            startingStatusesEditor.ResumeLayout();
            statusImmunityEditor.ResumeLayout();
            ResumeLayout();
            this.ignoreChanges = false;
        }

		#endregion Public Methods 

		#region Private Methods (1) 

        private void spinner_ValueChanged( object sender, EventArgs e )
        {
            if( !ignoreChanges )
            {
                NumericUpDownWithDefault spinner = sender as NumericUpDownWithDefault;
                ReflectionHelpers.SetFieldOrProperty( attributes, spinner.Tag.ToString(), (byte)spinner.Value );
                OnDataChanged( sender, System.EventArgs.Empty );
            }
        }

		#endregion Private Methods 
    }
}
