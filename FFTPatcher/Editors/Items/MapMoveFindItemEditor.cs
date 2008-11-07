using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class MapMoveFindItemEditor : BaseEditor
    {
		#region Instance Variables (1) 

        private MapMoveFindItems mapMoveFindItems;

		#endregion Instance Variables 

		#region Public Properties (1) 

        public MapMoveFindItems MapMoveFindItems
        {
            get { return mapMoveFindItems; }
            set
            {
                if ( value == null )
                {
                    this.Enabled = false;
                    mapMoveFindItems = null;
                }
                else if ( mapMoveFindItems != value )
                {
                    mapMoveFindItems = value;
                    this.Enabled = true;
                    UpdateView();
                }
            }
        }

		#endregion Public Properties 

		#region Constructors (1) 

        public MapMoveFindItemEditor()
        {
            InitializeComponent();
            moveFindItemEditor1.DataChanged += OnDataChanged;
            moveFindItemEditor2.DataChanged += OnDataChanged;
            moveFindItemEditor3.DataChanged += OnDataChanged;
            moveFindItemEditor4.DataChanged += OnDataChanged;
        }

		#endregion Constructors 

		#region Private Methods (1) 

        private void UpdateView()
        {
            moveFindItemEditor1.MoveFindItem = mapMoveFindItems.Items[0];
            moveFindItemEditor2.MoveFindItem = mapMoveFindItems.Items[1];
            moveFindItemEditor3.MoveFindItem = mapMoveFindItems.Items[2];
            moveFindItemEditor4.MoveFindItem = mapMoveFindItems.Items[3];
        }

		#endregion Private Methods 
    }
}
